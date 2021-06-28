using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;
using Tienda.Dto;
using Tienda.Interfaces;
using System.Data;
using System.Globalization;

namespace Tienda.Dapper
{
    public class DapperDataAccess : IProductsCategoryLogic, IUsersLogic
    {

        string connectionString = @"Data Source = ALEJO\SQLEXPRESS; Initial Catalog = MercadoFusion; Integrated Security = True; Persist Security Info = false; Trusted_Connection = True";

        public DapperDataAccess()
        {

        }

        public DapperDataAccess(string connectionString) {
            this.connectionString = connectionString;
        }



        /********** Productos **********/
        /*public List<Product> ListProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Devuelve vista con info que puede ver cualquiera 
                return connection.Query("SELECT * FROM dbo.ProductsInfo").Select(ProductMapper).AsList();
            }
        }*/

        public List<Product> GetProductsPaginated(int index, int fetch)
        {
            List<Product> productsPaginated = new List<Product>();
            DynamicParameters ObjParm = new DynamicParameters();

            ObjParm.Add("@index", index);
            ObjParm.Add("@fetch", fetch);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //return connection.CreateCommand($"EXEC dbo.GetProductsPaginated { index }, { fetch }".Select(ProductMapper).AsList());
                try
                {
                    productsPaginated = connection.Query($"EXEC dbo.GetProductsPaginated { index }, { fetch }").Select(ProductMapper).AsList();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return productsPaginated;
            }
        }
        public List<Product> GetProductsFiltered(string filters, int index, int fetch)
        {
            List<Product> productsPaginated = new List<Product>();
            //DynamicParameters ObjParm = new DynamicParameters();
            //ObjParm.Add("@index", index);
            //ObjParm.Add("@fetch", fetch);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //return connection.CreateCommand($"EXEC dbo.GetProductsPaginated { index }, { fetch }".Select(ProductMapper).AsList());
                try
                {
                    return connection.Query($"EXEC dbo.GetProductsFiltered '{ filters }', { index }, { fetch }").Select(ProductMapper).AsList();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    Console.ReadKey();
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return null;
                }
            }
        }

        public Product CreateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute($"EXEC dbo.NewProduct { product.CategoryID }, '{ product.Name }', '{ product.Description }', { product.Price }, 2");
                return product;
            }
            
        }

        public bool UpdateProduct(Product newProductData, int productID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(@$"EXEC dbo.UpdateProduct { productID }, 
                                                              { newProductData.CategoryID }, 
                                                              '{ newProductData.Name }', 
                                                              '{ newProductData.Description }', 
                                                              { newProductData.Price }, 
                                                              { (int)newProductData.StatusID }"
                                            );
                return  true;
            }
        }


        public Product DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query($"EXEC dbo.DeleteProduct { id }").Select(ProductMapper).FirstOrDefault();
            }
        }

        public Product GetProductByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return ProductMapper(connection.QueryFirstOrDefault($"EXEC dbo.GetProductByID {id}"));
            };
        }

        public List<Product> GetProductByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query($"EXEC dbo.GetProductByName '{ name }'").Select(ProductMapper).AsList();
            };
        }

        private Product ProductMapper(dynamic dbProduct)
        {
            if (dbProduct != null)
            {
                return new Product
                {
                    ProductID = dbProduct.Id,
                    Name = dbProduct.Name,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price,
                    AddedDate = dbProduct.CreatedDate,
                    StatusID = (ProductStatus)dbProduct.StatusId,
                    CategoryID = dbProduct.CategoryId
                };
            }
            return null;
        }

        public List<ProductsCategory> ListProductsCategories()
        {
            List<ProductsCategory> categories = new List<ProductsCategory>();
            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    var reader = connection.ExecuteReader("SELECT Id, Description FROM dbo.Categories");
                    while(reader.Read())
                    categories.Add(new ProductsCategory { CategoryID = int.Parse(reader["Id"].ToString()), Description = reader["Description"].ToString() });
                    reader.Close();
                }
            
            //else
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
                   
            //       var reader = connection.ExecuteReader("SELECT CategoryID, Description FROM dbo.ProductsCategoriesInfo");
            //        while (reader.Read())
            //        {
            //            categories.Add(new ProductsCategory { CategoryID = int.Parse(reader["CategoryID"].ToString()), Description = reader["Description"].ToString() });
            //        }
            //        reader.Close();
            //    }
            //}
            return categories;
        }

        public void CreateProductsCategory(string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute($"EXEC dbo.NewCategory { description }");
            }
        }

        public bool DeleteProductsCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (1 == connection.Execute($"EXEC dbo.DeleteProductsCategory { id }"))
                    return true;
                else
                    return false;
            }
        }

        public void UpdateProductsCategory(ProductsCategory newProductsCategoryData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute($"EXEC dbo.UpdateProductsCategory @Description, @CategoryID",
                    new
                    {
                        Description = newProductsCategoryData.Description,
                        CategoryID = newProductsCategoryData.CategoryID
                    });
            }
        }

        //       ----------------------------------------------------------------------------------------------------------------------------------------
        //                    Usuarios
        //
        /*
        public string[] UserTryLogin(string username)
        {
            List<string> returned = new List<string>();
            //string[] returnd = new string[] { };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader($"EXEC dbo.UserTryLogin '{ username }'");
                //int i = 0;
                while (reader.Read())
                {
                    returned.Add(reader["Salt"].ToString());
                    //i++;
                }
            }

            return returned.ToArray();
        }
        */
        public string[] UserLogin(string username, string password)
        {

            string[] newSession = new string[2];
            //int userID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader($"EXEC dbo.UserLogin '{ username }', '{ password }'");
                while (reader.Read())
                {
                    newSession[0] = reader[0].ToString();
                    newSession[1] = reader[1].ToString();
                }
            }
            return newSession;
        }

        public bool UserSignup(User newUserData, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand($"EXEC dbo.NewUser '{ newUserData.Name }', '{ newUserData.LastName }', { newUserData.DNI }, '{ newUserData.Username }', { password }", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                
                return true;
            }
        }

        public UserTypes ValidateUserType (string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var userType = 3;
                var reader = connection.ExecuteReader($"EXEC dbo.UserType '{ username }'");
                while (reader.Read())
                {
                   int.TryParse(reader[0].ToString(), out userType);
                }
                reader.Close();
                return (UserTypes)userType;
            }                 
        }

        public List<User> ListUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader($"EXEC dbo.GetUsersList");
                var users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User() {
                        DNI = int.Parse(reader["DocumentNumber"].ToString()),
                        LastName = reader["Surname"].ToString(),
                        Name = reader["Name"].ToString(),
                        Username = reader["Username"].ToString(),
                        CreationDate = (DateTime)reader["CreatedDate"]
                        });
                }
                return users;
            }
        }

        public User DisplayUserInfo(string username)
        {
                User userData = new User();
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    var reader = connection.ExecuteReader($"EXEC dbo.RetrieveUserInfo '{ username }'");
                    while (reader.Read())
                    {
                        var i = reader["CreatedDate"].ToString() ;
                        userData = new User() { DNI = int.Parse(reader["DocumentNumber"].ToString()), LastName = reader["Surname"].ToString(), Name = reader["Name"].ToString(), Username = reader["Username"].ToString(), CreationDate = DateTime.Parse(reader["CreatedDate"].ToString()) };
                    }
                
                    return userData;
                }
        }

        public string RetrievePassword(string username)
        {
            string DontYouBeListening = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader($"EXEC dbo.RetrievePassword '{ username }'");
                while (reader.Read())
                {
                    DontYouBeListening = reader[0].ToString();
                }

                return DontYouBeListening;
            }
        }

        public bool UpdateUserInfo(User newUserData, string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute($"EXEC dbo.UpdateUserInfo '{ username }', '{ newUserData.Name }', '{ newUserData.LastName }', { newUserData.DNI }") > 0;
            }
        }

        public string UpdateUserPassword(string username, string StorePassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string password = "";
                var reader = connection.ExecuteReader($"EXEC dbo.UpdateUserPassword '{ username }', '{ StorePassword }'"); 
                while (reader.Read())
                {
                    password = reader[0].ToString();
                }
                return password;
            }

        }

        public bool ComparePassword(string username, string passwordInput)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var reader = connection.ExecuteReader($"EXEC dbo.ComparePasswords '{ username }', '{ passwordInput }'");
                bool match = false;
                while (reader.Read())
                {
                    match = true;
                }
                return match;
            }
        }


        public UserSession RetrieveSession()
        {
            throw new NotImplementedException();
        }

        public User RetrieveUser()
        {
            throw new NotImplementedException();
        }

        public string DontDoThisAtHome(string username)
        {
            throw new NotImplementedException();
        }
    }
}

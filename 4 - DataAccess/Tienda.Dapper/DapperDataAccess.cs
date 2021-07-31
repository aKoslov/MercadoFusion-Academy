using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;
using Tienda.Dto;
using Tienda.Interfaces;
using System.Data;
using System.Globalization;
using Dapper.Contrib.Extensions;

namespace Tienda.DapperDA
{
    public class DapperDataAccess : IProductsCategoryLogic, IUserLogic, IOrderLogic
    {

        string connectionString = @"Data Source = ALEJO\SQLEXPRESS; Initial Catalog = MercadoFusion; Integrated Security = True; Persist Security Info = false; Trusted_Connection = True";

        public DapperDataAccess()
        {

        }

        public DapperDataAccess(string connectionString) {
            this.connectionString = connectionString;
        }

        public ProductList GetProductsPaginated(int index, int fetch, string order)
        {
            ProductList productsPaginated = new ProductList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var pars = new DynamicParameters();
                    pars.Add("index", index);
                    pars.Add("fetch", fetch);
                    pars.Add("order", order);
                    using (var reader = connection.QueryMultiple("dbo.RetrieveProductsPaginated", pars, commandType: CommandType.StoredProcedure))
                    {
                        productsPaginated.List = reader.Read<Product>().AsList();
                        if (productsPaginated.List.Count() == 0 )
                            return null;
                        productsPaginated.Count = reader.ReadSingle<int>();
                        productsPaginated.maxPrice = reader.ReadSingle<int>();
                        productsPaginated.minPrice = reader.ReadSingle<int>();
                    }
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
        public ProductList GetProductsFiltered(DynamicParameters filters, int index, int fetch)
        {
            ProductList productsFiltered = new ProductList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    filters.Add("index", index);
                    filters.Add("fetch", fetch);
                    var reader = connection.QueryMultiple("dbo.RetrieveProductsFiltered", filters, commandType: CommandType.StoredProcedure);
                    productsFiltered.List = reader.Read<Product>().AsList();
                    if (productsFiltered.List.Count == 0)
                    {
                        return null;
                    }
                    productsFiltered.Count = reader.ReadSingle<int>();
                    productsFiltered.maxPrice = reader.ReadSingle<int>();
                    productsFiltered.minPrice = reader.ReadSingle<int>();
                    return productsFiltered;
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

        public long CreateProduct(ProductForInsert product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Insert(product);
                //var productParams = new DynamicParameters();
                //productParams.Add("catid", product.CategoryID);
                //productParams.Add("name", product.Name);
                //productParams.Add("desc", product.Description);
                //productParams.Add("createddate", product.CreatedDate);
                //productParams.Add("price", product.Price);
                //productParams.Add("statusid", product.StatusID);
                //connection.Execute("EXEC dbo.NewProduct", productParams, commandType: CommandType.StoredProcedure);
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

        public int DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var param = new DynamicParameters();
                param.Add("ProductID", id);
                return connection.Query<int>("dbo.DeleteProduct", param, commandType: CommandType.StoredProcedure).First();
            }
        }

        public Product GetProductByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return ProductMapper(connection.QueryFirstOrDefault($"EXEC dbo.RetrieveProductByID {id}"));
            };
        }

        public ProductList GetProductByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var productList = new ProductList();
                var nameParam = new DynamicParameters();
                nameParam.Add("name", name);
                var reader = connection.QueryMultiple("dbo.RetrieveProductByName", nameParam, commandType: CommandType.StoredProcedure);
                productList.List = reader.Read<Product>().AsList();
                productList.Count = reader.ReadSingle<int>();
                return productList;
            };
        }

        private Product ProductMapper(dynamic dbProduct)
        {
            if (dbProduct != null)
            {
                return new Product
                {
                    Id = dbProduct.Id,
                    Name = dbProduct.Name,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price,
                    CreatedDate = dbProduct.CreatedDate,
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
                var idParam = new DynamicParameters();
                idParam.Add("id", id);
                if (1 == connection.Query("dbo.DeleteProductsCategory", id).First())
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
        public UserSession UserLogin(string username, string password)
        {

            //string[] newSession = new string[2];
            //int userID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var loginParams = new DynamicParameters();
                loginParams.Add("username", username);
                loginParams.Add("password", password);
                var newSession = new UserSession() { UserId = -1, UserType = 3 };
                var reader = connection.ExecuteReader("dbo.UserLogin", loginParams, commandType: CommandType.StoredProcedure);
                while (reader.Read())
                {
                    newSession.UserId = int.Parse(reader[0].ToString());
                    newSession.UserType = int.Parse(reader[1].ToString());
                }

                return newSession;
            }
        }

        public bool UserSignup(User newUserData, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("dbo.NewUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name",newUserData.Name);
                command.Parameters.AddWithValue("@LastName", newUserData.Surname);
                command.Parameters.AddWithValue("@DNI", newUserData.DocumentNumber);
                command.Parameters.AddWithValue("@Username", newUserData.Username);
                command.Parameters.AddWithValue("@Password", password);
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
                var reader = connection.QueryMultiple("dbo.RetrieveUsersList", commandType: CommandType.StoredProcedure);
                var users = reader.Read<User>().ToList();
                return users;
            }
        }

        public User DisplayUserInfo(int userId)
        {
                User userData = new User();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("userId", userId);
                    var reader = connection.ExecuteReader("dbo.RetrieveUserInfo", param, commandType: CommandType.StoredProcedure);
                    while (reader.Read())
                    {
                        var i = reader["CreatedDate"].ToString() ;
                        userData = new User() { DocumentNumber = int.Parse(reader["DNI"].ToString()), Surname = reader["LastName"].ToString(), Name = reader["Name"].ToString(), Username = reader["Username"].ToString(), CreationDate = DateTime.Parse(reader["CreatedDate"].ToString()) };
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
                return connection.Execute($"EXEC dbo.UpdateUserInfo '{ username }', '{ newUserData.Name }', '{ newUserData.Surname }', { newUserData.DocumentNumber }") > 0;
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

        public string SendOrder(OrderToStore newOrder, List<OrderLines> orderItems)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                int.TryParse(connection.Insert(newOrder).ToString(), out var orderId);
                orderItems.ForEach(i => i.OrderId = orderId);
                return connection.Insert(orderItems).ToString();
            }
        }
        public OrderList GetOrders(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var userIdParam = new DynamicParameters();
                if (userId > -1)
                    userIdParam.Add("userId", userId);
                if (userId == -1)
                    userIdParam.Add("userId", "%");
                using (var reader =  connection.QueryMultiple("dbo.RetrieveUsersOrders", userIdParam, commandType: CommandType.StoredProcedure)) {

                    var ordersList = new OrderList();
                    ordersList.List = new List<OrderResponse>();
                    var userOrdersList = new List<Order>();
                    var userOrdersLines = new List<OrderLines>();

                    userOrdersList = reader.Read<Order>().ToList();
                    if (userOrdersList == null)
                        return null;

                    userOrdersList.ForEach(order => ordersList.List.Add(new OrderResponse { Details = order, Items = new List<OrderLines>() }));
                    userOrdersLines = reader.Read<OrderLines>().ToList();
                    userOrdersLines.ForEach(line =>
                    {
                        ordersList.List.Find(orderWithLines => orderWithLines.Details.Id == line.OrderId).Items.Add(line);
                    });

                    ordersList.Count = reader.ReadSingle<int>();
                    return ordersList;
                }
                
            }
        }
        public bool UpdateOrderStatus(Order updatedOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Update<Order>(updatedOrder);
            }
        }

    }
}

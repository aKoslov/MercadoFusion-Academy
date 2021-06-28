//using System;
//using System.Linq;
//using Tienda.Dto;
//using Tienda.Interfaces;
//using Tienda.Logic;
//using Tienda.Exceptions;
//using System.Collections.Generic;
//using Microsoft.Data.SqlClient;

//namespace Tienda.ConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {


//            //var bytes = new byte[128 / 8];
//            //var rng = new RNGCryptoServiceProvider();
//            //rng.GetBytes(bytes);
//            //byte[] salt = bytes;
//            ////Hash 
//            //DataHashing hash = new DataHashing();
//            //var hashing = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes("defaultpw"), salt, 10000);
//            //var byteResult1 = Convert.ToBase64String(hashing.GetBytes(24));

//            //hashing = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes("defaultpw"), salt, 10000);
//            //var byteResult2 = Convert.ToBase64String(hashing.GetBytes(24));
//            //if (byteResult1 == byteResult2)
//            //    Console.WriteLine($"match " +
//            //        $"{byteResult1}" +
//            //        $"{byteResult2}");
//            //else
//            //{
//            //    Console.WriteLine($"no match " +
//            //        $"{byteResult1}" +
//            //        $"{byteResult2}");
//            //}
//            //Console.ReadKey();

//            var exitmain = false;
//            IProductLogic productLogic = new ProductLogic();
//            IProductsCategoryLogic productsCategoriesLogic = new ProductsCategoryLogic();
//            IUsersLogic session = new UserLogic(null);

//            //Console.WriteLine(Console.ReadKey().Key);
//            //Console.ReadKey();

//            //Menú Principal en bucle por directiva "exitmain"
//            while (!exitmain)
//            {
//                Console.Clear();
//                var sessionUser = session.RetrieveSession();
//                //Console.WriteLine(session.RetrieveSession().UserID);
//                //Console.WriteLine(session.RetrieveSession().UserID);
//                //Console.ReadKey();
//                //if (sessionUser.UserID == 0)
//                //    sessionUser = null;
//                char menuOption;
//                if (sessionUser == null)
//                {
//                    menuOption = (char)DisplayMenu(0, sessionUser);
//                }
//                else
//                {
//                    menuOption = (char)DisplayMenu(
//                        session.ValidateUserType(sessionUser),
//                        session.RetrieveSession()
//                        );
//                }
//                switch (menuOption)
//                {
//                    case '1': //Iteración de la lista en búsqueda de imprimirla por pantalla de manera esquemática.
                        
//                        Console.Clear();
//                        bool exitCatalog = false;

//                        int index = 1;
//                        int fetch = 10;
//                        string filters = "";
                        
//                        do
//                        {
//                            int rowsAffected = DisplayCatalog(sessionUser, productLogic, index, fetch, filters);
//                            if (rowsAffected > 9)
//                            {
//                                Console.WriteLine($"----------Apretá ENTER para avanzar a página { index + 1 } ----------");
//                                Console.WriteLine($"----------Apretá BACKSPACE para avanzar a página { index - 1} ----------");
//                            }
//                            Console.WriteLine("----------Apretá F para filtrar la búsqueda----------");
//                            Console.WriteLine("----------Apretá ESC para volver a Inicio----------");

//                            var input = Console.ReadKey().Key;
//                            switch (input)
//                            {
//                                case ConsoleKey.Escape:
//                                    exitCatalog = true;
//                                    break;
//                                case ConsoleKey.Enter:
//                                    if (rowsAffected > 9)
//                                        index += 1;
//                                    exitCatalog = false;
//                                    break;
//                                case ConsoleKey.Backspace:
//                                    if (rowsAffected > 9)
//                                        index -= 1;
//                                    exitCatalog = false;
//                                    break;
//                                case ConsoleKey.F:
//                                    bool exitFilters = false;
//                                    do
//                                    {
//                                        Console.Clear();
//                                        Console.WriteLine($"-----------------------------");
//                                        Console.WriteLine($"---------- Filtros ----------");
//                                        Console.WriteLine($"-----------------------------");
//                                        Console.WriteLine("1. Por categoría");
//                                        Console.WriteLine("2. Por precio");
//                                        Console.WriteLine("3. Mostrar sólo disponibles");
//                                        if (filters != "")
//                                        {
//                                            Console.WriteLine("4. Borrar Filtros");
//                                        }
//                                        Console.WriteLine("Enter. Aceptar");

//                                        switch (Console.ReadKey().Key)
//                                        {
//                                            case ConsoleKey.Enter:
//                                                Console.Clear();
//                                                exitFilters = true;
//                                                break;
//                                            case ConsoleKey.NumPad1 or ConsoleKey.D1:
//                                                DisplayCategories(sessionUser);
//                                                Console.WriteLine();
//                                                if (int.TryParse(Console.ReadLine(), out int cat))
//                                                {
//                                                    if (filters == "")
//                                                        filters += $"Category = { cat } ";
//                                                    else
//                                                        filters += $"AND Category = { cat } ";
//                                                    exitFilters = false;
//                                                }
//                                                else
//                                                {
//                                                    Console.WriteLine("pucite mal");
//                                                    exitFilters = false;
//                                                }
//                                                break;
//                                            case ConsoleKey.D2 or ConsoleKey.NumPad2:
//                                                bool exito = false;
//                                                var comparison = ">";
//                                                var price = "";

//                                                do
//                                                {
//                                                    comparison = ">";
//                                                    price = "";
//                                                    Console.Clear();
//                                                    Console.WriteLine($"-----------------------------");
//                                                    Console.WriteLine("Ingresá '<' o '>' y/o '=' que un valor numérico");
//                                                    Console.WriteLine($"-----------------------------");
//                                                    Console.WriteLine();
//                                                    comparison = Console.ReadKey().KeyChar.ToString();

//                                                    if (comparison == "<" || comparison == ">" || comparison == "=")
//                                                    {
//                                                        string comp = Console.ReadKey().KeyChar.ToString();
//                                                        if (comp == "<" || comp == ">" || comp == "=")
//                                                        {
//                                                            comparison.Concat(comp.ToString());
//                                                            exito = true;
//                                                        }
//                                                        else
//                                                        {
//                                                            if (int.TryParse(comp.ToString(), out int porqueria))
//                                                            {
//                                                                price += comp;
//                                                                exito = true;
//                                                            }
//                                                            else
//                                                            {
//                                                                exito = false;
//                                                                continue;
//                                                            }
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        exito = false;
//                                                        continue;
//                                                    }
//                                                    price += Console.ReadLine();
//                                                } while (!exito);

//                                                if (filters == "")
//                                                    filters += $"Price { comparison } { int.Parse(price) }";
//                                                else
//                                                    filters += $"AND Price { comparison } { int.Parse(price) }";
//                                                exitFilters = false;
//                                                break;
//                                            case ConsoleKey.D3 or ConsoleKey.NumPad3:
//                                                if (filters == "")
//                                                    filters += "StatusID = 1";
//                                                else
//                                                    filters += "AND StatusID = 1";
//                                                exitFilters = false;
//                                                break;
//                                            case ConsoleKey.D4 or ConsoleKey.NumPad4:
//                                                if (filters != "")
//                                                {
//                                                    filters = "";
//                                                    exitFilters = true;
//                                                }
//                                                else
//                                                {
//                                                    exitFilters = false;
//                                                }
//                                                break;
//                                            default:
//                                                exitFilters = false;
//                                                break;
//                                        }
//                                    } while (!exitFilters);
//                                    break;
//                                default:
//                                    exitCatalog = false;
//                                    break;
//                            }
//                        } while (!exitCatalog);
                        
//                        break;
//                    case '2':
//                        Console.Clear();
//                        bool exitSearch = false;

//                        do
//                        {
//                            System.Console.WriteLine("----------¿Qué estás buscando comprar hoy?----------");
//                            System.Console.WriteLine("");
//                            string searchbar = Console.ReadLine().ToString();
//                            try
//                            {
//                                var matches = productLogic.GetProductByName(searchbar.ToString());
//                                if (!matches.Any()) throw new NotOnListException();
//                                foreach (var match in matches)
//                                {
//                                    PrintProduct(match);
//                                }
//                                System.Console.WriteLine("");
//                                System.Console.WriteLine("----------Cuando quieras volver a Inicio apretá una tecla cualquiera----------");
//                                Console.ReadKey();
//                                break;
//                            }
//                            catch (NotOnListException)
//                            {
//                                Console.Clear();
//                                System.Console.WriteLine("----------No logramos encontrar nada con ese nombre :(----------");
//                                System.Console.WriteLine("");
//                                System.Console.WriteLine("Presioná una tecla cualquiera para volver a buscar o ESC para volver a Inicio");
//                                if (Console.ReadKey().Key == ConsoleKey.Escape)
//                                {
//                                    Console.Clear();
//                                    break;
//                                }
//                                exitSearch = false;
//                            }
//                        } while (!exitSearch);
//                        break;

//                    case '3':
//                        Console.Clear();
//                        if (session.ValidateUserType(sessionUser) == 1)
//                        {
//                            PublishProduct(productLogic, productsCategoriesLogic, sessionUser);
//                        }
//                        else
//                        {
//                            DisplayCategories(sessionUser);
//                            Console.WriteLine();
//                            Console.WriteLine();
//                            Console.WriteLine("-----------------------------------------------------------");
//                            Console.WriteLine("--------------------------- Volver ------------------------");
//                            Console.WriteLine("-----------------------------------------------------------");
//                            Console.ReadKey();
//                        }
//                        break;

//                    case '4':
//                        Console.Clear();
//                        switch (session.ValidateUserType(sessionUser))
//                        {
//                            default:
// //session = new UserLogic (LoginForm(session));
//                                break;
//                            case 1:
//                                UpdateProduct(productLogic, productsCategoriesLogic, sessionUser);
//                                break;
//                            case 2:
//                                DisplayUserInfo(session);
//                                break;
//                        }
//                        break;

//                    case '5':
//                        Console.Clear();
//                        switch (session.ValidateUserType(sessionUser))
//                        {
//                            default:
//                                SignupForm(session);
//                                break;
//                            case 1:
//                                DisplayUserInfo(session);
//                                break;
//                            case 2:
//                                exitmain = true;

//                                Console.WriteLine("----------¡Nos vemos la próxima!----------");
//                                Console.ReadKey();
//                                break;
//                        }
//                        continue;

//                        //if (session.ValidateUserType(sessionUser) == 1)
//                        //{
//                        //    DisplayUserInfo(session);
//                        //    break;
//                        //}
//                        //else
//                        //{
//                        //    exitmain = true;

//                        //    Console.WriteLine("----------¡Nos vemos la próxima!----------");
//                        //    Console.ReadKey();

//                        //    continue;
//                        //}


//                    case '6':
//                        Console.Clear();
//                        Console.WriteLine("---------- Configuración de Cuenta----------");
//                        Console.WriteLine();
//                        session.DisplayUserInfo(sessionUser);
//                        Console.WriteLine($"");
//                        exitmain = true;
//                        break;

//                    case '7':
//                        exitmain = false;
//                        continue;

//                    default:

//                        Console.WriteLine("<!--¡No te entendí! Decime de nuevo--!>");
//                        Console.WriteLine("");
//                        break;
//                }
//            }
//        }
//        //

//        private static bool SignupForm(IUsersLogic session)
//        {
//            bool signupSuccess = false;
//            do
//            {

//                Console.Clear();

//                DataHashing hash = new DataHashing();

//                Console.Write(
//        $@"Create una Cuenta
//    Nombre de Usuario:      ");
//                string username = Console.ReadLine();
//                Console.Write(
//        $@"Contraseña:          ");

//                //string hashedData = hash.ComputeHash(Encoding.UTF8.GetBytes(Console.ReadLine()));
//                string hashedData = Console.ReadLine();

//                Console.Write(
//        $@"Nombre:              ");
//                string name = Console.ReadLine();

//                Console.Write(
//        $@"Apellido:            ");
//                string lastNanme = Console.ReadLine();

//                Console.Write(
//        $@"DNI:                 ");
//                int.TryParse(Console.ReadLine(), out int dni);
//                try
//                {
//                    //signupSuccess = session.UserSignup(new User { Name = name, LastName = lastNanme, DNI = dni }, hashedData, "2", "2");
//                } catch (SqlException sqlE)

//                {
//                    Console.WriteLine("Credenciales Incorrectas,\n         intentá de nuevo." + sqlE.Message);
//                    Console.ReadKey();
//                    signupSuccess = false;
//                }
//            } while (!signupSuccess);

//            return signupSuccess;
//        }

////        private static UserSession LoginForm(IUsersLogic session)
////        {
////            DataHashing hash = new DataHashing();

////            Console.Write(
////$@"Inicia Sesión
////                notanotherstaffmember defaultpw
////                notanothercustomer defaultpw
////Nombre de Usuario:      ");
////            string username = Console.ReadLine();
////            Console.Write(
////$@"Contraseña:          ");

////            var hashedData = hash.ComputeHash(Encoding.UTF8.GetBytes(Console.ReadLine()), Encoding.UTF8.GetBytes("me sigo informando aún sobre hashing y dehashing"));
//        //    if (int.TryParse(session.UserLogin(username, ).ToString(), out int userID))
//        //    {
//        //        UserSession sessionUser = new UserSession() { Username = username };
//        //        session = new UserLogic(sessionUser);
//        //        return sessionUser;
//        //    }
//        //    return session.RetrieveSession();
//        //}
//        private static void PrintProduct(Product product)
//        {
//            System.Console.WriteLine("");
//            System.Console.WriteLine("--------------------");
//            System.Console.WriteLine($" ID: {product.ProductID} - {product.Name} - Precio ${product.Price}\nDescripción:\n{product.Description}");
//            System.Console.WriteLine("--------------------");
//        }
//        private static void PrintProductsCategories(ProductsCategory productCategory)
//        {
//            Console.WriteLine();
//            Console.WriteLine("----------------------------------------");
//            Console.WriteLine();
//            Console.WriteLine($"        { productCategory.CategoryID }      { productCategory.Description }");
//            Console.WriteLine();
//            Console.WriteLine("----------------------------------------");

//        }
//        private static int DisplayMenu(int userType, UserSession session)
//        {
//            char menuOption = ' ';
//            do
//            {
//                try
//                {
//                    switch (userType)
//                    {
//                        default:
//                            Console.WriteLine($@"
//    --------------------MercadoFusión--------------------

//                                                               Bienvenidx Guest
//    ¡Nuevo! Menúes Y/N activados por ReadKey + Opción volver a Inicio con Esc


//    Ingresá tu opción
//    1. Catálogo
//    2. Buscar para Comprar
//    3. Categorías de Productos
//    4. Iniciar Sesión
//    5. Registrarse
//                    ");
//                            menuOption = Console.ReadKey().KeyChar;
                            
//                            if (!(menuOption == '1' || menuOption == '2' || menuOption == '3' || menuOption == '4' || menuOption == '5'))
//                                throw new InvalidOptionException();
//                            break;
//                        case 2:

//                            Console.WriteLine($@"
//    --------------------MercadoFusión--------------------

//                                                               Bienvenidx { session.Username }
//    ¡Nuevo! Menúes Y/N activados por ReadKey + Opción volver a Inicio con Esc


//    Ingresá tu opción
//    1. Catálogo
//    2. Buscar para Comprar
//    3. Categorías de Productos
//    4. Cuenta
//    5. Cerrar Sesión
//                    ");
//                            menuOption = Console.ReadKey().KeyChar;
//                            if (!(menuOption == '1' || menuOption == '2' || menuOption == '3' || menuOption == '4' || menuOption == '5'))
//                                throw new InvalidOptionException();
//                            break;
//                        case 1:

//                            Console.WriteLine($@"
//    --------------------MercadoFusión--------------------

//                                                               Bienvenidx { session.Username }

//    ¡Nuevo! Menúes Y/N activados por ReadKey + Opción volver a Inicio con Esc


//    Ingresá tu opción
//    1. Catálogo de Mercadería
//    2. Buscar Artículos
//    3. Publicar Artículo
//    4. Editar Publicación
//    5. Cuenta
//    6. Cerrar Sesión
//                    ");
//                           menuOption = Console.ReadKey().KeyChar;
//                            if (!(menuOption == '1' || menuOption == '2' || menuOption == '3' || menuOption == '4' || menuOption == '5' || menuOption == '6'))
//                                throw new InvalidOptionException();
//                            break;
//                    }
//                }
//                catch (InvalidOptionException optEx)
//                {
//                    Console.WriteLine(optEx.Message);
//                    Console.ReadKey();
//                    continue;
//                }

//           } while (menuOption == ' ');
//            return (int)menuOption;
//        }
//        private static int DisplayCatalog(UserSession session, IProductLogic productLogic, int index, int fetch, string filters)
//        {
//            int rowsAffected = 0;
//            Console.Clear();
//            Console.WriteLine("----------Catálogo----------");
//            Console.WriteLine("");
//            //Console.Write(filters + " " + filtered);
//            //Console.ReadKey();
//            if (filters == "")
//            {
//                var products = productLogic.GetProductsPaginated(index, fetch);
//                if (!products.Any())
//                {
//                    Console.WriteLine("No hay productos para mostrar");
//                    Console.ReadKey();
//                }
//                else
//                {
//                    foreach (var product in products)
//                    {
//                        PrintProduct(product);
//                        //Console.Write($"--------------------\nID: {product.ProductID} - {product.Name} - Precio ${product.Price}\nDescripción:\n{product.Description}\n--------------------\n");
//                    }
//                    rowsAffected = products.Count();
//                }
//            }
//            else
//            {
//                //var products = productLogic.GetProductsFiltered(($"' { filters } '"), index, fetch);
//                var products = new List<Product>();
//                if (products == null)
//                {
//                    Console.WriteLine("No hay productos para mostrar");
//                    Console.ReadKey();
//                }
//                else
//                {
//                    foreach (var product in products)
//                    {
//                        PrintProduct(product);
//                        //Console.Write($"--------------------\nID: {product.ProductID} - {product.Name} - Precio ${product.Price}\nDescripción:\n{product.Description}\n--------------------\n");
//                    }
//                    rowsAffected = products.Count();
//                }
//            }
//            return rowsAffected;
//        }
//        private static void DisplayCategories(UserSession session)
//        {
//            IProductsCategoryLogic categoriesLogic = new ProductsCategoryLogic();
//            foreach (ProductsCategory productCategory in categoriesLogic.ListProductsCategories(session))
//            {
//                PrintProductsCategories(productCategory);
//            }

//        }
//        private static void DisplayUserInfo(IUsersLogic session)
//        {
//            Console.Clear();
//            User userData = session.DisplayUserInfo(session.RetrieveSession());
//            Console.WriteLine(
//$@"Nombre de Usuario:     { session.RetrieveSession().Username }
//Nombre:                   { userData.Name } { userData.LastName }      DNI:                   { userData.DNI }
//Contacto:                 {userData.PhoneNumber }                      CakeDay:               { userData.CreationDate }");
//        }
//        private static void PublishProduct(IProductLogic productLogic, IProductsCategoryLogic productsCategoriesLogic, UserSession session)
//        {
//            bool exitPublish = false;

//            do
//            {
//                try
//                {
//                    Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                    Console.WriteLine("");

//                    Product newProduct = new Product();

//                    /*
//                    Console.Write("ID           ");

//                    bool checkinput = int.TryParse(Console.ReadLine(), out int id);

//                    while (!checkinput)
//                    {
//                        Console.Clear();
//                        Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                        Console.WriteLine("");
//                        Console.WriteLine("<!--¡Recordá! El ID tiene que ser un número decimal. Intentá de nuevo.--!>");
//                        Console.Write("ID           ");
//                        checkinput = int.TryParse(Console.ReadLine(), out id);
//                        if (checkinput)
//                        {
//                            Console.Clear();
//                            Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                            Console.WriteLine("");
//                            Console.WriteLine($"ID           {id}");
//                        }
//                    }
//                    if (logic.GetProductByID(id) != null) throw new Exceptions.DuplicatedItem();
//                    */
//                    Console.Write("Nombre       ");
//                    var name = Console.ReadLine();
//                    Console.Write("Descripción  ");
//                    var description = Console.ReadLine();
//                    Console.Write("Categoría  ");
//                    Console.WriteLine();
//                    foreach (var productsCategory in productsCategoriesLogic.ListProductsCategories(session))
//                    {
//                        PrintProductsCategories(productsCategory);
//                    }
//                    bool success = int.TryParse(Console.ReadLine(), out int categoryid);
//                    while (!success)
//                    {
//                        Console.Clear();
//                        Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                        Console.WriteLine("");
//                        Console.Write("Nombre       " + name);
//                        Console.Write("Descripción  " + description);
//                        Console.Write("Categoría  ");
//                        Console.WriteLine("<!--¡Recordá seleccionar una de las categorías disponibles!. Intentá de nuevo.--!>");
//                        success = int.TryParse(Console.ReadLine(), out categoryid);
//                    }
//                    try
//                    {
//                        if (!productsCategoriesLogic.ListProductsCategories(session).Any(pc => pc.CategoryID == categoryid))
//                            throw new NullReferenceException();
//                        exitPublish = true;
//                    }
//                    catch (NullReferenceException exc)
//                    {
//                        Console.WriteLine(exc.Message);
//                        Console.ReadKey();
//                        exitPublish = false;
//                        continue;
//                    }

//                    Console.Write("Precio      $");
//                    bool checkinput = decimal.TryParse(Console.ReadLine(), out decimal price);
//                    Console.WriteLine(price);

//                    while (!checkinput)
//                    {
//                        Console.Clear();
//                        Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                        Console.WriteLine("");
//                        //  Console.WriteLine($"ID           {id}");
//                        Console.WriteLine($"Nombre       {name}");
//                        Console.WriteLine($"Descripción  {description}");
//                        Console.WriteLine("<!--¡Recordá! El precio tiene que ser un número decimal. Intentá de nuevo.--!>");
//                        Console.Write("Precio      $");
//                        checkinput = decimal.TryParse(Console.ReadLine(), out price);
//                    }

//                    Console.Clear();
//                    do
//                    {
//                        Console.WriteLine("----------¿Qué vas a vender hoy?----------");
//                        Console.WriteLine("");
//                        //  Console.WriteLine($"ID           {id}");
//                        Console.WriteLine($"Nombre       {name}");
//                        Console.WriteLine($"Descripción  {description}");
//                        Console.WriteLine($"Precio      ${price}");
//                        Console.WriteLine($"Categoría    {productsCategoriesLogic.ListProductsCategories(session).Find(pc => pc.CategoryID == categoryid).Description} ");
//                        Console.WriteLine("");
//                        Console.WriteLine("Publicar (Y/N)");
//                        var rdKey = Console.ReadKey();
//                        if (rdKey.Key == ConsoleKey.Escape)
//                        {
//                            exitPublish = true;
//                            break;
//                        }
//                        string submit = rdKey.KeyChar.ToString().ToUpper();
//                        switch (submit)
//                        {
//                            case "Y":
//                                {
//                                    Console.WriteLine("");
//                                    //  newProduct.ProductID = id;
//                                    newProduct.Name = name;
//                                    newProduct.Description = description;
//                                    newProduct.Price = price;
//                                    newProduct.CategoryID = categoryid;
//                                    productLogic.CreateProduct(newProduct);
//                                    System.Console.WriteLine("");
//                                    Console.WriteLine("----------Venta Publicada----------");
//                                    Console.WriteLine("");
//                                    Console.WriteLine("----------Apretá una tecla para volver a Inicio----------");
//                                    Console.ReadKey();
//                                    exitPublish = true;
//                                    Console.Clear();
//                                    break;
//                                };
//                            case "N":
//                                {
//                                    Console.WriteLine(":(");
//                                    Console.ReadKey();
//                                    Console.Clear();
//                                    exitPublish = true;
//                                    break;
//                                };
//                            default:
//                                {
//                                    Console.Clear();
//                                    System.Console.WriteLine("");
//                                    System.Console.WriteLine("Opción Incorrecta, intentá de nuevo");
//                                    System.Console.WriteLine("");
//                                    Console.ReadKey();
//                                    exitPublish = false;
//                                    break;
//                                };
//                        } while (!exitPublish);
                        
//                    } while (!exitPublish);



//                }
//                catch (InvalidOperationException exc)
//                {
//                    Console.WriteLine(exc.Message);
//                }
//            } while (true);
//        }
//        private static void UpdateProduct(IProductLogic productLogic, IProductsCategoryLogic productsCategoryLogic, UserSession session)
//        {

//            bool exitDelete = false;
//            do
//            {

//                try
//                {
//                    System.Console.WriteLine("----------Eliminar Publicación----------");
//                    System.Console.WriteLine("");
//                    System.Console.WriteLine("Ingresá el ID de la publicación");
//                    //var keyPressed = Console.ReadKey();
//                    System.Console.WriteLine();
//                    //if (keyPressed.Key == ConsoleKey.Escape) break;
//                    //keyPressed.KeyChar.ToString()
//                    bool success = int.TryParse(Console.ReadLine(), out int idDel);
//                    if (success)
//                    {
//                        var itemToRemove = productLogic.GetProductByID(idDel);
//                        if (itemToRemove != null)
//                        {
//                            System.Console.WriteLine("");
//                            System.Console.WriteLine("¿Es esta la publicación que querés dar de baja? Y/N");
//                            System.Console.WriteLine("");
//                            PrintProduct(itemToRemove);
//                            System.Console.WriteLine("--------------------");
//                            System.Console.WriteLine("");
//                            var rdKey = Console.ReadKey();
//                            if (rdKey.Key == ConsoleKey.Escape)
//                            {
//                                Console.Clear();
//                                exitDelete = true;
//                                break;
//                            }
//                            string chr = rdKey.KeyChar.ToString().ToUpper();
//                            switch (chr)
//                            {
//                                case "Y":
//                                    productLogic.DeleteProduct((int)(itemToRemove.ProductID));
//                                    System.Console.WriteLine("");
//                                    System.Console.WriteLine("----------Bajamos tu publicación, ¡volvé pronto!----------");
//                                    System.Console.WriteLine("");
//                                    System.Console.WriteLine("Apretá una tecla cualquiera para continuar");
//                                    System.Console.WriteLine("\"No hay una tecla cualquiera :(\"");
//                                    System.Console.WriteLine("");
//                                    Console.ReadKey();
//                                    Console.Clear();
//                                    exitDelete = true;
//                                    break;
//                                case "N":
//                                    Console.Clear();
//                                    System.Console.WriteLine("----------Eliminar Publicación----------");
//                                    System.Console.WriteLine("");
//                                    System.Console.WriteLine("¿Querés seleccionar otra publicación? Para volver a Inicio seleccioná No Y/N");
//                                    rdKey = Console.ReadKey();
//                                    if (rdKey.Key == ConsoleKey.Escape)
//                                    {
//                                        Console.Clear();
//                                        exitDelete = true;
//                                        break;
//                                    }
//                                    chr = rdKey.KeyChar.ToString().ToUpper();
//                                    Console.Clear();
//                                    switch (chr)
//                                    {
//                                        case "Y":
//                                            {
//                                                exitDelete = false;
//                                                Console.Clear();
//                                                break;
//                                            };
//                                        case "N":
//                                            {
//                                                exitDelete = true;
//                                                Console.Clear();
//                                                break;
//                                            };
//                                        default:
//                                            {
//                                                System.Console.WriteLine("Es Y o N, ahí vas de nuevo. Para volver a Inicio apretá ESC.");
//                                                System.Console.WriteLine("all you had to do was follow the damn train cj");
//                                                rdKey = Console.ReadKey();
//                                                if (rdKey.Key == ConsoleKey.Escape)
//                                                {
//                                                    Console.Clear();
//                                                    exitDelete = true;
//                                                    break;
//                                                }
//                                                chr = rdKey.KeyChar.ToString().ToUpper();
//                                                Console.Clear();
//                                                exitDelete = false;
//                                                break;
//                                            };
//                                    }
//                                    break;
//                                default:
//                                throw new InvalidOptionException();

//                            }
//                        }
//                        else
//                        {
//                            throw new Exceptions.NotOnListException();
//                        }
//                    }
//                    else
//                    {
//                        Console.Clear();
//                        System.Console.WriteLine("----------¡Recordá que los índices están en números decimales!----------");
//                        System.Console.WriteLine("");
//                        System.Console.WriteLine("Apretá una tecla para intentar de nuevo");
//                        System.Console.WriteLine("");
//                        if (Console.ReadKey().Key == ConsoleKey.Escape)
//                        {
//                            Console.Clear();
//                            break;
//                        }
//                        Console.Clear();
//                        exitDelete = false;
//                    }
//                }
//                catch (NotOnListException nol)
//                { //Excepción Custom para casos donde el ID ingresado no se encuentra en la lista.
//                    Console.Clear();
//                    System.Console.WriteLine("----------¡No encontramos el elemento!----------");
//                    System.Console.WriteLine("");
//                    System.Console.WriteLine("Error ocurrido para más info:\n" + nol.Message);
//                    System.Console.WriteLine("");
//                    System.Console.WriteLine("----------Apretá una tecla para reintentar o ESC para volver a inicio----------");
//                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
//                    {
//                        Console.Clear();
//                        break;
//                    }
//                    else
//                    {
//                        Console.Clear();
//                        exitDelete = false;
//                    }
//                }
//                catch (InvalidOptionException invOptE)
//            {
//                    Console.Write(invOptE.Message);
//            }
//            } while (!exitDelete);
//        }

//    }
//}
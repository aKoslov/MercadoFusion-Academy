USE [MercadoFusion]
GO

--------------------- 3 Tipos de Usuarios

	--	SELECT * FROM dbo.UserTypes

INSERT INTO dbo.UserTypes VALUES ('Staff'), ('Customer'), ('Guest')

--------------------- 10 Usuarios
DELETE FROM Users
--	SELECT * FROM dbo.Users

INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (39437741,
'Rodriguez','Maria','Bwpi/X+XHqp8sirsj2GCKhBryp9IzLJG','marialadelbarrio','099999999',1,'f8VVNFzwD8daCaD62qMnyw==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (22408322,
'Gonzalez','Juan','ceC4r7lIIuUngLRYHAUOLOgqhS3MjG/Z','juango1','099999999',1,'Q3Ditu5iiEQAhrTeSZKadQ==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (68749753,
'Martinez','Jose','YVFYWubJZjrA/Pq3Kv1Gdowd5p4pW5i0','josema','099999999',1,'Bn44EOzo/dVtKJzbbR0Rcw==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (68971774,
'Fernandez','Carlos','6lKB7kSwkUWQzv7z4XxhZXAiALqUIy/o','carfer','099999999',1,'RDDygqZR2w1E3ih92f15WA==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (66026195,
'Perez','Luis','mJZ/RLbRrudFNXjm4UFXoNxXnASKTFZu','lp009','099999999',1,'M5cppBpLYzhlHGaWdjnEfQ===')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (57050356,
'Garcia','Ana','6snzAos7ZEREdz6thvfWP3lpRZKKCgtE','anagar','099999999',2,'wHzRWiq4iLlzTqTaWihFkg==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (10552877,
'Silva','Jorge','T3Iz3YBJwEhgqam0c8WuJsv9ouWfoht+','jorgesilva1948','099999999',2,'4Hr646DFBkRPmL+zjDrh5w==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (28627408,
'Lopez','Ruben','EplH0drfrnqVpluI3v7dk4so8nXvx6jY','rublox','099999999',2,'sBVY12Q/8ENC0gEx4TNbXA==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (50045579,
'Pereira','Walter','RdOguFIKZmbQIEXvXMEd+3XiHBwC72nW','waper','099999999',2,'KmDF5mOE5l1ntDhaTb9Mkw==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (18453850,
'Sosa','Miguel','bMsyF2+v/qxYs9VzXcySbIrNgrAwDA90','usercreated32091273','099999999',2,'pOMijqG9ragzA/HcIr0H/w==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[UserType],[Salt]) VALUES (555666888,
'lastname','name','4QDORjrYt1Id6HokHs629LiPd5y4sa0L','notanothercustomer',2,'mMlptxLf/nFr0tUEbkanDg==')
INSERT INTO dbo.Users([DNI],[LastName],[Name],[Password],[Username],[PhoneNumber],[UserType],[Salt]) VALUES (555666888,
'lastname','name','MNZdirK0oc8KSqxoBMKvc75sCjTrDWLs','notanotherstaffmember',2,'Bd3/MrIaSrNW6lbfUp+8fA==')

--SELECT * FROM dbo.Users

--------------------- 7 Categor�as

--SELECT * FROM dbo.ProductsCategories

INSERT INTO dbo.ProductsCategories([Description]) VALUES ('Bebidas')
INSERT INTO dbo.ProductsCategories([Description]) VALUES ('L�cteos')
INSERT INTO dbo.ProductsCategories([Description]) VALUES ('Limpieza y Hogar')
INSERT INTO dbo.ProductsCategories([Description]) VALUES ('Vida Sana')
INSERT INTO dbo.ProductsCategories([Description]) VALUES ('Panader�a')
INSERT INTO dbo.ProductsCategories([Description]) VALUES ('Preparados')
EXECUTE dbo.NewCategory 'Alacena';
GO

--SELECT * FROM dbo.ProductsCategories

--------------------- 3 Estados de Disponibilidad

INSERT INTO ProductsStates VALUES (1,'Available'),(0,'Unavailable'),(2,'Out Of Stock')

--------------------- SELECT * FROM ProductsStates

--------------------- 30 Productos

--SELECT * FROM Products

INSERT INTO dbo.Products([CategoryID], [Name], [Description],[Price],
[StatusID]) VALUES (3, 'Detergente Primor','Deter m�s que la gente', 33.31,1)
INSERT INTO dbo.Products([CategoryID], [Name],[Description],[Price],
[StatusID]) VALUES (3,'Fabulosamente Sin �', 'Tulipanes y Kiwi 1L', 2.31,0)
INSERT INTO dbo.Products([CategoryID], [Name],[Description],[Price],
[StatusID]) VALUES (6,'Caf� Pel�ador', 'Soluble en Polvo 200g', 169.31,0)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'CocaKola 655ml','Refrescura paladar o algo as�',55.60,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (2,'Yogurt Mercantil','Durazno 1L',71,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Garbanzos La Carencia','400G quedan muy buenos al horno con especias y salsa de soja',50,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (1,'Vino El Nogal','Truchazo pero barato',94,0)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Porotos Ocultaci�n','Negros 400G',50,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Agua Salud','1.25L Con Gas',75,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Vinagre Queens Gambit','De Alcohol 500ml',40,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Salsa de Soja','La m�s barata porque es car�sima 250ml',100,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Porotos Ocultaci�n','Frutilla 400G',50,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (1,'Paso de los Bueyes','Llena de az�car 1,25L',120,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (2,'Leche Blanca Nimbostratus','La �nica que te deja dudando por qu� ser� m�s barata',47,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Galleta Renata','Tripaq',60,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Aceite Deficiente','Canola 900ml',92,1)
INSERT INTO dbo.Products ([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (1,'Cerveza Sure�a','1L',110,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (7,'Galleta 9 de Oro','Agridulce 200G',46,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Hasta se me acab� la lista de compra','Podr� copiar y pegar?hmmm',4.20,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (3,'Termo Thermos 1L','Qu� caros son los termos',1000,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (3,'Jab�n Girando Luna','En Barra 200G',20,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (3,'Trapo','De piso',20,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (6,'Granola Devil','90G no ser� tan rica pero s� es medio barata ;)',59,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (6,'Man� Manix Japon�s','Versi�n de Jam�n',64,0)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Solo 5 m�s','Despu�s sigo agregando productos reales',1312,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Caf� Bracaf�','Nestl� deja a consciencia sin agua a familias. 15 sticks',44,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Soja La Carencia','400G',80,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Semillas de chia La Carencia','80G',80,1)
INSERT INTO dbo.Products([CategoryID],[Name],[Description],[Price],
[StatusID]) VALUES (4,'Polenta Ocultaci�n','400G',30,1)
EXECUTE dbo.NewProduct 4,'Yogurt Mercantil','Deslactosado 500G',120,1
GO

--SELECT * FROM dbo.Products

--------------------- 15 �rdenes

-- SELECT * FROM dbo.Carts

INSERT INTO dbo.Carts([UserID],[IsOpen]) VALUES (1,0)
INSERT INTO dbo.Carts([UserID],[IsOpen]) VALUES (2,0)
INSERT INTO dbo.Carts([UserID],[IsOpen]) VALUES (3,0)
INSERT INTO dbo.Carts([UserID],[IsOpen]) VALUES (4,0)
INSERT INTO dbo.Carts([UserID]) VALUES (5)
INSERT INTO dbo.Carts([UserID]) VALUES (6)
INSERT INTO dbo.Carts([UserID]) VALUES (7)
INSERT INTO dbo.Carts([UserID]) VALUES (8)
INSERT INTO dbo.Carts([UserID]) VALUES (9)
INSERT INTO dbo.Carts([UserID]) VALUES (10)
INSERT INTO dbo.Carts([UserID],[IsOpen]) VALUES (3,0)
INSERT INTO dbo.Carts([UserID]) VALUES (2)
INSERT INTO dbo.Carts([UserID]) VALUES (3)
INSERT INTO dbo.Carts([UserID]) VALUES (4)
EXECUTE dbo.NewCart 2
GO

	--	SELECT * FROM dbo.Carts

 --------------------- 30 Productos Encargados
 
	--	SELECT * FROM dbo.ProductToCart 

INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (1,1,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (1,4,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (2,5,2)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (2,6,3)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (2,8,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (2,9,3)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,10,7)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,11,3)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,12,6)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,13,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,14,2)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,15,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,16,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,17,3)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (3,30,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (4,18,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (5,19,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (6,20,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (7,21,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (8,22,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (9,23,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (10,24,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (11,25,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (12,26,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (13,27,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (14,28,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (14,29,1)
INSERT INTO dbo.ProductToCart([CartID],[ProductID],[Quantity]) VALUES (15,18,1)
	
	--	SELECT * FROM ProductToCart

--------------------- 5 pedidos encargados ---------------------

	/*	SELECT * FROM dbo.Orders
		SELECT * FROM dbo.ProductToOrder	*/
	--Users con Pedidos Realizados
	EXEC dbo.SendOrder 1
	EXEC dbo.SendOrder 2
	EXEC dbo.SendOrder 3
	EXEC dbo.SendOrder 4
	-- Resto
	/*
	EXEC dbo.SendOrder 5
	EXEC dbo.SendOrder 6
	EXEC dbo.SendOrder 7
	EXEC dbo.SendOrder 8
	EXEC dbo.SendOrder 9
	EXEC dbo.SendOrder 10
	*/
	--	select * from ProductsInfo
--------------------- 3 pedidos pagos ---------------------

	EXEC dbo.PaidOrder 1
	EXEC dbo.PaidOrder 2
	EXEC dbo.PaidOrder 4

--------------------- 2 Carritos Cancelados sin realizar �rden ---------------------

	EXEC CloseCart 4
	EXEC CloseCart 8
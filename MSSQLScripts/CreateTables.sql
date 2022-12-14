/*
	Создание таблиц.
*/

CREATE TABLE [dbo].[Category](
	[IdCategory] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 18.09.2022 0:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 18.09.2022 0:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[IdProduct] [int] NOT NULL,
	[IdCategory] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC,
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (3, N'В тренде')
INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (5, N'Дешёвое')
INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (6, N'Дорогое')
INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (4, N'Интересное')
INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (2, N'Удобное')
INSERT [dbo].[Category] ([IdCategory], [Title]) VALUES (1, N'Умное')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([IdProduct], [Title]) VALUES (1, N'Айфон')
INSERT [dbo].[Product] ([IdProduct], [Title]) VALUES (4, N'Приставка')
INSERT [dbo].[Product] ([IdProduct], [Title]) VALUES (2, N'Пылесос')
INSERT [dbo].[Product] ([IdProduct], [Title]) VALUES (5, N'Учебник математики')
INSERT [dbo].[Product] ([IdProduct], [Title]) VALUES (3, N'Часы')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (1, 3)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (1, 6)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (2, 2)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (2, 5)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (3, 1)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (3, 4)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (3, 6)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (4, 3)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (4, 4)
INSERT [dbo].[ProductCategory] ([IdProduct], [IdCategory]) VALUES (4, 6)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CategoryTitle]    Script Date: 18.09.2022 0:56:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CategoryTitle] ON [dbo].[Category]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductTitle]    Script Date: 18.09.2022 0:56:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProductTitle] ON [dbo].[Product]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Category] ([IdCategory])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
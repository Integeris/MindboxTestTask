SELECT Product.Title, Category.Title
FROM Product
LEFT JOIN ProductCategory
ON Product.IdProduct = ProductCategory.IdProduct
LEFT JOIN Category
ON ProductCategory.IdCategory = Category.IdCategory;
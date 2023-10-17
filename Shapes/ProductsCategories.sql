SELECT p.Name, c.Name
FROM Products p
         left join ProductsCategories pc on p.Id = pc.ProductId
         left join Categories c on pc.CategoryId = c.Id;
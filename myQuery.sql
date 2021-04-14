use DBEShop;
select * from dbo.Products as p,dbo.ProductInCategories as pic,dbo.ProductTranslations as pt, dbo.Categories as c
where  c.Id = 1 and pt.LanguageId='en-US' and p.Id = pt.ProductId and p.Id = pic.ProductId and pic.CategoryId = c.Id 


select * from Products as p
inner join ProductTranslations as pt on p.Id = pt.ProductId
inner join ProductInCategories as pic on pic.ProductId = p.Id
inner join Categories as c on c.Id = pic.CategoryId
where pt.LanguageId = 'en-US' and c.Id = 1

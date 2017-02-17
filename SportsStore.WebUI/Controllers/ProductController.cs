using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        
        public ViewResult List(string category,int page = 1)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Model1>());

            //var context = new Model1();
            ////插入一行值
            //context.products.Add(new products {ProductID = 5, Name = "EF6MySQL" ,Price=25,Category="cat",Description = "catdes"});
            //context.SaveChanges();

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(p=>category == null ||p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null?
                    repository.Products.Count():
                    repository.Products.Where(e=>e.Category==category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}
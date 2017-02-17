using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI;
using System.Data.Entity;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.ConCrete;
using System.Configuration;

namespace SportsStore.WebUI.Intrastructure
{
    public class NijectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NijectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType); 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductID = 1, Name = "Football",Price = 25 ,Description = "这是足球1",Category = "第一组球类"},
                new Product {ProductID = 2,Name = "Surf board",Price = 179 ,Description = "这是球1",Category = "第一组球类"},
                new Product {ProductID = 3,Name = "Running shoes",Price = 95 ,Description = "这是跑鞋1",Category = "第一组球类"},
                new Product {ProductID = 4,Name = "Football1",Price = 25 ,Description = "这是足球1-2",Category = "第一组球类"},
                new Product {ProductID = 5,Name = "Surf board1",Price = 179 ,Description = "这是球1-2",Category = "第一组球类"},
                new Product {ProductID = 6,Name = "Running shoes1",Price = 95 ,Description = "这是跑鞋1-2",Category = "第一组球类" },

                new Product {ProductID = 7,Name = "Football",Price = 25 ,Description = "这是足球2",Category = "第二组球类"},
                new Product {ProductID = 8,Name = "Surf board",Price = 179 ,Description = "这是球2",Category = "第二组球类"},
                new Product {ProductID = 9,Name = "Running shoes",Price = 95 ,Description = "这是跑鞋2",Category = "第二组球类"},
                new Product {ProductID = 10,Name = "Football1",Price = 25 ,Description = "这是足球2-1",Category = "第二组球类"},
                new Product {ProductID = 11,Name = "Surf board1",Price = 179 ,Description = "这是球2-1",Category = "第二组球类"},
                new Product {ProductID = 12,Name = "Running shoes1",Price = 95 ,Description = "这是跑鞋2-1",Category = "第二组球类"}
            });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"]??"false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            //kernel.Bind<IProduct>().To<EFProduct>();
        }
    }
}
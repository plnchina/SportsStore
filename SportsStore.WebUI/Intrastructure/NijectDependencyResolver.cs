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
                new Product {Name = "Football",Price = 25 ,Description = "这是足球1",Category = "第一组球类"},
                new Product {Name = "Surf board",Price = 179 ,Description = "这是球1",Category = "第一组球类"},
                new Product {Name = "Running shoes",Price = 95 ,Description = "这是跑鞋1",Category = "第一组球类"},
                new Product {Name = "Football1",Price = 25 ,Description = "这是足球1-2",Category = "第一组球类"},
                new Product {Name = "Surf board1",Price = 179 ,Description = "这是球1-2",Category = "第一组球类"},
                new Product {Name = "Running shoes1",Price = 95 ,Description = "这是跑鞋1-2",Category = "第一组球类" },

                new Product {Name = "Football",Price = 25 ,Description = "这是足球2",Category = "第二组球类"},
                new Product {Name = "Surf board",Price = 179 ,Description = "这是球2",Category = "第二组球类"},
                new Product {Name = "Running shoes",Price = 95 ,Description = "这是跑鞋2",Category = "第二组球类"},
                new Product {Name = "Football1",Price = 25 ,Description = "这是足球2-1",Category = "第二组球类"},
                new Product {Name = "Surf board1",Price = 179 ,Description = "这是球2-1",Category = "第二组球类"},
                new Product {Name = "Running shoes1",Price = 95 ,Description = "这是跑鞋2-1",Category = "第二组球类"}
            });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            //kernel.Bind<IProduct>().To<EFProduct>();
        }
    }
}
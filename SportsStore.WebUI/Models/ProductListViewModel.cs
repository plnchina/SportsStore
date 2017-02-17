using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
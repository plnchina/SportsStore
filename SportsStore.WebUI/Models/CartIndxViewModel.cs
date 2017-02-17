using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class CartIndxViewModel
    {
        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}
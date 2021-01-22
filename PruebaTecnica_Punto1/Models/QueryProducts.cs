using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica_Punto1.Models
{
    public class QueryProducts
    {
        string productId;
        string productName;
        string category;
        string brand;

        public string ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Category { get => category; set => category = value; }
        public string Brand { get => brand; set => brand = value; }
    }
}
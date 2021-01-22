using Newtonsoft.Json.Linq;
using PruebaTecnica_Punto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica_Punto1.Utilities
{
    public class JsonHandler
    {
        public static List<QueryProducts> ConvertToList(JToken jObj,string productId, string productName,string categoryId)
        {
            List<QueryProducts> result = new List<QueryProducts>();
            var children = jObj.Children();

            if (string.IsNullOrEmpty(productId) && string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(categoryId))
            {
                var queryLondonCustomers = from cust in children
                                           select new QueryProducts
                                           {
                                               ProductId = cust["productId"].ToString(),
                                               ProductName = cust["productName"].ToString(),
                                               Category = cust["categoryId"].ToString(),
                                               Brand = cust["brand"].ToString()
                                           };
                result = queryLondonCustomers.ToList();
            }
            else
            {
                var queryLondonCustomers = from cust in children
                                           where 
                                           cust["productId"].ToString() == productId ||
                                           (!string.IsNullOrEmpty(productName) && cust["productName"].ToString().ToUpper().Contains(productName.ToUpper())) ||
                                           cust["categoryId"].ToString() == categoryId
                                           select new QueryProducts
                                           {
                                               ProductId = cust["productId"].ToString(),
                                               ProductName = cust["productName"].ToString(),
                                               Category = cust["categoryId"].ToString(),
                                               Brand = cust["brand"].ToString()
                                           };
                result = queryLondonCustomers.ToList();
            }
           
            return result;
        }
    }
}
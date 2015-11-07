using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWithMongo.Models
{
    public class Customer
    {
      
        public object _id { get; set; }
        public string FullName { get; set; }
    }
}
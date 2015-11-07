using MongoDB.Bson;
using MongoDB.Driver;
using MVCWithMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections;
using MongoDB.Driver.Builders;

namespace MVCWithMongo.Controllers
{
    

    public class HomeController : Controller
    {

        public IMongoCollection<Customer> collection; 
       
        public HomeController()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MongoDbx");
            collection = db.GetCollection<Customer>("Customers");
        }

        public async Task<ActionResult> Index()
        {
            

            await collection.InsertOneAsync(new Customer { _id = ObjectId.GenerateNewId().ToString(), FullName = "Anakin" });
            await collection.InsertOneAsync(new Customer { _id = ObjectId.GenerateNewId().ToString(), FullName = "Obiwan" });
            await collection.InsertOneAsync(new Customer { _id = ObjectId.GenerateNewId().ToString(), FullName = "Julius" });
            await collection.InsertOneAsync(new Customer { _id = ObjectId.GenerateNewId().ToString(), FullName = "Yoda" });
            await collection.InsertOneAsync(new Customer { _id = ObjectId.GenerateNewId().ToString(), FullName = "Qui-Gon" });            
            return View();
        }

        public async Task<ActionResult> List()
        {
          


         
            var result = await collection.Find(x => x.FullName != "").ToListAsync();

            ViewBag.customers = result.ToList();

            return View();
        }

        public string Delete()
        {

            
            collection.DeleteManyAsync(x => x.FullName == "Anakinxxx"); // works fine

            //collection.FindOneAndDeleteAsync(x => x.FullName == "Obiwan"); //deletes only one
            //collection.DeleteManyAsync(x => x.FullName == "Qui-Gon"); // works fine
            //collection.DeleteManyAsync(x => x.FullName == "Qui-Gon" || x.FullName=="Yoda");  // && wont delete


            return "xxx";
        }

        public async Task<string> Updater()
        {
           

            //updates 1 match
            //var result = await collection.FindOneAndUpdateAsync(Builders<Customer>.Filter.Eq("FullName", "Anakin"),
            //          Builders<Customer>.Update.Set("FullName", "Anakinxxx"));

            var result = await collection.UpdateManyAsync(Builders<Customer>.Filter.Eq("FullName", "Anakin"),
                      Builders<Customer>.Update.Set("FullName", "Anakinxxx"));


            return "xxx";
        }


    }
}
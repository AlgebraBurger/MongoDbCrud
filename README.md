# MongoDbCrud
Crud in MongoDb CSharpDriver


Download MongoDb 
https://www.mongodb.org/downloads#production

Download RoboMongo
http://robomongo.org/


Install MongoDb in your machine.
Install MongoDb Csharp Driver from Nuget.

One of the options to connection to MongoDb from C#

var client = new MongoClient();
var db = client.GetDatabase("MongoDbx");
collection = db.GetCollection<Customer>("Customers");



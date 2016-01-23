using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("school");
            var students = db.GetCollection<BsonDocument>("students");
            var list = await students.Find(new BsonDocument()).ToListAsync();
            Dictionary<int, BsonValue> dic = new Dictionary<int, BsonValue>();
            
            // Get the lowest homework score by student
            foreach (var doc in list)
            {
                BsonArray scores = doc["scores"].AsBsonArray;
                var hw = scores.Where(s => s["type"] == "homework").OrderBy(s => s["score"]).First();
                dic.Add(doc["_id"].ToInt32(), hw["score"]);
            }

            // Delete the lowest homework score of each student
            foreach (int key in dic.Keys)
            {
                var filter = Builders<BsonDocument>.Filter;
                var update = Builders<BsonDocument>.Update;
                await students.FindOneAndUpdateAsync(filter.Eq("_id", key), update.PullFilter("scores", filter.Eq("score", dic[key])));
            }
        }
    }
}

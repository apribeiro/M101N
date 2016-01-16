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

            var db = client.GetDatabase("students");
            var grades = db.GetCollection<BsonDocument>("grades");
            var list = await grades.Find(Builders<BsonDocument>.Filter.Eq("type", "homework"))
                .Sort(Builders<BsonDocument>.Sort.Ascending("student_id"))
                .Sort(Builders<BsonDocument>.Sort.Ascending("score"))
                .ToListAsync();

            Dictionary<int, BsonValue> dic = new Dictionary<int, BsonValue>();

            foreach (var doc in list)
            {
                if (!dic.ContainsKey(int.Parse(doc["student_id"].ToString())))
                {
                    dic.Add(int.Parse(doc["student_id"].ToString()), doc["score"]);
                    Console.WriteLine(doc["student_id"] + " " + doc["score"]);
                }
            }

            // Delete the lowest homework grade of each student
            foreach (int key in dic.Keys)
            {
                var builder = Builders<BsonDocument>.Filter;
                await grades.DeleteOneAsync(builder.And(builder.Eq("student_id", key), builder.Eq("score", dic[key])));
            }
        }
    }
}

using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using ConsoleApplication1;
using System.Collections.Generic;
using System.Linq;
using System;

namespace M101DotNet
{
    class InsertTest
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var images = db.GetCollection<Image>("images");

            List<Album> Albums = await db.GetCollection<Album>("albums").Find("{}").ToListAsync();
            List<Image> Images = await images.Find("{}").ToListAsync();
            int count = 0;
            List<Image> lstOrphanImages = new List<Image>();

            foreach (Image img in Images)
            {
                bool isFound = false;

                foreach (Album album in Albums)
                {
                    if (album.images.Any(x => x == img.Id))
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    count++;
                    lstOrphanImages.Add(img);
                    await images.DeleteOneAsync(x => x.Id == img.Id);
                }
            }
        }
    }
}
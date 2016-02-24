using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Image
    {
        public int Id { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public List<string> tags { get; set; }
    }
}

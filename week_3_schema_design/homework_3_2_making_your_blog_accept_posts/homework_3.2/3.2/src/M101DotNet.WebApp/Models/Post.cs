using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M101DotNet.WebApp.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
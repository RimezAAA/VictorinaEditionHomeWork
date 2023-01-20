using EditorPerson;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorinaEditionHomeWork
{
    public class Questions
    {
        [BsonId]
        public ObjectId _id;
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public Questions(string question, string answer)
        {
            this.id = MongoExamples.FindAll().Count + 1;
            this.question = question;
            this.answer = answer;
        }
    }
}

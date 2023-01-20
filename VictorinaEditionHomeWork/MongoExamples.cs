using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Windows;
using System.Windows.Controls;
using VictorinaEditionHomeWork;

namespace EditorPerson
{
    public class MongoExamples
    {
        public static void AddToDB(Questions question)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("VictorinaDB");
            var collection = database.GetCollection<Questions>("Victorina");
            collection.InsertOne(question);
        }
        public static List<Questions> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("VictorinaDB");
            var collection = database.GetCollection<Questions>("Victorina");
            var list = collection.Find(x => true).ToList();
            return list;
        }

        public static Questions Find(int id)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("VictorinaDB");
            var collection = database.GetCollection<Questions>("Victorina");
            var one = collection.Find(x => x.id == id).FirstOrDefault();
            return one;
        }

        //public static void ReplaceByName(string name, Character character)
        //{
        //    var client = new MongoClient();
        //    var database = client.GetDatabase("CharactersDataBaseArt");
        //    var collection = database.GetCollection<Character>("Characters");
        //    collection.ReplaceOne(x => x.name == name, character);
        //}

        //public static void Update(Character character)
        //{
        //    var client = new MongoClient();
        //    var database = client.GetDatabase("CharactersDataBaseArt");
        //    var collection = database.GetCollection<Character>("Characters");
        //    var update = Builders<Character>.Update.Set("Items", character.Items);
        //    collection.UpdateMany(x => x.name == character.name, update);
        //}
    }
}

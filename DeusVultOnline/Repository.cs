using System.Configuration;
using MongoDB.Driver;

namespace DeusVultOnline
{
    public class Repository
    {
        private static Repository _instance;

        public static Repository Instance => _instance??(_instance = new Repository());

        private IMongoDatabase _database;

        public IMongoCollection<T> GetCollection<T>()
        {
            EnsureDatabase();
            return _database.GetCollection<T>(typeof(T).Name);
        }

        private void EnsureDatabase()
        {
            if (_database == null)
            {
                var connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                var mongoConnectionString = new MongoUrlBuilder(connectionString);
                mongoConnectionString.AuthenticationSource = "admin";
                mongoConnectionString.Password = ConfigurationManager.AppSettings.Get("mongoPassword");
                mongoConnectionString.Username = ConfigurationManager.AppSettings.Get("mongoUser");
                mongoConnectionString.ReplicaSetName = "Cluster0-shard-0";
                mongoConnectionString.UseSsl = true;
                var client = new MongoClient(mongoConnectionString.ToMongoUrl());
                _database = client.GetDatabase("DeusVultOnline");
            }
        }
    }
}
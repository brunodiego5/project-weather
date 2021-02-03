using Application.Interfaces.Repositories;
using CrossCuting;
using Domain.Entities;
using Infrastructure.Data.Schema;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CityMongoRepository : ICityRepository
    {
        private readonly IMongoCollection<CitySchema> _cityMongoRepository;

        public CityMongoRepository(SystemSettings systemSettings)
        {
            IMongoClient client = new MongoClient(systemSettings.MongoDBSettings.ConnectionString);

            IMongoDatabase database = client.GetDatabase(systemSettings.MongoDBSettings.DatabaseName);

            _cityMongoRepository = database.GetCollection<CitySchema>("cities");
        }

        public async Task<City> GetById(int id)
        {
            var citySchema = await _cityMongoRepository.Find(new BsonDocument("id", id)).FirstOrDefaultAsync();

            var city = new City();

            city.Id = citySchema.Id;
            city.Name = citySchema.Name;
            city.Country = citySchema.Country;

            return new City();
        }

        public async Task<IEnumerable<City>> GetByName(string name)
        {
            //var filter = Builders<CitySchema>.Filter.

            var citySchema = await _cityMongoRepository.Find("{name: /^"+ name + "/i}").ToListAsync();

            List<City> cities = new List<City>();

            citySchema.ForEach(c => {
                var city = new City();
                city.Id = c.Id;
                city.Name = c.Name;
                city.Country = c.Country;
                cities.Add(city);
            });

            return cities;
        }
    }
}

using Application.Interfaces.Repositories;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CityMongoRepository(SystemSettings systemSettings, IMapper mapper)
        {
            IMongoClient client = new MongoClient(systemSettings.MongoDBSettings.ConnectionString);

            IMongoDatabase database = client.GetDatabase(systemSettings.MongoDBSettings.DatabaseName);

            _cityMongoRepository = database.GetCollection<CitySchema>("cities");

            _mapper = mapper;
        }

        public async Task<City> GetById(int id)
        {
            var citySchema = await _cityMongoRepository.Find(new BsonDocument("id", id)).FirstOrDefaultAsync();

            return _mapper.Map<CitySchema, City>(citySchema);
        }

        public async Task<IEnumerable<City>> GetByName(string name)
        {
            var citiesSchema = await _cityMongoRepository.Find("{name: /^"+ name + "/i}").ToListAsync();

            return _mapper.Map<IEnumerable<CitySchema>, IEnumerable<City>>(citiesSchema);
        }
    }
}

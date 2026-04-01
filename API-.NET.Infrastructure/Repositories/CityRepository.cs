using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
        public CityRepository(AppDbContext context)
        { 
            _context = context;
        }

        public async Task Create(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

    }
}

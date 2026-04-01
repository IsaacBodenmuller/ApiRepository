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
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;
        public StateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();
        }

    }
}

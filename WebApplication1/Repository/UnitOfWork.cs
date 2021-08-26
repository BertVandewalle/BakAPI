using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakAPI.Data;
using BakAPI.IRepository;

namespace BakAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        private IGenericRepository<Player> _players;
        private IGenericRepository<Game> _games;
        private IGenericRepository<Rank> _ranks;
        private IGenericRepository<Goal> _goals;
        private IGenericRepository<Duo> _duos;


        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<Player> Players => _players ??= new GenericRepository<Player>(_context);
        public IGenericRepository<Game> Games => _games ??= new GenericRepository<Game>(_context);
        public IGenericRepository<Rank> Ranks => _ranks ??= new GenericRepository<Rank>(_context);
        public IGenericRepository<Goal> Goals => _goals ??= new GenericRepository<Goal>(_context);
        public IGenericRepository<Duo> Duos => _duos ??= new GenericRepository<Duo>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

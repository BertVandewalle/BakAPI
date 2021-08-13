using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakAPI.Data;

namespace BakAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        IGenericRepository<Player> Players { get; }
        IGenericRepository<Game> Games { get; }
        IGenericRepository<Rank> Ranks { get; }
        IGenericRepository<Goal> Goals { get; }


        Task Save();
    }
}

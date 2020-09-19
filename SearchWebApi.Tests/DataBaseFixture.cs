using Microsoft.EntityFrameworkCore;
using SearchWebApi.DB;
using System;

namespace TestProject.Tests
{
    public class DataBaseFixture : IDisposable
    {
        public readonly SearchApiDbContext SearchApiDbContext;
    
        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<SearchApiDbContext>()
           .UseInMemoryDatabase("TestDatabase", new Microsoft.EntityFrameworkCore.Storage.InMemoryDatabaseRoot())
           .Options;
            SearchApiDbContext = new SearchApiDbContext(options);           
        }

        public void Dispose()
        {
            SearchApiDbContext.Database.EnsureDeleted();
            SearchApiDbContext.Dispose();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PhilipDaubmeier.DigitalstromHost.Database;
using PhilipDaubmeier.TokenStore.Database;

namespace PhilipDaubmeier.DigitalstromTimeSeriesApi.Database
{
    public class DigitalstromTimeSeriesDbContext : DbContext, ITokenStoreDbContext, IDigitalstromDbContext
    {
        #region ITokenStoreDbContext
        public DbSet<AuthData> AuthDataSet { get; set; }
        #endregion
        
        #region IDigitalstromDbContext
        public DbSet<DigitalstromZone> DsZones { get; set; }

        public DbSet<DigitalstromZoneSensorData> DsSensorDataSet { get; set; }

        public DbSet<DigitalstromSceneEventData> DsSceneEventDataSet { get; set; }

        public DbSet<DigitalstromEnergyHighresData> DsEnergyHighresDataSet { get; set; }
        #endregion
        
        public DigitalstromTimeSeriesDbContext(DbContextOptions<DigitalstromTimeSeriesDbContext> options)
            : base(options)
        { }
    }
}
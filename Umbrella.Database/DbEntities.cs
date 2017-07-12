using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Model;

namespace Umbrella.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DbEntities : DbContext
    {
        public DbEntities() : base("umbrella")
        {
        }

        public DbSet<UmbrellaDevice> UmbrellaDevices { get; set; }
    }
}

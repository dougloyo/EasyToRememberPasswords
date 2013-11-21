using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EasyToRememberPasswords.Models.Mapping;

namespace EasyToRememberPasswords.Models
{
    public partial class PasswordGeneratorContext : DbContext
    {
        static PasswordGeneratorContext()
        {
            Database.SetInitializer<PasswordGeneratorContext>(null);
        }

        public PasswordGeneratorContext()
            : base("Name=PasswordGeneratorContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<WordsList> WordsLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new WordsListMap());
        }
    }
}

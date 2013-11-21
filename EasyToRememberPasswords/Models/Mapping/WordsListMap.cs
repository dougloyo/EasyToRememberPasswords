using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyToRememberPasswords.Models.Mapping
{
    public class WordsListMap : EntityTypeConfiguration<WordsList>
    {
        public WordsListMap()
        {
            // Primary Key
            this.HasKey(t => t.Word);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Word)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("WordsList");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Word).HasColumnName("Word");
            this.Property(t => t.LetterCount).HasColumnName("LetterCount");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rest_with_asp_net_10.Model
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title", TypeName = "varchar(MAX)")]
        [MaxLength]
        public string Title { get; set; }

        [Column("author", TypeName = "varchar(MAX)")]
        [MaxLength]
        public string Author { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public double Price { get; set; }

        [Required]
        [Column("launch_date", TypeName = "datetime2(6)")]
        public DateTime LauchDate { get; set; }
    }
}

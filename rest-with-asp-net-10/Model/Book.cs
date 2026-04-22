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

        [Required]
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; }

        [Required]
        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date")]
        public DateTime LauchDate { get; set; }
    }
}

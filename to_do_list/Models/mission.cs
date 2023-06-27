using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace to_do_list.Models
{
    public class Mission
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "deadline is required")]
        [Column(TypeName = "datetime")]
        public DateTime DeadLine { get; set; }

        [Column(TypeName = "bit")]
        public bool IsCompleted { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }

    }
}

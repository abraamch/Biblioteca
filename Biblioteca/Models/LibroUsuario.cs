using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class LibroUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string MailUsuario { get; set; }

        public int PaginasLibro { get; set; }
        public string NombreLibro { get; set; }
        public string   TapaLibro { get; set; }

        public string AutorLibro { get; set; }
        [EnumDataType(typeof(GeneroLiterario))]
        public GeneroLiterario GeneroLibro { get; set; }

        public DateTime VencimientoLibro { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca.Areas.Identity.Data;

namespace Biblioteca.Models
{
    public class Libro
    {
        

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "cant paginas del libro")]
        public int CantPaginas { get; set; }
        [Required]
        [Display(Name = "nombre del libro")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "foto del libro")]
        public string Tapa { get; set; }
        [Required]
        [Display(Name = "autor del libro")] public string Autor { get; set; }

        [EnumDataType(typeof(GeneroLiterario))]
        public GeneroLiterario Genero { get; set; }

        [Display(Name = "Fecha vencimiento")]
        public DateTime VencimientoEntrega { get; set; }

        
        public override string ToString()
        {
            return "Nombre "+ Nombre + "Cant Paginas" + CantPaginas;
        }
    }

  
}

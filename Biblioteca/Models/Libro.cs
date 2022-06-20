using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CantPaginas { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string GeneroLiterario { get; set; }

        [Display(Name = "Fecha vencimiento")]
        public DateTime VencimientoEntrega { get; set; }
  
    }
}

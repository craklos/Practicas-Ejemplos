using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppEjemplo.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La placa es obligatoria")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El modelo es obligatoria")]
        public string Modelo { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El número de serie es obligatoria")]
        [Display(Name = "Número de serie")]
        public string NoSerie { get; set; }
    }
}

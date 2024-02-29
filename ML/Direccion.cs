using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "El campo Calle no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Calle no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //[RegularExpression("[a-zA-Z0-9\\s]+", ErrorMessage = "sin espacion y solo letras")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "El campo Numero Interior no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Numero Interior no puede ser menor a 8 ni mayor a 50", MinimumLength = 4)]
        //[RegularExpression("^\\+?[1-9][0-9]$", ErrorMessage = "sin espacion y solo letras")]
        public string NumeroInterior { get; set; }
        [Required(ErrorMessage = "El campo Numero Exterior no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Numero Exterior no puede ser menor a 8 ni mayor a 50", MinimumLength = 4)]
        //[RegularExpression("^\\+?[1-9][0-9]$", ErrorMessage = "sin espacion y solo letras")]
        public string NumeroExterior { get; set; }

        public ML.Colonia Colonia { get; set; }
        public ML.Usuario Usuario { get; set; }

        public List<object> Direcciones { get; set; }
    }
}

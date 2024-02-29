using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo Username no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Username no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //[RegularExpression("\\S+[a-zA-Z]+", ErrorMessage = "sin espacion y solo letras")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Nombre no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //RegularExpression("\\S+[a-zA-Z]+", ErrorMessage = "sin espacion y solo letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo ApellidoPaterno no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Apellido Paterno no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //[RegularExpression("\\S+[a-zA-Z]+", ErrorMessage = "sin espacion y solo letras")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo ApellidoMaterno no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Apellido Materno no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //[RegularExpression("\\S+[a-zA-Z]+", ErrorMessage = "sin espacion y solo letras")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo Email no puede estar vacio")]
        //[StringLength(255, ErrorMessage = "El ApellidoMaterno no puede ser mayor a 255")]
        //[EmailAddress(ErrorMessage = "El Email que ingreso no es valido")]
        //[RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "El Email que ingreso no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Password no puede estar vacio")]
        [StringLength(50, ErrorMessage = "El Password no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$", ErrorMessage = "At least one uppercase \r\n At least one lowercase \r\n At least one digit \r\n At least one special character,")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Password no puede estar vacio")]
        //[StringLength(50, ErrorMessage = "El Password no puede ser menor a 8 ni mayor a 50", MinimumLength = 8)]
        //[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$", ErrorMessage = "At least one uppercase \r\n At least one lowercase \r\n At least one digit \r\n At least one special character,")]
        //[DataType(DataType.Password)]
        public string ConfirmarPwd { get; set; }

        [Required(ErrorMessage = "El campo Sexo no puede estar vacio")]
        [RegularExpression("M{1}|F{1}", ErrorMessage = "Solo una letra M o F en mayusculas")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacio")]
        //[StringLength(10, ErrorMessage = "El Telefono no puede ser menor a 10", MinimumLength = 10)]
        //[RegularExpression("^\\+?[1-9][0-9]{9}$", ErrorMessage = "sin espacion ni letras")]
        //[DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Celular no puede estar vacio")]
        //[StringLength(10, ErrorMessage = "El Celular no puede ser menor a 8 ni mayor a 50", MinimumLength = 10)]
        //[RegularExpression("^\\+?[1-9][0-9]{9}$", ErrorMessage = "sin espacion ni letras")]
        //[DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        public bool Estatus { get; set; }

        [Required(ErrorMessage = "El campo FechaNacimiento no puede estar vacio")]
        //[DataType(DataType.Date)]
        //[RegularExpression("[0-9]{1,2}\\-[0-9]{1,2}\\-[0-9]{4}$", ErrorMessage = "sin espacion y solo letras")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo CURP no puede estar vacio")]
        //[StringLength(20, ErrorMessage = "El CURP no puede ser menor a 8 ni mayor a 50", MinimumLength = 20)]
        //[RegularExpression("[A-Z0-9]+", ErrorMessage = "sin espacion y solo letras Mayusculas")]
        public string CURP { get; set; }
        public string Image { get; set; }
        public string NombreCompleto { get; set; }

        public ML.Role Role { get; set; }

        public ML.Direccion Direccion { get; set; }

        public List<object> Usuarios { get; set; }
    }
}

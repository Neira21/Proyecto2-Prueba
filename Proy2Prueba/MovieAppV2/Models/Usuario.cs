using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAppV2.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        [Required(ErrorMessage="Por favor, ingrese el número de documento")]
        [Display( Name = "Número de documento")]
        [StringLength(8, MinimumLength=8, ErrorMessage="Debe ingresar un número minimo de 8 dígitos")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "Ingresa un numero valido")]
        public string Dni { get; set; }
        [Required(ErrorMessage="Por favor, Ingrese el nombre")]
        [StringLength(50, MinimumLength=2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage="Por favor, ingrese el apellido")]
        [StringLength(50, MinimumLength=2)]
        public string Apellido { get; set; }
        [Required(ErrorMessage="Seleccione uno")]
        public char Sexo { get; set; }
        [Required(ErrorMessage="Ingrese un email")]
        public string Email { get; set; }
        [Required(ErrorMessage="Ingrese un celular de contacto")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([9]{1}[0-9]{8})$", ErrorMessage = "Ingresa un numero celular valido")]
        public string Celular { get; set; }
        [Required(ErrorMessage="Seleccione uno")]
        public string GenFav { get; set; }
        [Required(ErrorMessage="Debe ingresar una fecha")]
        [DataType(DataType.Date)]
        public DateTime? FecNac { get; set; }
        public List<Pelicula> Peliculas { get; set; }
        public List<Noticia> Noticias { get; set; }
        public List<Reseña> Reseñas {get;set;}
    }
}
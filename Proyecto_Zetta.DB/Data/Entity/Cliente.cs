using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    [Index(nameof(Codigo), Name = "Cliente_Cod", IsUnique = true)]
    public class Cliente : EntityBase
    {
        [Required(ErrorMessage = "El código del Cliente es obligatorio.")]
        [Range(0, 9999999999, ErrorMessage = "Máximo número de carácteres {1}.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria.")]
        [MaxLength(40, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio.")]
        public string Telefono { get; set; }

        [MaxLength(30, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Mail { get; set; }

        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Descripcion { get; set; }
    }
}

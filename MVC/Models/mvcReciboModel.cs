using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcReciboModel
    {
        public int ReciboID { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Proveedor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<double> Monto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Moneda { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<System.DateTime> Fecha { get; set; }

        public string Comentario { get; set; }
    }
    
}
using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceBlazorCrud.Models
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}

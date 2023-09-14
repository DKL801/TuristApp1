using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TuristApp
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}

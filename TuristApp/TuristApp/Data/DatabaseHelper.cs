using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TuristApp.Data
{
    public class DatabaseHelper
    {
        SQLiteConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Usuario>();
        }

        public bool LoginUsuario(string nombreUsuario, string contraseña)
        {
            var user = database.Table<Usuario>().FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
            return user != null;
        }
        public bool UsuarioExiste(string nombreUsuario)
        {
            var existingUser = database.Table<Usuario>().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            return existingUser != null;
        }
        public void InsertarUsuario(Usuario usuario)
        {
            database.Insert(usuario);
        }

    }
}

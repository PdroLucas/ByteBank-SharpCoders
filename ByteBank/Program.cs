using ByteBank.Entities;
using System;
using System.Drawing;

namespace ByteBank {
    class Program {
        public static void Main(string[] args) {
            Usuario.dataBase.Add(new Usuario("admin", "admin", "adm"));
            Login.FazerLogin();
        }
    }
}
namespace ByteBank.Entities {
    class Login {
        // ATRIBUTO
        public static string loginAtivo = "";

        // LOGIN
        public static void FazerLogin() {
            Utils.Titulo("login");

            Console.Write("Login: ");
            string usuario = Console.ReadLine();
            if (usuario == "") {
                Utils.Titulo("login");
                Utils.msgResposta("erro", "LOGIN NÃO INFORMADO");
                Utils.TentarNovamente("login");
            }
            bool existeUsuario = Usuario.dataBase.Any(x => x.Nome == usuario);
            if (existeUsuario == false) {
                Utils.Titulo("login");
                Utils.msgResposta("erro", "LOGIN INEXISTENTE");
                Utils.TentarNovamente("login");
            }

            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            if (senha == "") {
                Utils.Titulo("login");
                Utils.msgResposta("erro", "SENHA NÃO INFORMADA");
                Utils.TentarNovamente("login");
            }
            bool existe = Usuario.dataBase.Any(x => x.Senha == senha);
            if (existe == false) {
                Utils.Titulo("login");
                Utils.msgResposta("erro", "SENHA INCORRETA");
                Utils.TentarNovamente("login");
            }
            int index = Usuario.LocalizarIndex("nome", usuario);
            if (senha != Usuario.dataBase[index].Senha) {
                Utils.Titulo("login");
                Utils.msgResposta("erro", "SENHA INCORRETA");
                Utils.TentarNovamente("login");
            }

            if (Usuario.dataBase[index].Tipo == "adm") {
                Utils.Menu("adm");
            } else {
                string login = Usuario.dataBase[index].Nome;
                loginAtivo = login;
                Utils.Menu("cliente");
            }
        }

        // LOGOFF
        public static void FazerLogoff() {
            loginAtivo = "";
            FazerLogin();
        }
    }
}
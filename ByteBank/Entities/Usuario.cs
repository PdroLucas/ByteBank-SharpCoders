namespace ByteBank.Entities {
    class Usuario {
        // AUTO PROPRIEDADES
        public string Nome  { get; private set; }
        public string Senha { get; private set; }
        public string Tipo  { get; private set; }        

        // CONSTRUTOR
        public Usuario(string usuario, string senha, string tipo) {            
            Nome  = usuario;            
            Senha = senha;
            Tipo  = tipo;
        }

        // BANCO DE DADOS
        public static List<Usuario> dataBase = new List<Usuario>();

        // LOCALIZA INDEX DO USUARIO
        public static int LocalizarIndex(string campo, string valor) {
            int index = -1;

            if (campo == "nome") {
                index = dataBase.FindIndex(x => x.Nome == valor);
            }

            return index;
        }

        // ALTERAR SENHA
        public static void AlterarSenha(int index, string novaSenha) {
            dataBase[index].Senha = novaSenha;
        }
    }
}
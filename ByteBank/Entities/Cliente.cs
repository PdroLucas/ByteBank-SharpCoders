namespace ByteBank.Entities {
    class Cliente {
        // AUTO PROPRIEDADES
        public string Conta   { get; private set; }
        public string Titular { get; private set; }
        public string CPF     { get; private set; }
        public double Saldo   { get; private set; }
        public string Senha   { get; private set; }

        // CONSTRUTOR
        public Cliente(string conta, string titular, string cpf, double saldo, string senha) {
            Conta   = conta;
            Titular = titular;
            CPF     = cpf;
            Saldo   = saldo;
            Senha   = senha;
        }

        // BANCO DE DADOS
        public static List<Cliente> dataBase = new List<Cliente>();

        // LOCALIZA INDEX DE CLIENTE
        public static int LocalizarIndex(string campo, string valor) {
            int index = -1;

            if (campo == "cpf") {
                index = dataBase.FindIndex(x => x.CPF == valor);
            }

            if (campo == "conta") {
                index = dataBase.FindIndex(x => x.Conta == valor);
            }

            return index;
        }

        // LOCALIZA NOME DO CLIENTE
        public static string LocalizarNomeCliente(string conta) {
            string resultado = "";

            for (int i = 0; i < dataBase.Count; i++) {
                if (dataBase[i].Conta == conta) {
                    resultado = dataBase[i].Titular;
                    break;
                }
            }

            return resultado;
        }

        // MENU INFORMAÇÕES CLIENTE
        public static void InformacoesCliente() {
            Console.Clear();
            Utils.Titulo("informações do cliente");
            Console.WriteLine("[1] Dados Cadastrais + Saldo");
            Console.WriteLine("[2] Dados Cadastrais + Saldo + Movimentações");
            Console.WriteLine("[0] Voltar para o Menu Principal");
            Console.WriteLine();
            Console.Write("Escolha a opção desejada: ");
            try {
                int index = -1;
                char opcao = char.Parse(Console.ReadLine());
                switch (opcao) {
                    case '0':
                        Utils.Menu("adm");
                        break;
                    case '1':
                        Console.Write("Informe o número da conta: ");
                        string conta = Console.ReadLine();
                        index = dataBase.FindIndex(x => x.Conta == conta);
                        Console.Clear();
                        Utils.Titulo("informações do cliente");
                        GeraInformacoesCliente("resumido", "com saldo", index);
                        Utils.VoltarMenu("adm");
                        break;
                    case '2':
                        Console.Write("Informe o número da conta: ");
                        conta = Console.ReadLine();
                        index = dataBase.FindIndex(x => x.Conta == conta);
                        Console.Clear();
                        Utils.Titulo("informações do cliente");
                        GeraInformacoesCliente("completo", "com saldo", index);
                        Console.WriteLine();
                        Utils.VoltarMenu("adm");
                        break;
                    default:
                        Utils.Menu("adm");
                        break;
                }
            }
            catch {
                Utils.Menu("adm");
            }
        }

        // GERA INFORMAÇÕES DO CLIENTE
        public static void GeraInformacoesCliente(string tipo, string saldo, int index) {
            if (tipo == "resumido") {
                if (saldo == "com saldo") {
                    Console.WriteLine($"Conta:   {dataBase[index].Conta}");
                    Console.WriteLine($"Titular: {dataBase[index].Titular}");
                    Console.WriteLine($"CPF:     {dataBase[index].CPF}");
                    Console.WriteLine($"Saldo:   R$ {dataBase[index].Saldo.ToString("F2")}");
                    Console.WriteLine();
                }
                else {
                    Console.WriteLine($"Conta:   {dataBase[index].Conta}");
                    Console.WriteLine($"Titular: {dataBase[index].Titular}");
                    Console.WriteLine($"CPF:     {dataBase[index].CPF}");
                    Console.WriteLine();
                }
            }

            if (tipo == "completo") {
                if (saldo == "com saldo") {
                    Console.WriteLine($"Conta:   {dataBase[index].Conta}");
                    Console.WriteLine($"Titular: {dataBase[index].Titular}");
                    Console.WriteLine($"CPF:     {dataBase[index].CPF}");
                    Console.WriteLine($"Saldo:   R$ {dataBase[index].Saldo.ToString("F2")}");
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" CONTA ORIGEM | CONTA DESTINO | DATA                | VALOR MOVIMENTADO | OPERAÇÃO      ");
                    Console.ResetColor();
                    string conta         = dataBase[index].Conta;
                    int qtdMovimentacoes = Movimentacao.dataBase.Count();
                    int i                = 0;
                    while (i < qtdMovimentacoes) {
                        if ((Movimentacao.dataBase[i].ContaOrigem == conta) || (Movimentacao.dataBase[i].ContaDestino == conta)) {
                            Console.Write($" {Movimentacao.dataBase[i].ContaOrigem}         |");
                            Console.Write($" {Movimentacao.dataBase[i].ContaDestino}          |");
                            Console.Write($" {Movimentacao.dataBase[i].Data} |");
                            Console.Write($" R$ {Movimentacao.dataBase[i].Valor.ToString("F2").PadRight(14)} |");
                            Console.Write($" {Movimentacao.dataBase[i].Operacao} ");
                            Console.WriteLine();
                        }
                        i++;
                    }
                }
                else {
                    GeraInformacoesCliente("resumido", "sem saldo", index);
                    Console.WriteLine($"Conta:   {dataBase[index].Conta}");
                    Console.WriteLine($"Titular: {dataBase[index].Titular}");
                    Console.WriteLine($"CPF:     {dataBase[index].CPF}");
                    Console.WriteLine();
                    Console.WriteLine("CONTA ORIGEM | CONTA DESTINO | DATA | VALOR MOVIMENTADO | OPERAÇÃO");                    
                }
            }

            if (tipo == "menu principal") {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($" Conta:   {dataBase[index].Conta.PadRight(43)}");
                Console.WriteLine($" Titular: {dataBase[index].Titular.PadRight(43)}");
                Console.WriteLine($" CPF:     {dataBase[index].CPF.PadRight(43)}");
                Console.WriteLine($" Saldo:   R$ {dataBase[index].Saldo.ToString("F2").PadRight(40)}");
                Console.ResetColor();
            }
        }

        // CADASTRAR
        public static void Cadastrar() {
            Utils.Titulo("cadastro de cliente");
            Utils.Atencao("cadastro de cliente");

            Console.Write("Nome do titular: ");
            string titular = Console.ReadLine();
            if ((titular.Trim() == "") || (titular.Trim().Length < 8) || (Utils.temNumero(titular))) {
                Utils.Titulo("cadastro de cliente");
                Utils.msgResposta("erro", "NOME DO TITULAR NÃO INFORMADO OU INVÁLIDO");
                Utils.TentarNovamente("cadastro de cliente");
            }

            Console.Write("CPF (11 dígitos): ");
            string cpf = Console.ReadLine();
            if ((cpf.Trim() == "") || (cpf.Length < 11) || (cpf.Length > 11) || (!cpf.All(char.IsDigit)) || (!Utils.ValidaCPF(cpf))) {
                Utils.Titulo("cadastro de cliente");
                Utils.msgResposta("erro", "CPF NÃO INFORMADO OU INVÁLIDO");
                Utils.TentarNovamente("cadastro de cliente");
            }

            Console.Write("Senha (4 dígitos): ");
            string senha = Console.ReadLine();
            if ((senha.Trim() == "") || (senha.Length < 4) || (senha.Length > 4) || (!senha.All(char.IsDigit))) {
                Utils.Titulo("cadastro de cliente");
                Utils.msgResposta("erro", "SENHA NÃO INFORMADA OU INVÁLIDA");
                Utils.TentarNovamente("cadastro de cliente");
            }

            string conta = Utils.GeraNumeroConta();
            dataBase.Add(new Cliente(conta, titular.ToUpper(), cpf, 0, senha));
            Usuario.dataBase.Add(new Usuario(conta, senha, "user"));
            Utils.Titulo("cadastro de cliente");
            Utils.Atencao("cadastro finalizado");
            Console.WriteLine($"Conta/Login: {conta}");
            Console.WriteLine($"Titular:     {titular.ToUpper()}");
            Console.WriteLine($"CPF:         {cpf}");
            Console.WriteLine($"Saldo:       R$ 0,00");
            Console.WriteLine();
            Utils.msgResposta("sucesso", "CADASTRO REALIZADO COM SUCESSO");
            Utils.VoltarMenu("adm");
        }

        // APAGAR
        public static void Apagar() {
            Utils.Titulo("apagar cliente");
            Utils.Atencao("apagar cliente");

            Console.Write("CPF do titular (11 dígitos): ");
            string cpf = Console.ReadLine();
            int index = LocalizarIndex("cpf", cpf);
            if ((cpf.Trim() == "") || (cpf.Length < 11) || (cpf.Length > 11) || (!cpf.All(char.IsDigit)) || (index == -1)) {
                Utils.Titulo("apagar cliente");
                Utils.msgResposta("erro", "CPF NÃO INFORMADO, INVÁLIDO OU INEXISTENTE");
                Utils.TentarNovamente("apagar cliente");
            }
            if (dataBase[index].Saldo > 0) {
                Utils.Titulo("apagar cliente");
                Utils.Atencao("apagar cliente");
                GeraInformacoesCliente("resumido", "com saldo", index);
                Utils.msgResposta("erro", "NÃO É POSSÍVEL APAGAR O CADASTRO, POIS A CONTA POSSUI SALDO MAIOR QUE 0 (ZERO)");
                Utils.TentarNovamente("apagar cliente");
            }

            Utils.Titulo("apagar cliente");
            Utils.Atencao("confirmar apagar cliente");
            GeraInformacoesCliente("resumido", "com saldo", index);
            Console.Write("Tem certeza que deseja apagar (S/N)? ");
            char resposta = char.Parse(Console.ReadLine());
            if ((resposta == 'S') || (resposta == 's')) {
                Utils.Titulo("apagar cliente");
                dataBase.RemoveAt(index);
                Utils.msgResposta("sucesso", "CADASTRO APAGADO COM SUCESSO");
                Utils.VoltarMenu("adm");
            } else {
                Utils.VoltarMenu("adm");
            }
        }

        // SACAR
        public static void Sacar(int index, double valorSaque) {
            dataBase[index].Saldo -= valorSaque;
        }

        // DEPOSITAR
        public static void Depositar(int index, double valorDeposito) {
            dataBase[index].Saldo += valorDeposito;
        }

        // TRANSFERIR
        public static void Transferir(int indexContaOrigem, int indexContaDestino, double valorTransferencia) {
            dataBase[indexContaOrigem].Saldo -= valorTransferencia;
            dataBase[indexContaDestino].Saldo += valorTransferencia;
        }

        // ALTERAR SENHA
        public static void AlterarSenha() {
            Utils.Titulo("alterar senha");

            Console.Write("Informe a senha atual: ");
            string senhaAtual = Console.ReadLine();
            if ((senhaAtual.Trim() == "") || (senhaAtual.Length < 4) || (senhaAtual.Length > 4) || (!senhaAtual.All(char.IsDigit))) {
                Utils.Titulo("alterar senha");
                Utils.msgResposta("erro", "SENHA NÃO INFORMADA OU INVÁLIDA");
                Utils.TentarNovamente("alterar senha");
            }

            Console.Write("Informe a nova senha: ");
            string senhaNova = Console.ReadLine();
            if ((senhaAtual.Trim() == "") || (senhaAtual.Length < 4) || (senhaAtual.Length > 4) || (!senhaAtual.All(char.IsDigit))) {
                Utils.Titulo("alterar senha");
                Utils.msgResposta("erro", "SENHA NÃO INFORMADA OU INVÁLIDA");
                Utils.TentarNovamente("alterar senha");
            }

            Utils.Titulo("alterar senha");
            int index = Usuario.LocalizarIndex("nome", Login.loginAtivo);
            Usuario.AlterarSenha(index, senhaNova);
            Utils.msgResposta("sucesso", "SENHA ALTERADA COM SUCESSO");
            Utils.VoltarMenu("cliente");
        }
    }
}
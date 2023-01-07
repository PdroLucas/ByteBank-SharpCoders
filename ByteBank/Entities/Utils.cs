using System.ComponentModel.Design;

namespace ByteBank.Entities {
    class Utils {
        public static void Menu(string tipo) {
            // MENU ADMINISTRADOR
            if (tipo == "adm") {
                Console.Clear();
                Titulo("menu");

                Console.WriteLine("[1] Cadastrar Cliente");
                Console.WriteLine("[2] Apagar Cliente");
                Console.WriteLine("[3] Informações do Cliente");
                Console.WriteLine("[4] Informações do Banco");
                Console.WriteLine("[5] Fazer Logoff");
                Console.WriteLine("[0] Encerrar Sistema");
                Console.WriteLine();
                Console.Write("Escolha a opção desejada: ");                

                try {
                    char opcao = char.Parse(Console.ReadLine());
                    switch (opcao) {
                        case '0':
                            EncerrarSistema();
                            break;
                        case '1':
                            Cliente.Cadastrar();
                            break;
                        case '2':
                            Cliente.Apagar();
                            break;
                        case '3':
                            Cliente.InformacoesCliente();
                            break;
                        case '4':
                            Banco.InformacoesBanco();
                            break;
                        case '5':
                            Login.FazerLogoff();
                            break;
                        default:
                            Menu("adm");
                            break;
                    }
                } catch {
                    Menu("adm");
                }
            }

            // MENU CLIENTE
            if (tipo == "cliente") {
                Console.Clear();
                Titulo("menu");
                int index = Cliente.LocalizarIndex("conta", Login.loginAtivo);
                Cliente.GeraInformacoesCliente("menu principal", "", index);
                Console.WriteLine();
                Console.WriteLine("[1] Sacar");
                Console.WriteLine("[2] Depositar");
                Console.WriteLine("[3] Transferir");
                Console.WriteLine("[4] Histórico de Movimentações");
                Console.WriteLine("[5] Alterar senha");
                Console.WriteLine("[6] Fazer Logoff");
                Console.WriteLine("[0] Encerrar Sistema");
                Console.WriteLine();
                Console.Write("Escolha a opção desejada: ");

                try {
                    char opcao = char.Parse(Console.ReadLine());
                    switch (opcao) {
                        case '0':
                            EncerrarSistema();
                            break;
                        case '1':
                            Movimentacao.Sacar();
                            break;
                        case '2':
                            Movimentacao.Depositar();
                            break;
                        case '3':
                            Movimentacao.Transferir();
                            break;
                        case '4':
                            Utils.Titulo("movimentações");
                            Cliente.GeraInformacoesCliente("completo", "com saldo", Cliente.LocalizarIndex("conta", Login.loginAtivo));
                            Console.WriteLine();
                            VoltarMenu("cliente");
                            break;
                        case '5':
                            Cliente.AlterarSenha();
                            break;
                        case '6':
                            Login.FazerLogoff();
                            break;
                        default:
                            Menu("cliente");
                            break;
                    }
                }
                catch {
                    Menu("cliente");
                }
            }
        }

        // TÍTULO
        public static void Titulo(string titulo) {
            if (titulo == "menu") {
                Console.Clear();
                Console.WriteLine("\r\n█▀▄▀█ █▀▀ █▄░█ █░█   █▀█ █▀█ █ █▄░█ █▀▀ █ █▀█ ▄▀█ █░░\r\n█░▀░█ ██▄ █░▀█ █▄█   █▀▀ █▀▄ █ █░▀█ █▄▄ █ █▀▀ █▀█ █▄▄");
                Console.WriteLine();
            }

            if (titulo == "login") {
                Console.Clear();
                Console.WriteLine("\r\n█▄▄ █▄█ ▀█▀ █▀▀   █▄▄ ▄▀█ █▄░█ █▄▀\r\n█▄█ ░█░ ░█░ ██▄   █▄█ █▀█ █░▀█ █░█");
                Console.WriteLine();
            }

            if (titulo == "cadastro de cliente") {
                Console.Clear();
                Console.WriteLine("\r\n█▀▀ ▄▀█ █▀▄ ▄▀█ █▀ ▀█▀ █▀█ █▀█   █▀▄ █▀▀   █▀▀ █░░ █ █▀▀ █▄░█ ▀█▀ █▀▀\r\n█▄▄ █▀█ █▄▀ █▀█ ▄█ ░█░ █▀▄ █▄█   █▄▀ ██▄   █▄▄ █▄▄ █ ██▄ █░▀█ ░█░ ██▄");
                Console.WriteLine();
            }

            if (titulo == "apagar cliente") {
                Console.Clear();
                Console.WriteLine("\r\n▄▀█ █▀█ ▄▀█ █▀▀ ▄▀█ █▀█   █▀▀ █░░ █ █▀▀ █▄░█ ▀█▀ █▀▀\r\n█▀█ █▀▀ █▀█ █▄█ █▀█ █▀▄   █▄▄ █▄▄ █ ██▄ █░▀█ ░█░ ██▄");
                Console.WriteLine();
            }

            if (titulo == "informações do cliente") {
                Console.Clear();
                Console.WriteLine("\r\n█ █▄░█ █▀▀ █▀█ █▀█ █▀▄▀█ ▄▀█ █▀▀ █▀█ █▀▀ █▀   █▀▄ █▀█   █▀▀ █░░ █ █▀▀ █▄░█ ▀█▀ █▀▀\r\n█ █░▀█ █▀░ █▄█ █▀▄ █░▀░█ █▀█ █▄▄ █▄█ ██▄ ▄█   █▄▀ █▄█   █▄▄ █▄▄ █ ██▄ █░▀█ ░█░ ██▄");
                Console.WriteLine();
            }

            if (titulo == "informações do banco") {
                Console.Clear();
                Console.WriteLine("\r\n█▄▄ █▄█ ▀█▀ █▀▀   █▄▄ ▄▀█ █▄░█ █▄▀\r\n█▄█ ░█░ ░█░ ██▄   █▄█ █▀█ █░▀█ █░█");
                Console.WriteLine();
            }

            if (titulo == "sacar") {
                Console.Clear();
                Console.WriteLine("\r\n█▀ ▄▀█ █▀▀ ▄▀█ █▀█\r\n▄█ █▀█ █▄▄ █▀█ █▀▄");
                Console.WriteLine();
            }

            if (titulo == "depositar") {
                Console.Clear();
                Console.WriteLine("\r\n█▀▄ █▀▀ █▀█ █▀█ █▀ █ ▀█▀ ▄▀█ █▀█\r\n█▄▀ ██▄ █▀▀ █▄█ ▄█ █ ░█░ █▀█ █▀▄");
                Console.WriteLine();
            }

            if (titulo == "transferir") {
                Console.Clear();
                Console.WriteLine("\r\n▀█▀ █▀█ ▄▀█ █▄░█ █▀ █▀▀ █▀▀ █▀█ █ █▀█\r\n░█░ █▀▄ █▀█ █░▀█ ▄█ █▀░ ██▄ █▀▄ █ █▀▄");
                Console.WriteLine();
            }

            if (titulo == "movimentações") {
                Console.Clear();
                Console.WriteLine("\r\n█▀▄▀█ █▀█ █░█ █ █▀▄▀█ █▀▀ █▄░█ ▀█▀ ▄▀█ █▀▀ █▀█ █▀▀ █▀\r\n█░▀░█ █▄█ ▀▄▀ █ █░▀░█ ██▄ █░▀█ ░█░ █▀█ █▄▄ █▄█ ██▄ ▄█");
                Console.WriteLine();
            }

            if (titulo == "alterar senha") {
                Console.Clear();
                Console.WriteLine("\r\n▄▀█ █░░ ▀█▀ █▀▀ █▀█ ▄▀█ █▀█   █▀ █▀▀ █▄░█ █░█ ▄▀█\r\n█▀█ █▄▄ ░█░ ██▄ █▀▄ █▀█ █▀▄   ▄█ ██▄ █░▀█ █▀█ █▀█");
                Console.WriteLine();
            }
        }

        // ATENÇÃO
        public static void Atencao(string tipo) {
            if (tipo == "cadastro de cliente") {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("* É permitido apenas CPF válido;");
                Console.WriteLine("* No momento de inserir o CPF, informe apenas os números;");
                Console.WriteLine("* A senha precisa ter 4 dígitos (somente números).");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (tipo == "cadastro finalizado") {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("* O número da conta é também o login para acessar a área do cliente;");
                Console.WriteLine("* Solicite ao cliente, alterar a senha após efetuar o primeiro login no sistema.");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (tipo == "apagar cliente") {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("* Só é possível apagar o cadastro do cliente, caso o saldo da conta do mesmo esteja zerado;");
                Console.WriteLine("* Mesmo apagando a conta, as movimentações realizadas pelo cliente, continuarão registradas.");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (tipo == "confirmar apagar cliente") {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("* Após realizado o processo, não será possível reverter a exclusão.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // MENSAGENS DE RESPOSTA
        public static void msgResposta(string tipo, string resposta) {
            if (tipo == "erro") {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(resposta);
                Console.ResetColor();
                Console.WriteLine();
            }

            if (tipo == "sucesso") {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(resposta);
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // TENTAR NOVAMENTE
        public static void TentarNovamente(string tipo) {
            if (tipo == "login") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Login.FazerLogin();
                } else if ((resposta == "n") || (resposta == "N")) {
                    EncerrarSistema();
                } else {
                    Login.FazerLogin();
                }
            }

            if (tipo == "cadastro de cliente") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Cliente.Cadastrar();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("adm");
                }
                else {
                    Cliente.Cadastrar();
                }
            }

            if (tipo == "apagar cliente") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Cliente.Apagar();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("adm");
                }
                else {
                    Cliente.Apagar();
                }
            }

            if (tipo == "sacar") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Movimentacao.Sacar();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("cliente");
                }
                else {
                    Movimentacao.Sacar();
                }
            }

            if (tipo == "depositar") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Movimentacao.Depositar();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("cliente");
                }
                else {
                    Movimentacao.Depositar();
                }
            }

            if (tipo == "transferir") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Movimentacao.Transferir();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("cliente");
                }
                else {
                    Movimentacao.Transferir();
                }
            }

            if (tipo == "alterar senha") {
                Console.Write("Tentar novamente (S/N)? ");
                string resposta = Console.ReadLine();
                if ((resposta == "s") || (resposta == "S")) {
                    Cliente.AlterarSenha();
                }
                else if ((resposta == "n") || (resposta == "N")) {
                    Menu("cliente");
                }
                else {
                    Cliente.AlterarSenha();
                }
            }
        }

        // FAZER LOGOFF
        public static void Logoff() {

        }

        // ENCERRA SISTEMA
        public static void EncerrarSistema() {
            Console.Clear();
            Console.WriteLine("\r\n█▄▄ █▄█ ▀█▀ █▀▀   █▄▄ ▄▀█ █▄░█ █▄▀\r\n█▄█ ░█░ ░█░ ██▄   █▄█ █▀█ █░▀█ █░█");
            Console.WriteLine();
            Console.WriteLine("Encerrando Sistema...");
            Environment.Exit(0);
        }

        // VERIFICA SE O CPF É VÁLIDO OU NÃO
        public static bool ValidaCPF(string cpf) {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string auxCPF;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) {
                return false;
            }
            auxCPF = cpf.Substring(0, 9);
            soma = 0;

            switch (cpf) {
                case "00000000000":
                    return false;
                case "11111111111":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            for (int i = 0; i < 9; i++) {
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            auxCPF = auxCPF + digito;
            soma = 0;
            for (int i = 0; i < 10; i++) {
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        // VERIFICA SE TEM NÚMERO
        public static bool temNumero(string variavel) {
            bool resultado = false;
            
            if (variavel.Where(x => char.IsNumber(x)).Count() > 0) {
                resultado = true;
            }

            return resultado;
        }

        // GERA NÚMERO DA CONTA
        public static string GeraNumeroConta() {
            Random numeroAleatorio = new Random();
            int resultado = numeroAleatorio.Next(1000, 9999);

            for (int i = 0; i < Cliente.dataBase.Count; i++) {
                if (resultado.ToString() == Cliente.dataBase[i].Conta) {
                    resultado = numeroAleatorio.Next(1000, 9999);
                }
            }
            return resultado.ToString();
        }

        // VOLTAR PARA O MENU PRINCIPAL
        public static void VoltarMenu(string tipo) {
            Console.Write("Voltar para o menu principal (S/N)? ");
            char resposta = char.Parse(Console.ReadLine());
            if (tipo == "adm") {
                if ((resposta == 's') || (resposta == 'S')) {
                    Utils.Menu("adm");
                }
            } else if (tipo == "cliente") {
                if ((resposta == 's') || (resposta == 'S')) {
                    Utils.Menu("cliente");
                }
            } else {
                EncerrarSistema();
            }
        }

        // PEGAR DATA E HORA ATUAL
        public static string dataHoraAtual() {
            DateTime dataHoraAtual = DateTime.Now;
            return dataHoraAtual.ToString();
        }
    }
}
using Microsoft.Win32;
using System.Drawing;

namespace ByteBank.Entities {
    class Movimentacao {
        // AUTO PROPRIEDADES
        public string ContaOrigem  { get; private set; }
        public string ContaDestino { get; private set; }
        public string Data         { get; private set; }
        public double Valor        { get; private set; }
        public string Operacao     { get; private set; }

        // BANCO DE DADOS
        public static List<Movimentacao> dataBase = new List<Movimentacao>();

        // CONSTRUTOR
        public Movimentacao(string contaOrigem, string contaDestino, string data, double valor, string operacao) {
            ContaOrigem  = contaOrigem;
            ContaDestino = contaDestino;
            Data         = data;
            Valor        = valor;
            Operacao     = operacao;
        }

        // REGISTRAR MOVIMENTAÇÃO
        public static void RegistrarMovimentacao(string tipo, string contaOrigem, string contaDestino, string data, double valor, string operacao) {
            if (tipo == "saque") {
                dataBase.Add(new Movimentacao(contaOrigem, contaOrigem, data, valor, "Saque"));
            }

            if (tipo == "depósito") {
                dataBase.Add(new Movimentacao(contaDestino, contaDestino, data, valor, "Depósito"));
            }

            if (tipo == "transferência") {
                dataBase.Add(new Movimentacao(contaOrigem, contaDestino, data, valor, "Transferência"));
            }
        }

        // SACAR
        public static void Sacar() {
            Utils.Titulo("sacar");

            int index = Cliente.LocalizarIndex("conta", Login.loginAtivo);

            if (Cliente.dataBase[index].Saldo <= 0) {
                Utils.Titulo("sacar");
                Utils.msgResposta("erro", "SALDO INSUFICIENTE PARA SAQUE");
                Utils.VoltarMenu("cliente");
            }

            Console.Write("Informe o valor: ");
            double valorSaque = double.Parse(Console.ReadLine());
            if (Cliente.dataBase[index].Saldo < valorSaque) {
                Utils.Titulo("sacar");
                Utils.msgResposta("erro", "SALDO INSUFICIENTE");
                Utils.TentarNovamente("sacar");
            }

            Cliente.Sacar(index, valorSaque);
            RegistrarMovimentacao("saque", Login.loginAtivo, Login.loginAtivo, Utils.dataHoraAtual(), valorSaque, "Saque");
            Utils.Titulo("sacar");            
            Cliente.GeraInformacoesCliente("resumido", "com saldo", index);
            Utils.msgResposta("sucesso", "SAQUE REALIZADO COM SUCESSO");
            Utils.VoltarMenu("cliente");
        }

        // DEPOSITAR
        public static void Depositar() {
            Utils.Titulo("depositar");

            Console.Write("Informe o número da conta: ");
            string conta = Console.ReadLine();
            int index = Cliente.LocalizarIndex("conta", conta);
            if ((conta.Trim() == "") || (conta.Length < 4) || (!conta.All(char.IsDigit)) || (index == -1)) {
                Utils.Titulo("depositar");
                Utils.msgResposta("erro", "CONTA NÃO INFORMADA OU INEXISTENTE");
                Utils.TentarNovamente("depositar");
            }
            Console.Clear();
            Utils.Titulo("depositar");
            Cliente.GeraInformacoesCliente("resumido", "sem saldo", index);

            Console.Write("Informe o valor: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            if ((valorDeposito == null) || (valorDeposito <= 0)) {
                Utils.msgResposta("erro", "VALOR NÃO INFORMADO OU INVÁLIDO");
                Utils.TentarNovamente("depositar");
            }

            Cliente.Depositar(index, valorDeposito);
            RegistrarMovimentacao("depósito", conta, conta, Utils.dataHoraAtual(), valorDeposito, "Depósito");
            Utils.Titulo("depositar");
            Cliente.GeraInformacoesCliente("resumido", "sem saldo", index);
            Utils.msgResposta("sucesso", "DEPÓSITO REALIZADO COM SUCESSO");
            Utils.VoltarMenu("cliente");
        }

        // TRANSFERIR
        public static void Transferir() {
            Utils.Titulo("transferir");

            Console.Write("Conta destino: ");
            string contaDestino = Console.ReadLine();
            int indexContaDestino = Cliente.LocalizarIndex("conta", contaDestino);
            if ((contaDestino.Trim() == "") || (contaDestino.Length < 4) || (!contaDestino.All(char.IsDigit)) || (indexContaDestino == -1)) {
                Utils.Titulo("transferir");
                Utils.msgResposta("erro", "CONTA NÃO INFORMADA OU INEXISTENTE");
                Utils.TentarNovamente("transferir");
            }

            Console.Clear();
            Utils.Titulo("transferir");
            Cliente.GeraInformacoesCliente("resumido", "sem saldo", indexContaDestino);

            double valorTransferencia = 0;
            try {
                Console.Write("Informe o valor: ");
                valorTransferencia = double.Parse(Console.ReadLine());
            } catch (FormatException) {
                Utils.Titulo("transferir");
                Utils.msgResposta("erro", "VALOR INVÁLIDO");
                Utils.TentarNovamente("transferir");
            }

            int indexContaOrigem = Cliente.LocalizarIndex("conta", Login.loginAtivo);
            if (valorTransferencia > Cliente.dataBase[indexContaOrigem].Saldo) {
                Utils.Titulo("transferir");
                Utils.msgResposta("erro", "SALDO INSUFICIENTE");
                Utils.TentarNovamente("transferir");
            }

            Cliente.Transferir(indexContaOrigem, indexContaDestino, valorTransferencia);
            RegistrarMovimentacao("transferência", Login.loginAtivo, contaDestino, Utils.dataHoraAtual(), valorTransferencia, "Transferência");
            Utils.Titulo("transferir");
            Cliente.GeraInformacoesCliente("resumido", "sem saldo", indexContaDestino);
            Utils.msgResposta("sucesso", $"TRANSFERÊNCIA REALIZADA COM SUCESSO NO VALOR DE R$ {valorTransferencia.ToString("F2")}");
            Utils.VoltarMenu("cliente");
        }
    }
}
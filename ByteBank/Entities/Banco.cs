using System;

namespace ByteBank.Entities {
    class Banco {
        // INFORMAÇÕES GERAIS DO BANCO
        public static void InformacoesBanco() {
            Utils.Titulo("informações do banco");
            Console.WriteLine($"Quantidade de Clientes: {Cliente.dataBase.Count()}");
            Console.WriteLine($"Saldo Geral: R$ {SaldoGeral()}");
            Console.WriteLine();
            Utils.VoltarMenu("adm");
        }

        // SALDO GERAL DAS CONTAS
        public static double SaldoGeral() {
            double saldo = 0;

            for (int i = 0; i < Cliente.dataBase.Count(); i++) {
                saldo += Cliente.dataBase[i].Saldo;
            }

            return saldo;
        }
    }
}
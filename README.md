# Byte Bank
Projeto desenvolvido para a turma de formação de programadores Sharp Coders, da Ímã Learning Place.

## Validações / Regras de Negócio
* É preciso ter saldo positivo para realizar saque e/ou transferência;
* O valor do saque/transferência, não pode ser maior do que o saldo disponível na conta, ou seja, precisa ser menor ou igual;
* É possível um mesmo CPF possuir mais de uma conta, como em qualquer banco tradicional, mas não é possível, o mesmo cliente possuir duas contas com o mesmo número.
* No cadastro de cliente, é obrigatório informar o nome;
* No cadastro de cliente, é obrigatório informar um CPF válido;
* No cadastro de cliente, é obrigatório informar uma senha de acesso/transações;
* A exclusão de cliente só será possível, se o saldo da conta estiver zerado;

## Funcionalidades
O sistema possui dois tipos de usuário. Administrador e Cliente.

**Administrador**
1. Cadastro de Cliente
2. Exclusão de Cliente
3. Informações do Cliente
4. Informações do Banco
5. Logoff
6. Encerrar o Sistema

**Cliente**
1. Saque
2. Depósito
3. Transferência
4. Histórico das Movimentações
5. Alterar a senha de acesso/transações
6. Logoff
7. Encerrar o Sistema

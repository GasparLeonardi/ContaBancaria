using contabancaria.Controller;
using contabancaria.Model;

namespace contabancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {

            int opcao,agencia, tipo, aniversario;
            string? titular;
            decimal saldo, limite;


            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Samantha", 100000000.00M,1000);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Nico Robin", 100000000.00M, 25);
            contas.Cadastrar(cp1);

            while (true) {

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("************************************************");
                Console.WriteLine("                                                ");
                Console.WriteLine("               BANCO DIVERSIDADE                ");
                Console.WriteLine("                                                ");
                Console.WriteLine("************************************************");
                Console.WriteLine("                                                ");
                Console.WriteLine("  1 - Criar Conta                               ");
                Console.WriteLine("  2 - Listar todas as Contas                    ");
                Console.WriteLine("  3 - Buscar Conta por número                   ");
                Console.WriteLine("  3 - Buscar Conta por número                   ");
                Console.WriteLine("  4 - Atualizar dados da Conta                  ");
                Console.WriteLine("  5 - Apagar Conta                              ");
                Console.WriteLine("  6 - Sacar                                     ");
                Console.WriteLine("  7 - Depositar                                 ");
                Console.WriteLine("  8 - Transferir valores entre contas           ");
                Console.WriteLine("  9 - Sair                                      ");
                Console.WriteLine("                                                ");
                Console.WriteLine("************************************************");
                Console.WriteLine("                                                ");
                Console.WriteLine("Entre com a opção desejada:                     ");
                Console.WriteLine("                                                ");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                Console.Clear();

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Banco Diversidade - You're welcome (you really are!)");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
                switch (opcao) 
                {
                    case 1: 
                        Console.WriteLine("Criar Conta\n\n");

                        Console.WriteLine("Digite o número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o nome do titular: ");
                        titular = Console.ReadLine();
                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o tipo da conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.WriteLine("Digite o Saldo da conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o aniversario da conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;

                        }

                        

                        

                        KeyPress();
                        break;
                    case 2: 
                        Console.WriteLine("Listar todas as Contas\n\n");

                        contas.ListarTodas();
                        KeyPress();
                        break;
                    case 3: 
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("Apagar Conta\n\n");
                        KeyPress();
                        break;
                    case 6:
                        Console.WriteLine("Saque\n\n");
                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("Depósito\n\n");
                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("Transferência entre Contas\n\n");
                        KeyPress();
                        break;
                    default:
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\nOpção Inválida\n");
                        KeyPress();
                        break;
                }
            }
        }
        static void Sobre() 
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("                                                    ");
            Console.WriteLine(" Projeto desenvolvido por Gaspar Lima Leonardi      ");
            Console.WriteLine(" e-mail: gasparlleonardi@gmail.com                  ");
            Console.WriteLine(" Github: github.com/GasparLeonardi                  ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("****************************************************");
        }
        static void KeyPress()
        {
            do
            {
                Console.WriteLine("\nPressione Enter para Continuar...");
                consoleKeyInfo = Console.ReadKey();
            }while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }

    }
}
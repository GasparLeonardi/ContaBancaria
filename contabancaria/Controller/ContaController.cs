using contabancaria.Model;
using contabancaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contabancaria.Controller
{
    public class ContaController : IContaRepository
    {

        private readonly List<Conta> listaContas = new();
        int numero = 0;

        //Métodos CRUD
        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNaCollection(conta.GetNumero());

            if (buscaConta is not null)
            {
                var index = listaContas.IndexOf(buscaConta);

                listaContas[index] = conta;

                Console.WriteLine($"A conta numero {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }

        }
        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta n° {conta.GetNumero()} foi criada com sucesso!");
        }
        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero);
            if (conta is not null)
            {
                
                if(listaContas.Remove(conta) == true)
                {
                    Console.WriteLine($"A conta {numero} foi apagada com sucesso!");
                }
            }
            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void ListarTodas()
        {
            foreach(var conta in listaContas) 
            {
                conta.Visualizar();
            }
        }
        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollection(numero);
            if(conta is not null)
            {
                conta.Visualizar();
            }
            else {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            
            }
        }

        //Métodos Bancários
        public void Sacar(int numero, decimal valor)
        {

            var conta = BuscarNaCollection(numero);
            if (conta is not null)
            {

                if(conta.Sacar(valor) == true)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"O saque de {valor} na conta {numero} foi efetuado com sucesso!");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }

        }
        public void Depositar(int numero, decimal valor)
        {

            var conta = BuscarNaCollection(numero);
            if (conta is not null)
            {

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                conta.Depositar(valor);
                Console.WriteLine($"O deposito de {valor} na conta {numero} foi efetuado com sucesso!");
                Console.ResetColor();

            }
            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }

        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollection(numeroOrigem);
            var contaDestino = BuscarNaCollection(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {

                if(contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine("A transfêrencia foi efetuada com sucesso!");
                }

            }
            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta de Origem ou Destino não foi encontrada!");
                Console.ResetColor();
            }








        }

        //Metodos Auxiliares

        public int GerarNumero() 
        {
            return ++numero;
        }

        //Método para buscar um objeto Conta específico
        public Conta? BuscarNaCollection(int numero) 
        {
            foreach (var conta in listaContas)
            {
                if(conta.GetNumero() == numero)
                    return conta;
            }
            return null;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contabancaria.Model
{
    public class Conta
    {
        //Atributos
        private int numero;
        private int agencia;
        private int tipo;
        private string titular = string.Empty;
        private decimal saldo;

        //Metodo construtor
        public Conta(int numero, int agencia, int tipo, string titular, decimal saldo)
        {
            this.numero = numero;
            this.agencia = agencia;
            this.tipo = tipo;
            this.titular = titular;
            this.saldo = saldo;
        }

        //Metodos Get e Set
        public int GetNumero()
        {
            return numero;
        }
        public void SetNumero(int numero)
        {
            this.numero = numero;
        }
        public int GetAgencia()
        {
            return agencia;
        }
        public void SetAgencia(int agencia)
        {
            this.agencia = agencia;
        }
        public int GetTipo()
        {
            return tipo;
        }
        public void SetTipo(int tipo)
        {
            this.tipo = tipo;
        }
        public string GetTitular()
        {
            return titular;
        }
        public void SetTitular(string titular)
        {
            this.titular = titular;
        }
        public decimal GetSaldo()
        {
            return saldo;
        }
        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }
        public bool Sacar(decimal valor)
        {
            if (this.saldo < valor)
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.SetSaldo(this.saldo - valor);
            return true;
        }
        public void Depositar(decimal valor)
        {
            this.SetSaldo(this.saldo + valor);
        }
        public void Visualizar()
        {
            string tipo = string.Empty;
            
            switch(this.tipo)
            {
                case 1:
                    tipo = "Conta Corrente";
                    break;
                case 2:
                    tipo = "Conta Poupança";
                    break;
            }
            Console.WriteLine("************************************************");
            Console.WriteLine(" Dados da conta                                 ");
            Console.WriteLine("************************************************");
            Console.WriteLine($"Número da conta: {this.numero}");
            Console.WriteLine($"Número da agêncua: {this.agencia}");
            Console.WriteLine($"Tipo da conta: {tipo}");
            Console.WriteLine($"Titular da conta: {this.titular}");
            Console.WriteLine($"Saldo da conta: {(this.saldo).ToString("C")}");
            Console.WriteLine("************************************************");
        }
    }
    }
    

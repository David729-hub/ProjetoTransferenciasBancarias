using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranferenciasBancariasC.Enum;

namespace TranferenciasBancariasC.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valor) {
            if (this.Saldo - valor < (this.Credito * -1)) {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valor;

            Console.WriteLine("O saldo atual da conta do(a) {0} é {1}", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(double valor) {
            this.Saldo += valor;
            Console.WriteLine("O saldo atual da conta do(a) {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valor, Conta contadestino) {
            if (this.Sacar(valor)) {
                contadestino.Depositar(valor);
            }
            
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }

    }
}

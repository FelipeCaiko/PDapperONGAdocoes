using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Models
{
    public class Pessoa
    {
        #region Constant
        public readonly static string INSERT = "INSERT INTO dbo.Pessoa (Nome, CPF, Sexo, DataNascimento, Telefone) VALUES (@Nome, @CPF, @Sexo, @DataNascimento, @Telefone);";
        public readonly static string SELECT = "SELECT Nome, CPF, Sexo, DataNascimento, Telefone FROM dbo.Pessoa;";
        #endregion

        #region Properties
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        #endregion

        #region Method
        public override string ToString()
        {
            return  "\nNome: " + this.Nome +
                    "\nCPF: " + this.CPF +
                    "\nSexo: " + this.Sexo +
                    "\nData de Nascimento: " + this.DataNascimento.ToShortDateString() +
                    "\nTelefone: " + this.Telefone;
        }
        #endregion

        #region Method Constructor
        public Pessoa()
        {
        }

        public Pessoa(string nome, string cpf, char sexo, DateTime dataNascimento, string telefone)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.Telefone = telefone;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Models
{
    public class Animal
    {
        #region Constant
        public readonly static string INSERT = "INSERT INTO dbo.Animal (Familia, Raca, Sexo, Nome, Situacao) VALUES (@Familia, @Raca, @Sexo, @Nome, @Situacao);";
        public readonly static string SELECT = "SELECT Chip, Familia, Raca, Sexo, Nome, Situacao FROM dbo.Animal;";
        #endregion

        #region Properties
        public int Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public char Situacao { get; set; }
        #endregion

        #region Method
        public override string ToString()
        {
            return "\nChip: " + this.Chip +
                    "\nFamilia: " + this.Familia +
                    "\nRaça: " + this.Raca +
                    "\nSexo: " + this.Sexo +
                    "\nNome: " + this.Nome +
                    "\nSituacao: " + this.Situacao;
        }
        #endregion

        #region Method Constructor
        public Animal()
        {
        }

        public Animal(string Familia, string Raca, char Sexo, string Nome)
        {
            this.Familia = Familia;
            this.Raca = Raca;
            this.Sexo = Sexo;
            this.Nome = Nome;
            this.Situacao = 'D';
        }

        #endregion
    }
}

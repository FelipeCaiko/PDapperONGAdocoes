using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Models
{

    public class Adocoes
    {
        #region Constant
        public readonly static string INSERT = "INSERT INTO dbo.Adocoes (CPF, Chip, DataAdocao) VALUES (@CPF, @Chip, @DataAdocao);";
        public readonly static string SELECT = "SELECT ID, CPF, Chip, DataAdocao FROM dbo.Adocoes;";
        #endregion

        #region Properties
        public int Id { get; set; }
        public string CPF { get; set; }
        public int Chip { get; set; }
        public DateTime DataAdocao { get; set; }
        #endregion

        #region Method
        public override string ToString()
        {
            return "\nID: " + this.Id +
                    "\nCPF do Adotante: " + this.CPF +
                    "\nChip do Animal: " + this.Chip +
                    "\nData de Adoção: " + this.DataAdocao;
        }
        #endregion

        #region Method Constructor
        public Adocoes()
        {
        }

        public Adocoes(string cpf, int chip)
        {
            this.CPF = cpf;
            this.Chip = chip;
            this.DataAdocao = DateTime.Now;
        }
        #endregion

    }
}

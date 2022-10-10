using PDapperONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Repository
{
    public interface IAdocoesRepository
    {
        bool Add(Adocoes adocoes);
        bool Delete(int chip);
        List<Adocoes> GetAll();
    }
}

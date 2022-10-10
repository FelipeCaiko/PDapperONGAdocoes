using PDapperONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Repository
{
    public interface IPessoaRepository
    {
        bool Add(Pessoa pessoa);
        bool Update(string cpf, string parametro, string value);
        Pessoa GetOne(string cpf);
        bool Delete(string cpf);
        List<Pessoa> GetAll();
    }
}

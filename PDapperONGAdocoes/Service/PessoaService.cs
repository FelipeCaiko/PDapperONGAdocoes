using PDapperONGAdocoes.Models;
using PDapperONGAdocoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Service
{
    public class PessoaService
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaService()
        {
            _pessoaRepository = new PessoaRepository();
        }

        public bool Add(Pessoa pessoa)
        {
            return _pessoaRepository.Add(pessoa);
        }

        public bool Update(string cpf, string parametro, string value)
        {
            return _pessoaRepository.Update(cpf, parametro, value);
        }
        public Pessoa GetOne(string cpf)
        {
            return _pessoaRepository.GetOne(cpf);
        }
        public bool Delete(string cpf)
        {
            return _pessoaRepository.Delete(cpf);
        }
        public List<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }
    }

}

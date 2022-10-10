using PDapperONGAdocoes.Models;
using PDapperONGAdocoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Service
{
    public class AdocoesService
    {
        private IAdocoesRepository _adocoesRepository;

        public AdocoesService()
        {
            _adocoesRepository = new AdocoesRepository();
        }

        public bool Add(Adocoes adocoes)
        {
            return _adocoesRepository.Add(adocoes);
        }

        public bool Delete(int id)
        {
            return _adocoesRepository.Delete(id);
        }

        public List<Adocoes> GetAll()
        {
            return _adocoesRepository.GetAll();
        }
    }
}

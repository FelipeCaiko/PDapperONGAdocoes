using PDapperONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Repository
{
    public interface IAnimalRepository
    {
        bool Add(Animal animal);
        bool Update(int chip, string parametro, string value);
        Animal GetOne(int chip);
        bool Delete(int chip);
        List<Animal> GetAll();
    }
}

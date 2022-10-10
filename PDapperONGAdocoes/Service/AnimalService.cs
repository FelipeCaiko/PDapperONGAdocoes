using PDapperONGAdocoes.Models;
using PDapperONGAdocoes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Service
{
    public class AnimalService
    {
        private IAnimalRepository _animalRepository;

        public AnimalService()
        {
            _animalRepository = new AnimalRepository();
        }

        public bool Add(Animal animal)
        {
            return _animalRepository.Add(animal);
        }

        public bool Update(int chip, string parametro, string value)
        {
            return _animalRepository.Update(chip, parametro, value);
        }
        public Animal GetOne(int chip)
        {
            return _animalRepository.GetOne(chip);
        }
        public bool Delete(int chip)
        {
            return _animalRepository.Delete(chip);
        }
        public List<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }
    }
}

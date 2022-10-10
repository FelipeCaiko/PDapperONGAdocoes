using Dapper;
using PDapperONGAdocoes.Config;
using PDapperONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private string _conn;

        public AnimalRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Animal animal)
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.INSERT, animal);
                result = true;
            }
            return result;
        }

        public Animal GetOne(int chip)
        {
            Animal animal = new();

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var query = $"SELECT * FROM Animal WHERE Chip = {chip}";
                animal = db.Query<Animal>(query).FirstOrDefault();

                if (animal != null)
                {
                    return animal;
                }
                return null;
            }
        }
        public bool Delete(int chip)
        {
            using (var db = new SqlConnection(_conn))
            {
                var query = $"DELETE FROM Animal WHERE Chip = '{chip}'";
                db.Execute(query);
                return true;
            }
        }

        public bool Update(int chip, string parametro, string value)
        {
            using (var db = new SqlConnection(_conn))
            {
                var query = $"UPDATE Animal SET {parametro} = '{value}' WHERE Chip = '{chip}'";
                db.Execute(query);
                return true;
            }
        }

        public List<Animal> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animais = db.Query<Animal>(Animal.SELECT);
                return (List<Animal>)animais;
            }
        }
    }
}

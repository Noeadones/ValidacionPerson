using PersonRepository.Interfaces;
using System;
using PersonRepository;
using PersonRepository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PersonValidator
{
    public class Personax : IPersonRepositoryBasic, IPersonRepositoryAdvanced
    {
        public List<Person> People { get; set; }

        private bool IdExiste(Person person){
            return People.Exists(x => x.Id == person.Id);
        }
        private bool MayorACero(Person person){
            return person.Age > 0;
        }

        private bool EmailValido(Person person){
            return person.Email.Contains("@ariel.com");
        }

        public void Add(Person person)
        {             
           if(!IdExiste(person) && MayorACero(person) && EmailValido(person)){
                People.Add(person);
            }
             
        }

        public void Delete(int id)
        {
            var Item = People.Single(x => x.Id == id);
            People.Remove(Item);
        }

        public int GetCountRangeAges(int min, int max)
        {
            var ListAux = People.Where(x => x.Age >= min && x.Age <= max);

            return ListAux.Count();
        }

        private bool FiltroNombre(string name, Person person){
            
            return person.Name == name || name == null || name == "";
        }

        private bool FiltroEdad(int age, Person person){
            return person.Age == age || age == 0;
        }

        private bool FiltroEmail(string email, Person person){
            return email == null || person.Email.Contains(email);
        }
        public List<Person> GetFiltered(string name, int age, string email)
        {
            var ListaAux = People.Where(x => FiltroNombre(name, x) && FiltroEmail(email, x) && FiltroEdad(age, x)).ToList();
            return ListaAux;
        }

        public Person GetPerson(int Id)
        {
            Person persona = People.Find(p => p.Id == Id);
            return persona;
        }

        public void Update(Person person)
        {
            if(IdExiste(person) && MayorACero(person) && EmailValido(person)){
                Delete(person.Id);
                Add(person);
            }
        }

        Func <char, char, bool> EsMayus  = (v, c) => char.IsUpper(c) && v == ' ' ;
        Func <string, Func<bool>> Pasar = (name) => (c, b) => EsMayus(c,v);
        private bool IsCapitalized(string name){
            //bool isIt = false;
            int ind = (char.IsUpper(name[0])) ? 1 : 0;
            ind = ind + name.Count(c => EsMayus(c, v));
            return ind != 0;
        }
        public int[] GetNotCapitalizedIds()
        {
            int num = People.Count();
            int[] arrayNotCap = new int[num];
            int i = 0;
            foreach(Person person in People){
                string name = person.Name;

            
                if (!IsCapitalized(name)){
                    arrayNotCap[i] = person.Id;
                    i++;
                }
            }
            return arrayNotCap;
        }

        public Dictionary<int, string[]> GroupEmailByNameCount()
        {
            throw new NotImplementedException();
        }
    }
}
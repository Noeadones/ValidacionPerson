using PersonRepository.Interfaces;
using System;
using PersonRepository.Entities;
using System.Collections.Generic;
using PersonRepository;

namespace PersonValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var va = new ValidatorTest();
            var personax = new Personax();
            va.Validate(personax);
        }
    }
}

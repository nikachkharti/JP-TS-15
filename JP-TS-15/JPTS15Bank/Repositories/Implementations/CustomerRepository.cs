﻿using JPTS15Bank.Models;
using JPTS15Bank.Repositories.Interfaces;

namespace JPTS15Bank.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string _filePath = @"../../../Data/Customers.csv";
        private List<Customer> _customers = new();

        public CustomerRepository()
        {
            _customers = File
                .ReadAllLines(_filePath)
                .Skip(1)
                .Select(x => x.ToCustomer())
                .ToList();
        }

        /// <summary>
        /// ჩაამატებს ახალ მომხმარებელს არამარტო ლისტში არამედ ფაილშიც.
        /// Id-ს გაზრდის ავტომატურად.
        /// </summary>
        /// <param name="model"></param>
        public void AddCustomer(Customer model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// წამოიღებს პირველივე ისეთ ჩანაწერს რომელიც აკმაყოფილებს გადაცემულ ID -ს
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }


    internal static class CustomerExtension
    {
        internal static Customer ToCustomer(this string input)
        {
            string[] csvInput = input.Split(',');

            Customer result = new()
            {
                Id = int.Parse(csvInput[0]),
                Name = csvInput[1],
                IdentityNumber = csvInput[2],
                PhoneNumber = csvInput[3],
                Email = csvInput[4],
                Type = (CustomerType)Enum.Parse(typeof(CustomerType), csvInput[5])
            };

            return result;
        }
    }

}

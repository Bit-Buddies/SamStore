using SamStore.Core.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SamStore.Core.Domain.ValueObjects
{
    public class CPF : IValueObject
    {
        public const int CPFMaxLength = 11;
        public string Number { get; private set; }

        protected CPF() { }
        public CPF(string cpf)
        {
            string onlyNumbers = Regex.Replace(cpf, @"[^\d]", "");

            if (!Validate(onlyNumbers))
                throw new DomainException();

            Number = onlyNumbers;
        }

        public static bool Validate(string cpf)
        {
            cpf = cpf.OnlyNumbers();

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            string tempCpf;
            string digito;
            
            int soma;
            int resto;

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            
            resto = soma % 11;
            
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            
            resto = soma % 11;
            
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            
            digito = digito + resto.ToString();
            
            return cpf.EndsWith(digito);
        }
    }
}

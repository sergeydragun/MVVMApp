﻿using System.Collections.Generic;

namespace Vending.Model
{
    public struct Banknote {
        public string Name { get; }
        public int Nominal { get; }
        public bool IsCoin { get; }

        public static readonly IReadOnlyList<Banknote> Banknotes = new[] {
                new Banknote("Рубль", 1, true),
                new Banknote("Два рубля", 2, true),
                new Banknote("Пять рублей", 5, true),
                new Banknote("Десять рублей", 10, false),
                new Banknote("Пятьдесят рублей", 50, false),
                new Banknote("Сто рублей", 100, false),
            };
        private Banknote(string name, int nominal, bool isCoin) {
            Name = name;
            Nominal = nominal;
            IsCoin = isCoin;  
        }
        
    }
}

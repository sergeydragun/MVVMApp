﻿using System.Collections.Generic;


namespace MVVMApp.Model
{
    public class PurchaseManager
    {        
        public User User { get; } = new User();
        public Automata Automata { get; } = new Automata();

        public void InsertMoney(Banknote banknote)
        {
            if (User.GetBanknote(banknote))
                Automata.InsertBanknote(banknote);
        }

        public void BuyProduct(Product product)
        {
            if (Automata.BuyProduct(product))
                User.AddProduct(product);
        }

        public void GetChange()
        {
            IEnumerable<MoneyStack> change;
            if (Automata.GetChange(out change))
                User.AppendMoney(change);
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using MVVMApp.Client.ModelViews;
using MVVMApp.Model;

namespace MVVMApp.Client.ModelViews
{
    public class MainViewVM : BindableBase
    {
        public int UserSumm => _user.UserSumm;
        public ObservableCollection<MoneyVM> UserWallet { get; }
        public ObservableCollection<ProductVM> UserBuyings { get; }
        public DelegateCommand GetChange { get; }
        public int Credit => _automata.Credit;
        public ObservableCollection<MoneyVM> AutomataBank { get; }
        public ObservableCollection<ProductVM> ProductsInAutomata { get; }
        private User _user;
        private Automata _automata;
        private PurchaseManager _manager = new PurchaseManager();
        public MainViewVM()
        {
            _user = _manager.User;
            _automata = _manager.Automata;
            _user.PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(UserSumm)); };
            _automata.PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(Credit)); };

            UserWallet = new ObservableCollection<MoneyVM>(_user.UserWallet.Select(ms => new MoneyVM(ms)));
            Watch(_user.UserWallet, UserWallet, um => um.MoneyStack);

            UserBuyings = new ObservableCollection<ProductVM>(_user.UserBuyings.Select(ub => new ProductVM(ub)));
            Watch(_user.UserBuyings, UserBuyings, ub => ub.ProductStack);
            
            AutomataBank = new ObservableCollection<MoneyVM>(_automata.AutomataBank.Select(a => new MoneyVM(a, _manager)));
            Watch(_automata.AutomataBank, AutomataBank, a => a.MoneyStack);

            ProductsInAutomata = new ObservableCollection<ProductVM>(_automata.ProductsInAutomata.Select(ap => new ProductVM(ap, _manager)));
            Watch(_automata.ProductsInAutomata, ProductsInAutomata, p => p.ProductStack);

            GetChange = new DelegateCommand(() => _manager.GetChange());
        }
        

        private static void Watch<T, T2> (ReadOnlyObservableCollection<T> collToWatch, ObservableCollection<T2> collToUpdate,
            Func<T2, object> modelProperty)
        {
            ((INotifyCollectionChanged) collToWatch).CollectionChanged += (s, a) =>
            {
                if (a.NewItems?.Count == 1) collToUpdate.Add((T2) Activator.CreateInstance(typeof(T2), (T)a.NewItems[0], null));
                if (a.OldItems?.Count == 1) collToUpdate.Remove(collToUpdate.First(mv => modelProperty(mv) == a.NewItems[0]));
            };
        }
    }
    
    
}

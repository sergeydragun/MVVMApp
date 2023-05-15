using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using Vending.Model;

namespace Vending.Client.ModelViews
{
    public class MoneyVM : BindableBase
    {
        public Visibility IsInsertVisible => InsertCommand == null ? Visibility.Collapsed : Visibility.Visible;
        public DelegateCommand InsertCommand { get; }
        public string Icon => MoneyStack.Banknote.IsCoin ? @"..\Images\coin.jpg" : @"..\Images\banknote.png";
        public string Name => MoneyStack.Banknote.Name;
        public int Amount => MoneyStack.Amount;
        public MoneyStack MoneyStack { get; }

        public MoneyVM(MoneyStack moneyStack, PurchaseManager manager = null)
        {
            MoneyStack = moneyStack;
            moneyStack.PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(Amount)); };

            if (manager != null)
                InsertCommand = new DelegateCommand(() => {
                    manager.InsertMoney(MoneyStack.Banknote);
                });
        }
        
    }
}

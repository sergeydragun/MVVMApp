using MVVMApp.Client.ModelViews;
using System.Windows;


namespace MVVMApp.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewVM();
        }
    }
}

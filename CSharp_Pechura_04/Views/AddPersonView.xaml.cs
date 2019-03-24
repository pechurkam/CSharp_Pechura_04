using System.Windows.Controls;
using CSharp_Pechura_04.Tools.Navigation;
using CSharp_Pechura_04.ViewModels;

namespace CSharp_Pechura_04.Views
{
    /// <summary>
    /// Interaction logic for AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : UserControl, INavigatable
    {
        public AddPersonView()
        {
            InitializeComponent();
            DataContext = new AddPersonViewModel();
        }
    }
}


using System.Windows.Controls;
using CSharp_Pechura_04.Tools.Navigation;
using CSharp_Pechura_04.ViewModels;

namespace CSharp_Pechura_04.Views
{
    /// <summary>
    /// Interaction logic for EditPersonView.xaml
    /// </summary>
    public partial class EditPersonView : UserControl, INavigatable
    {
        public EditPersonView()
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel();
        }
    }
}
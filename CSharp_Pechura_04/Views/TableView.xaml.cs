using CSharp_Pechura_04.Tools.Managers;
using CSharp_Pechura_04.Tools.Navigation;
using CSharp_Pechura_04.ViewModels;
using UserControl = System.Windows.Controls.UserControl;

namespace CSharp_Pechura_04.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl, INavigatable
    {

        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
            StationManager.PersonTable = TableGrid;
        }

    }
}

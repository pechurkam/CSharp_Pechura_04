namespace CSharp_Pechura_04.Tools.Navigation
{
    internal enum ViewType
    {
        TableView,
        AddPersonView,
        EditPersonView
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}

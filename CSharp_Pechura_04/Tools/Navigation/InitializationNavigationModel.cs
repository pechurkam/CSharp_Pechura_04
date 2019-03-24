using System;
using CSharp_Pechura_04.Views;

namespace CSharp_Pechura_04.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.TableView:
                    ViewsDictionary.Add(viewType, new TableView());
                    break;
                case ViewType.AddPersonView:
                    ViewsDictionary.Add(viewType, new AddPersonView());
                    break;
                case ViewType.EditPersonView:
                    ViewsDictionary.Add(viewType, new EditPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}

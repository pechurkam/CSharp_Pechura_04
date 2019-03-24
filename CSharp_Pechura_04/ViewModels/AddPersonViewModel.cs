using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Pechura02_03.Tools.Exceptions;
using CSharp_Pechura04.Tools.Exceptions;
using CSharp_Pechura_04.Models;
using CSharp_Pechura_04.Tools;
using CSharp_Pechura_04.Tools.Managers;
using CSharp_Pechura_04.Tools.Navigation;

namespace CSharp_Pechura_04.ViewModels
{
    class AddPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Person _person = StationManager.CurrentPerson;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        public AddPersonViewModel()
        {
        }

        #region Properties
        public Person PersonObj

        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           ProceedImplementation, CanExecuteProceed));
            }
        }

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           CancelImplementation));
            }
        }

        #endregion

        private async void ProceedImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                try
                {
                    _person.Validate();
                }
                catch (NotBornException e)
                {
                    MessageBox.Show($"Помилка з віком: {e.Message}");
                    return false;
                }
                catch (DeadPersonException e)
                {
                    MessageBox.Show($"Помилка з віком: {e.Message}");
                    return false;
                }
                catch (EmailException e)
                {
                    MessageBox.Show($"Помилка з поштою: {e.Message}");
                    return false;
                }
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (res)
            {
                StationManager.DataStorage.Add(_person);
                _person = new Person("", "", "");
                PersonObj = _person;
                NavigationManager.Instance.Navigate(ViewType.TableView);
            }
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonObj.Email) && !String.IsNullOrWhiteSpace(PersonObj.Name) && !String.IsNullOrWhiteSpace(PersonObj.Surname);
        }

        private void CancelImplementation(object obj)
        {
            StationManager.TablePersonVM.UpdateInfo();
            NavigationManager.Instance.Navigate(ViewType.TableView);
        }
    }
}

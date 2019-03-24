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
    class EditPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public EditPersonViewModel()
        {
            StationManager.EditPersonVM = this;
        }
        #region Fields
        private Person _person = StationManager.CurrentPerson;
        private Person _personToEdit = StationManager.PersonToEdit;

        private RelayCommand<object> _confirmCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        #region Properties
        public Person PersonToEdit
        {
            get { return _personToEdit; }
            set
            {
                _personToEdit = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ConfirmCommand
        {
            get
            {
                return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(
                           ConfirmImplementation, CanExecuteProceed));
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

        private async void ConfirmImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                try
                {
                    _personToEdit.Validate();
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
                _person.Name = _personToEdit.Name;
                _person.Surname = _personToEdit.Surname;
                _person.Email = _personToEdit.Email;
                _person.Birthday = _personToEdit.Birthday;
                StationManager.PersonToEdit = null;
                StationManager.DataStorage.DoChanges();
                StationManager.TablePersonVM.UpdateInfo();
                NavigationManager.Instance.Navigate(ViewType.TableView);
            }
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonToEdit.Email) && !String.IsNullOrWhiteSpace(PersonToEdit.Name) && !String.IsNullOrWhiteSpace(PersonToEdit.Surname);
        }

        private async void CancelImplementation(object obj)
        {
               StationManager.PersonToEdit = null;
            NavigationManager.Instance.Navigate(ViewType.TableView);

        }

        public void Update()
        {
            _personToEdit = StationManager.PersonToEdit;
            _person = StationManager.CurrentPerson;
            OnPropertyChanged("PersonToEdit");
        }
    }
}


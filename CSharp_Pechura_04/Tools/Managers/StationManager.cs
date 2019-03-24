using System;
using System.Windows;
using System.Windows.Controls;
using CSharp_Pechura_04.Models;
using CSharp_Pechura_04.Tools.DataStorage;
using CSharp_Pechura_04.ViewModels;

namespace CSharp_Pechura_04.Tools.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentPerson { get; set; }
        internal static Person PersonToEdit { get; set; }
        internal static DataGrid PersonTable { get; set; }
        internal static EditPersonViewModel EditPersonVM { get; set; }
        internal static TableViewModel TablePersonVM { get; set; }

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

    }
}


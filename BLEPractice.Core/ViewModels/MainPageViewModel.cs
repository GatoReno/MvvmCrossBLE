using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using BLEPractice.Abstractions.BLEHelpers;
using BLEPractice.Abstractions.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BLEPractice.Core.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel, IBLECastReciver //implementar IBLE
    {
        private readonly IUserDialogs _userDialogs;                       
        private readonly IScanBLE _scanBLE;
        public MvxObservableCollection<BLEDataItem> bleDataItems { get; set; }

   
        //status
        private string _blestatus;
        public string Status
        {
            get => _blestatus;
            set => SetProperty(ref _blestatus, value);
        }


        public IMvxCommand StartScanning { get; set; }
        public IMvxCommand StopScanning { get; set; }


        public MainPageViewModel(// construir
            IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IScanBLE  scanBLEObject, //recuerda para construir un servicio  hay que registrarlo
            IUserDialogs userDialogs            
            ) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs; 
            bleDataItems = new MvxObservableCollection<BLEDataItem>();
            _scanBLE = scanBLEObject;
            StartScanning = new MvxCommand(OnStartScannCommand);
            StopScanning = new MvxCommand(OnStopScannCommand);
            Title = "BLE Scanner";
        }

        public override void ViewCreated()
        {
            base.ViewCreated(); 
        }

       
        public override void ViewAppearing()
        {
            base.ViewAppearing();
            _scanBLE.StartScanning();
         }
        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
             _scanBLE.CancelScanning();
             
        }


        private void OnStartScannCommand()
        {
            bleDataItems.Clear();
            _scanBLE.StartScanning();

        }
        private void OnStopScannCommand()
        {
            _scanBLE.CancelScanning(); 
        }



        public void AddDeviceRecived(BLEDataItem dataItem)
        {
            var items = bleDataItems.Where(m => m.GetListItemType() == ListItemType.DataItem).ToList();
          
            if (items != null && !items.Any(x =>
                   ((BLEDataItem)x).Text == dataItem.Text
                   && ((BLEDataItem)x).SubTitle == dataItem.SubTitle))
            {
                bleDataItems.Add(dataItem);
            }

        }

    
    }

}


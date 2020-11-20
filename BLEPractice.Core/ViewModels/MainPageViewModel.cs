using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using BLEPractice.Abstractions.BLEHelpers;
using BLEPractice.Abstractions.Interfaces;
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
     

        public MainPageViewModel(// construir
            IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IUserDialogs userDialogs
            //IBLECastReciver bleCastReciver
            //, IScanBLE scanBLE
            ) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs; 
            bleDataItems = new MvxObservableCollection<BLEDataItem>();
        }

        public override void ViewCreated()
        {
            base.ViewCreated();
        }

       
        public override void ViewAppearing()
        {
            base.ViewAppearing();
            //_scanBLE.CancelScanning();
        }

        public void AddDeviceRecived(BLEDataItem dataItem)
        {
            bleDataItems.Add(dataItem);

        }
    }

}


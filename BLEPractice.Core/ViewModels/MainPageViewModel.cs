using System;
using System.Collections.Generic;
using System.Linq;
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

        //private MvxInteraction<bool> _interactionStartScan = new MvxInteraction<bool>();
        //public IMvxInteraction<bool> StartSCanInteraction => _interactionStartScan;

        private readonly IScanBLE _scanBLE;
        public MvxObservableCollection<BLEDataItem> bleDataItems { get; set; }
     

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
        }

        public override void ViewCreated()
        {
            base.ViewCreated();
        }

       
        public override void ViewAppearing()
        {
            base.ViewAppearing();
            _scanBLE.StartScanning();
            //_interactionStartScan.Raise(true);
        }
        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            // _interactionStartScan.Raise(false);
            _scanBLE.CancelScanning();
        }

       
        public void AddDeviceRecived(BLEDataItem dataItem)
        {
            var items = bleDataItems.Where(m => m.GetListItemType() == ListItemType.DataItem).ToList();
          
            if (items != null && !items.Any(x =>
                   ((BLEDataItem)x).Text == dataItem.Text && ((BLEDataItem)x).SubTitle == dataItem.SubTitle))
            {
                bleDataItems.Add(dataItem);
            }

        }

        //public void StartScanning()
        //{
        //    throw new NotImplementedException();
        //}

        //public void CancelScanning()
        //{
        //    throw new NotImplementedException();
        //}
    }

}


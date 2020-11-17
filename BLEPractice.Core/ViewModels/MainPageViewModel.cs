using System;
using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using Plugin.BLE.Abstractions.Contracts;

namespace BLEPractice.Core.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
         private readonly IUserDialogs _userDialogs;



        private readonly IBluetoothLE _ble;
        private readonly IAdapter _adapter;

        public MainPageViewModel(IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IUserDialogs userDialogs, IBluetoothLE ble, IAdapter adapter) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs;
            _ble = ble;
            _adapter = adapter;

        }

        
    }

}

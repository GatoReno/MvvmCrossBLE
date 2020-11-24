using System;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using BLEPractice.Abstractions.Interfaces;
using BLEPractice.Core.ViewModels;
using BLEPractice.Droid.BLEService;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace BLEPractice.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainPageView : BaseView<MainPageViewModel> , IScanBLE
    {

        private BluetoothDeviceReceiver _receiver;
        private BluetoothManager _manager;
        private bool _isReceiveredRegistered;
        private BLEScanService scanBlLEService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //
            var set = this.CreateBindingSet<MainPageView, MainPageViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            //set.Bind(this).For(v => v.StartInteraction).To(vm => vm.StartSCanInteraction);
            set.Apply();

            SetContentView(Resource.Layout.activity_main);

            _manager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
            //_manager.Adapter.Enable();
            _receiver = new BluetoothDeviceReceiver();


            _receiver.BLECastReciver = ViewModel;


            scanBlLEService = new BLEScanService();
            
            //OnStartScanBLE();

            RegisterBluetoothReceiver();

        }

        private void RegisterBluetoothReceiver()
        {
            if (_isReceiveredRegistered) return;

            RegisterReceiver(_receiver, new IntentFilter(BluetoothDevice.ActionFound));
            RegisterReceiver(_receiver, new IntentFilter(BluetoothAdapter.ActionDiscoveryStarted));
            RegisterReceiver(_receiver, new IntentFilter(BluetoothAdapter.ActionDiscoveryFinished));
            _isReceiveredRegistered = true;
        }

        //private IMvxInteraction<bool> _startInteraction;
        //public IMvxInteraction<bool> StartInteraction
        //{
        //    get => _startInteraction;

        //    set
        //    {
        //        if (_startInteraction != null)
        //        {
        //            _startInteraction.Requested -= OnStartScanBLE;
        //        }

        //        _startInteraction = value;
        //        _startInteraction.Requested += OnStartScanBLE;
        //    }
        //}

        public void OnStartScanBLE(object sender, MvxValueEventArgs<bool> e)
        {
            scanBlLEService.StartScanning();
           
        }

        public void OnStopScanBLE()
        {
            scanBlLEService.CancelScanning();
        }

        public void StartScanning()
        {
            scanBlLEService.StartScanning();
        }

        public void CancelScanning()
        {
            scanBlLEService.CancelScanning();
        }
    }
}

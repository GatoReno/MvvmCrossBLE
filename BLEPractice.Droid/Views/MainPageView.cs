﻿using System;
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
    public class MainPageView : BaseView<MainPageViewModel>  
    {

        private BluetoothDeviceReceiver _receiver;
        private BluetoothManager _manager;
        private bool _isReceiveredRegistered;
        private BLEScanService scanBlLEService;
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //
           

            SetContentView(Resource.Layout.activity_main);

            _manager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
            _manager.Adapter.Enable();
            _receiver = new BluetoothDeviceReceiver(ViewModel as IBLECastReciver);
            //_receiver.BLECastReciver = ViewModel;
            //BindBLEViewModel();
            scanBlLEService = new BLEScanService();

            
            RegisterBluetoothReceiver();

            var set = this.CreateBindingSet<MainPageView, MainPageViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title); 
            set.Apply();

        }

       

        private void RegisterBluetoothReceiver()
        {
            if (_isReceiveredRegistered) return;

            RegisterReceiver(_receiver, new IntentFilter(BluetoothDevice.ActionFound));
            RegisterReceiver(_receiver, new IntentFilter(BluetoothAdapter.ActionDiscoveryStarted));
            RegisterReceiver(_receiver, new IntentFilter(BluetoothAdapter.ActionDiscoveryFinished));
            _isReceiveredRegistered = true;
        }

       

     
      
    }
}

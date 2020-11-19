using System;
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BLEPractice.Core;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace BLEPractice.Droid
{
    [Application]
    public class MainActivity : MvxAppCompatApplication<Setup, App>
    {
        public MainActivity(IntPtr handle, JniHandleOwnership transer)
       : base(handle, transer)
        {
        }


        public override void OnCreate()
        {
            base.OnCreate();
            //intialize all plugins
            UserDialogs.Init(this);
            

        }
    }
}
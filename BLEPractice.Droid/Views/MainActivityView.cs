using System;
using Android.App;
using Android.OS;
using BLEPractice.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
 
namespace BLEPractice.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivityView : BaseView<MainPageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //
            var set = this.CreateBindingSet<MainActivityView, MainPageViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();

            SetContentView(Resource.Layout.activity_main);
        }

    }
}

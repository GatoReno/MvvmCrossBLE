using System;
using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Navigation; 
namespace BLEPractice.Core.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
         private readonly IUserDialogs _userDialogs;



   
     

        public MainPageViewModel(IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IUserDialogs userDialogs ) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs;
           
        }

        public async override void ViewCreated()
        {
            base.ViewCreated();
         }

        
         override vi


    }

}


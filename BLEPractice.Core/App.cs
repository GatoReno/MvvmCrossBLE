using System;
using Acr.UserDialogs;
using BLEPractice.Abstractions.Interfaces;
using BLEPractice.Core.ViewModels;
 
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels; 
namespace BLEPractice.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IUserService, MockUserService>();
            //service
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(UserDialogs.Instance);
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBLECastReciver, BLECastReciver>();
            //BLECastReciver

            RegisterAppStart<MainPageViewModel>();
        }
    }
}

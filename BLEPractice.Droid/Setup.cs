using System;
using System.Collections.Generic;
using MvvmCross;
using System.Reflection;
using BLEPractice.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using BLEPractice.Abstractions.Interfaces;
using BLEPractice.Droid.BLEService;
using MvvmCross.IoC;

namespace BLEPractice.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
           new List<Assembly>(base.AndroidViewAssemblies)
           {
                typeof(MvxRecyclerView).Assembly
           };

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            var blescan = new BLEScanService();
            Mvx.IoCProvider.RegisterSingleton<IScanBLE>(blescan);

        }
    }
}

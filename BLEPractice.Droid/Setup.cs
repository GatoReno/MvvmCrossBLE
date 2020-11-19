using System;
using System.Collections.Generic;
using MvvmCross;
using System.Reflection;
using BLEPractice.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;

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

        }
    }
}

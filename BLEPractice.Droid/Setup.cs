using System;
using System.Collections.Generic;
using System.Reflection;
using BLEPractice.Core;

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

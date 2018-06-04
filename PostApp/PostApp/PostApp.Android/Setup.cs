using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using MvvmCross.Platform.Logging;

namespace PostApp.Droid
{
    /// <summary>
    /// Platform setup class
    /// </summary>
    public class Setup : MvxFormsAndroidSetup
    {
        /// <summary>
        /// Constructor
        /// </summary>        
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        /// <summary>
        /// Sets the log provider
        /// </summary>
        /// <returns></returns>
        protected override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.None;


        /// <summary>
        /// Returns the assemblies used
        /// </summary>
        protected override IEnumerable<Assembly> GetViewAssemblies()
        {
            return new List<Assembly>(base.GetViewAssemblies().Union(new[] { typeof(PostApp.App).GetTypeInfo().Assembly }));
        }


        /// <summary>
        ///  Creates the app
        /// </summary>
        /// <returns></returns>
        protected override MvxFormsApplication CreateFormsApplication() => new PostApp.App();


        /// <summary>
        ///  Creates the Forms app
        /// </summary>
        /// <returns></returns>
        protected override IMvxApplication CreateApp() => new PostApp.CoreApp();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.Platform;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace PostApp.iOS
{
    public class Setup : MvxFormsIosSetup
    {
        public Setup(IMvxApplicationDelegate appDelegate, UIWindow window)
          : base(appDelegate, window)
        {
        }

        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new PostApp.App();
        }

        protected override IMvxApplication CreateApp()
        {
            return new PostApp.CoreApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
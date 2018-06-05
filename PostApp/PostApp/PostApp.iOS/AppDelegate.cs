﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.Platform;
using UIKit;

namespace PostApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate
    {
        public override UIWindow Window { get; set; }
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();


            startup.Start();

            LoadApplication(setup.FormsApplication);

            Window.MakeKeyAndVisible();
            return true;
        }
    }
}

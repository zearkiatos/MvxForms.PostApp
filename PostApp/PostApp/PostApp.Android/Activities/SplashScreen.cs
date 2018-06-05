using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace PostApp.Droid.Activities
{
    [Activity(
      Theme = "@style/Theme.Splash"
    , Label = "PostApp"
    , MainLauncher = true
    , Icon = "@drawable/icon"
    , NoHistory = true
    , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen)
        {
        }
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);

        }
        protected override void TriggerFirstNavigate()
        {
            StartActivity(typeof(MainActivity));
            base.TriggerFirstNavigate();

        }
    }
}
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    RegisterNavigationServiceAppStart<ViewModels.RootViewModel>();
                    break;
                default:
                    RegisterNavigationServiceAppStart<ViewModels.HomeViewModel>();
                    break;
            }
        }
    }
}

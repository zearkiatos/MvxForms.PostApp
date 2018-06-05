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
    /// <summary>
    /// Class with the core of the applications.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
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

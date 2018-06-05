using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    /// <summary>
    /// Class than represent RootViewModel the root of the projects than is the base of all view model classes than herectics of BaseViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class RootViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService navigationService;

        public RootViewModel()
        {
            this.ViewAppeared();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService"></param>
        public RootViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }


        /// <summary>
        /// Initialize the view
        /// </summary>
        public override void ViewAppeared()
        {
            MvxNotifyTask.Create(async () => {
                await ShowFirstViewModel();
            });
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }


        /// <summary>
        /// Shows the first view model
        /// </summary>
        /// <returns></returns>
        private async Task ShowFirstViewModel()
        {
            await this.navigationService.Navigate<HomeViewModel>();
        }
    }
}

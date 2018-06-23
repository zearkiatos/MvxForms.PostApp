using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PostApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    /// <summary>
    /// Abstract class than represent BaseViewModel than is the base of all view model classes than herectics of MvxViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public abstract class BaseViewModel : MvxViewModel
    {
        private bool isBusy;

        /// <summary>
        /// Get's if the viewModel is busy doing something
        /// </summary>
        public bool IsBusy
        {
            get => this.isBusy;
            set
            {
                this.isBusy = value;
                RaisePropertyChanged(() => IsBusy);
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        /// <summary>
        /// Gets the current NavigationService
        /// </summary>
        protected IMvxNavigationService NavigationService
        {
            get;
        }

        /// <summary>
        /// Gets the current data service
        /// </summary>
        protected IDataService DataService
        {
            get;
        }

        protected IPostService PostService
        {
            get;
        }

        protected IUserService UserService
        {
            get;
        }

        protected IReposService ReposService
        {
            get;
        }
        /// <summary>
        /// Gets if the ViewModel is enabled.
        /// It's the inverse of IsBusy for easier binding. (If IsBusy = true them IsEnabled = false)
        /// </summary>
        public bool IsEnabled
        {
            get => !this.isBusy;
            set
            {
                this.isBusy = !value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseViewModel()
        {
            this.DataService = Mvx.GetSingleton<IDataService>();
            this.PostService = Mvx.GetSingleton<IPostService>();
            this.UserService = Mvx.GetSingleton<IUserService>();
            this.ReposService = Mvx.GetSingleton<IReposService>();
            this.NavigationService = Mvx.GetSingleton<IMvxNavigationService>();
        }



        /// <summary>
        /// Checks if the Internet connection is available
        /// </summary>
        /// <returns></returns>
        public static bool IsInternetConnectionAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }

    /// <summary>
    /// Base ViewModel with parameters
    /// </summary>
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter> where TParameter : class
    {
        /// <summary>
        /// Called with the ViewModel's parameters before Initialize()
        /// </summary>
        public abstract void Prepare(TParameter parameter);
    }

    /// <summary>
    /// Base ViewModel with parameters and result
    /// </summary>
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModel, IMvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        //private TaskCompletionSource<TResult> taskCompletionSource;
        //private bool isClosing;

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        /// <summary>
        /// Called with the ViewModel's parameters before Initialize()
        /// </summary>
        public abstract void Prepare(TParameter parameter);
    }
}

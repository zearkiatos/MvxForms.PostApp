using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    /// <summary>
    /// Class than represent MainViewModel than is the base of all view model classes than herectics of BaseViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ShowViewModel<HomeViewModel>();
        }
        public override void Prepare()
        {

        }
        /// <summary>
        /// Initializes the data for this ViewModel
        /// </summary>
        /// <returns></returns>
        public override Task Initialize()
        {
            return Task.Run(async () =>
            {

            });
        }
    }
}

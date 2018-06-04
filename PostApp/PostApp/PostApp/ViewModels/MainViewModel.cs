using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
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

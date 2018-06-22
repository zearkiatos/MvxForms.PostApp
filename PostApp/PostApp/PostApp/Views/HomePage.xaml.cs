using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;
using PostApp.Models;
using PostApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class HomePage : MvxTabbedPage<HomeViewModel>
    {
        public HomePage ()
        {
            InitializeComponent();
        }
        
        private void ViewItem_Clicked(Button sender, EventArgs e)
        {
            var parameter = (Post)sender.CommandParameter;

            var viewModel = (HomeViewModel)DataContext;
            viewModel.Post = parameter;
            if (viewModel.ShowPostDetailPageCommand.CanExecute())
            {
                viewModel.ShowPostDetailPageCommand.Execute();
            }
        }

        private void GuardarPost_Clicked(object sender, EventArgs e)
        {
            var viewModel = (HomeViewModel)DataContext;
            viewModel.CreatePostCommand.Execute();
        }

        private void EditItem_Clicked(Button sender, EventArgs e)
        {
            var parameter = (Post)sender.CommandParameter;
            var viewModel = (HomeViewModel)DataContext;
            viewModel.Post = parameter;
            viewModel.ShowEditPostPageCommand.Execute();
        }

        private void DeleteItem_Clicked(Button sender, EventArgs e)
        {
            var parameter = (Post)sender.CommandParameter;
            var viewModel = (HomeViewModel)DataContext;
            viewModel.Post = parameter;
            viewModel.ShowDeletePostPageCommand.Execute();
        }

    }
}
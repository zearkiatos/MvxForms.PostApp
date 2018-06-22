using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;
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
    public partial class EditPostPage : MvxContentPage<PostViewModel>
    {
		public EditPostPage ()
		{
			InitializeComponent ();
		}

        private void EditarPost_Clicked(object sender, EventArgs e)
        {

        }
    }
}
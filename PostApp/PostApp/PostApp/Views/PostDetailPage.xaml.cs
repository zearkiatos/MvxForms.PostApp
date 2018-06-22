using MvvmCross.Forms.Views;
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
	public partial class PostDetailPage : MvxContentPage<PostDetailViewModel>
    {
		public PostDetailPage ()
		{
			InitializeComponent();
		}
	}
}
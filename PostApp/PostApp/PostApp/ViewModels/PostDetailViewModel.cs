using MvvmCross.Core.ViewModels;
using PostApp.Models;
using PostApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    /// <summary>
    /// Class than represent PostDetailViewModel than is the base of all view model classes than herectics of BaseViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>10.06.2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class PostDetailViewModel : BaseViewModel<Post>
    {
        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                RaisePropertyChanged(() => Post);
            }
        }

        /// <summary>
        /// Initializes the data Post
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>16.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        public override Task Initialize()
        {
            return Task.Run(async () =>
            {
                try
                {
                    this.IsBusy = true;
                    Post = post;
                }
                catch (Exception ex)
                {
                    post = new Post();
                }
                finally
                {
                    this.IsBusy = false;
                }
            });
        }

        public override void Prepare(Post parameter)
        {
            post = parameter;
        }
    }
}

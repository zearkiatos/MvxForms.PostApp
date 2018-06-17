using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PostApp.Models;
using PostApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    

    /// <summary>
    /// Class than represent HomeViewModel than is the base of all view model classes than herectics of BaseViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05.06.2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private Post post;

        public Post Post
        {
            get { return post; }
            set {
                post = value;
                RaisePropertyChanged(() => Post);
            }
        }

        private Post newPost;

        public Post NewPost
        {
            get { return newPost; }
            set
            {
                newPost = value;
                RaisePropertyChanged(() => newPost);
            }
        }

        /// <summary>
        /// Post viewmodel logic
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>10.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        private ObservableCollection<Post> posts;

        /// <summary>
        /// Post List
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>10.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set
            {
                posts = value;
                RaisePropertyChanged(() => Posts);
            }
        }

        /// <summary>
        /// Initializes the data, populates Post List
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>10.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        public override Task Initialize()
        {
            return Task.Run(async () =>
            {
                try
                {
                    this.IsBusy = true;
                    Posts = new ObservableCollection<Post>(this.PostService.GetPosts());
                }
                catch (Exception ex)
                {
                    Posts.Add(new Post
                    {
                        Id = 0,
                        Title = "",
                        Body = "",
                        UserId = 0
                    });
                    newPost = new Post();
                }
                finally
                {
                    this.IsBusy = false;
                }
            });
        }

        public override void Prepare()
        {
        }

        //public async Task selectedPost()
        //{
        //    await _navigationService.Navigate<PostDetailViewModel, Post>(post);
        //}
        /// <summary>
        /// Navigate to show the post details
        /// </summary>
        public IMvxCommand ShowPostDetailPageCommand
        {
            get
            {
                return new MvxCommand(() =>
                    this.NavigationService.Navigate<PostDetailViewModel, Post>(post));
            }
        }
    }
}

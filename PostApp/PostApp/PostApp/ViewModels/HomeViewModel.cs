using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PostApp.Commons;
using PostApp.Models;
using PostApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// <summary>
        /// Attribute readonly object type IMvxNavigationService to navigate and send parameters.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>16.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        private readonly IMvxNavigationService _navigationService;

        /// <summary>
        /// HomeViewModel Constructor class than receive the IMvxNavigation Parameter.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>10.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="navigationService">Navigation service.</param>
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
        /// Repos viewmodel logic
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        private ObservableCollection<Repos> repos;

        /// <summary>
        /// Repos List by User
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        public ObservableCollection<Repos> Repos
        {
            get { return repos; }
            set
            {
                repos = value;
                RaisePropertyChanged(() => Repos);
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
                    Repos = new ObservableCollection<Repos>(this.ReposService.GetReposByUser(Constants.githubUser));
                    NewPost = new Post();
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

                    Repos.Add(new Repos
                    {
                        Id = 0,
                        Description = "",
                        FullName = "",
                        Name = "",
                        Owner = new Owner()
                        {
                            AvatarUrl="",
                            Id = 0,
                            Login = ""
                        }
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

        /// <summary>
        /// Command method to navigate and send parameter post than consulting.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>16.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <return>IMvxCommand result.</return>
        public IMvxCommand ShowPostDetailPageCommand
        {
            get
            {
                return new MvxCommand(() =>
                    this.NavigationService.Navigate<PostDetailViewModel, Post>(post));
            }
        }

        /// <summary>
        /// Method to valid model post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>18.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>Boolean value</returns>
        bool PostValid()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(NewPost.Title) && !string.IsNullOrEmpty(NewPost.Body))
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// Command method to navigate and send parameter post than consulting.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>16.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <return>IMvxCommand result.</return>
        public IMvxCommand CreatePostCommand
        {
            get
            {
                return new MvxCommand<Post>(async newPost =>
                {
                    this.IsBusy = true;
                    try
                    {
                        if (this.PostValid())
                        {
                            NewPost.Id = PostService.GetPosts().LastOrDefault().Id + 1;
                            NewPost.UserId = 1;
                            var result = PostService.CreatePost(NewPost);
                            if (result)
                                await App.Current.MainPage.DisplayAlert("Mensaje", "Su solicitud fue enviada correctamente", "OK");
                            else
                                await App.Current.MainPage.DisplayAlert("Mensaje", "A ocurrido un error.", "OK");
                        }
                        else
                            await App.Current.MainPage.DisplayAlert("Mensaje", "El formato de los campos es incorrecto.", "OK");
                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Mensaje", "El formato de los campos es incorrecto", "OK");
                    }
                    finally
                    {
                        await Initialize();
                        this.IsBusy = false;
                    }
                    //this.NavigationService.Navigate<PostDetailViewModel, Post>(post));
                });
                    
            }
        }

        /// <summary>
        /// Command method to navigate and send parameter post than consulting for edit post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>20.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <return>IMvxCommand result.</return>
        public IMvxCommand ShowEditPostPageCommand
        {
            get
            {
                return new MvxCommand(() =>
                    this.NavigationService.Navigate<PostViewModel, Post>(post));
            }
        }

        /// <summary>
        /// Command method to navigate and send parameter post than consulting for delete post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <return>IMvxCommand result.</return>
        public IMvxCommand ShowDeletePostPageCommand
        {
            get
            {
                return new MvxCommand<Post>(async post =>
                {
                    this.IsBusy = true;
                    try
                    {
                        var result = PostService.DeletePost(Post);
                        if (result)
                            await App.Current.MainPage.DisplayAlert("Mensaje", "Registro Eliminado con Éxito.", "OK");
                        else
                            await App.Current.MainPage.DisplayAlert("Mensaje", "A ocurrido un error.", "OK");
                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Mensaje", "El formato de los campos es incorrecto", "OK");
                    }
                    finally
                    {
                        await Initialize();
                        this.IsBusy = false;
                    };
                });
            }
        }
    }
}

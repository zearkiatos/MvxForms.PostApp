using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PostApp.Interfaces;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.ViewModels
{
    /// <summary>
    /// Class than represent PostViewModel than is the base of all view model classes than herectics of BaseViewModel.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>20.06.2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class PostViewModel : BaseViewModel<Post>
    {
        /// <summary>
        /// Post ViewModel Logic
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>20.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
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
        /// <date>20.06.2018</date>
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

        /// <summary>
        /// Override method to get the parameter.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>20.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <param name="parameter">Post parameter.</param>
        public override void Prepare(Post parameter)
        {
            post = parameter;
        }

        /// <summary>
        /// Method to valid model post.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>Boolean value</returns>
        bool PostValid()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(Post.Title) && !string.IsNullOrEmpty(Post.Body))
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// Command method to navigate and send parameter post than edit.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>21.06.2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <return>IMvxCommand result.</return>
        public IMvxCommand EditPostCommand
        {
            get
            {
                return new MvxCommand<Post>(async post =>
                {
                    this.IsBusy = true;
                    try
                    {
                        if (this.PostValid())
                        {
                            var result = PostService.EditPost(Post);
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
    }
}

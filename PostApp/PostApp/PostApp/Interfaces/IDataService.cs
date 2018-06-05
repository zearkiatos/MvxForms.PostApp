using PostApp.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Interfaces
{
    /// <summary>
    /// Interface for obtain constants of the application than use constants class.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public interface IDataService
    {
        /// <summary>
        /// Method to obtain GetConstants of the application.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>Common constants of the aplication Type Constants.</returns>
        Constants GetConstants();
    }
}

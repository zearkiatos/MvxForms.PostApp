using PostApp.Commons;
using PostApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Services
{
    /// <summary>
    /// Class for obtain constants of the application than use constants class.
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class DataService : IDataService
    {
        /// <summary>
        /// Method to obtain GetConstants of the application.
        /// </summary>
        /// <author>Pedro Capriles</author>
        /// <date>05/06/2018</date>
        /// <email>caprilespe@outlook.com</email>
        /// <returns>Common constants of the aplication Type Constants.</returns>
        public Constants GetConstants()
        {
            return new Constants();
        }
    }
}

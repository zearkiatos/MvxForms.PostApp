using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Commons
{
    /// <summary>
    /// Class for obtain constants of the application
    /// </summary>
    /// <author>Pedro Capriles</author>
    /// <date>05/06/2018</date>
    /// <email>caprilespe@outlook.com</email>
    public class Constants
    {
        #region Constants
            /// <summary>
            /// Aplication version.
            /// </summary>
            public static string appVersion = "v1.6";

            /// <summary>
            /// Software version.
            /// </summary>
            public static string softwareVersion = "1.6.5.18";

            /// <summary>
            /// Build version of the aplication.
            /// </summary>
            public static string buildVersion = "1612018";

            /// <summary>
            ///  Endpoint of rest api for jsonplaceholder data.
            /// </summary>
            public static string placeholderDomain = "https://jsonplaceholder.typicode.com/";

            /// <summary>
            ///  Endpoint of rest api for GitHub data.
            /// </summary>
            public static string gitHubDomain = "https://api.github.com/";
        #endregion
    }
}

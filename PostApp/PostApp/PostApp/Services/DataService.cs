using PostApp.Commons;
using PostApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Services
{
    public class DataService : IDataService
    {
        public Constants GetConstants()
        {
            return new Constants();
        }
    }
}

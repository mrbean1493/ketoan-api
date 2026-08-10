using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketoan.Client
{
    internal class ApiConnectClient
    {
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://ketoan-api.onrender.com/") // URL Server Render
        };
    }
}

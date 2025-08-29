using eazyonrent.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazyonrent.Services
{
    public class GuestServices
    {
        private readonly HttpClient _httpClient;
        public GuestServices()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.BaseApiUrl)
            };
        }

    }
}

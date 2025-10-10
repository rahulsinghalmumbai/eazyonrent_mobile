using eazyonrent.Connection;
using eazyonrent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eazyonrent.Services
{
    class LoginServices
    {
        private readonly HttpClient _httpClient;
        public LoginServices()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.BaseApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
        public async Task<ListerModel> LoginAsync(string usermobile)
        {
            try
            {
                var url = $"{Endpoints.UserLogin}";
                var json = JsonSerializer.Serialize(new { Mobile = usermobile });
                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<ListerModel>(responseBody, options);

                return result ?? new ListerModel
                {
                    ResponseCode = "500",
                    ResponseMessage = "Empty response",
                    ListerId = null,
                    ExistUser = null
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login API Exception: " + ex.Message);
                return new ListerModel
                {
                    ResponseCode = "500",
                    ResponseMessage = "Exception occurred",
                    ListerId = null,
                    ExistUser = null
                };
            }
        }
        public async Task<ListerModel> UpdateProfileAsync(ListerUpdateRequest request)
        {
            try
            {
                using var form = new MultipartFormDataContent();

                // Normal fields (query me na bhejke form-data me bhej dete hai)
                form.Add(new StringContent(request.ListerId.ToString()), "ListerId");
                form.Add(new StringContent(request.CompanyName ?? ""), "CompanyName");
                form.Add(new StringContent(request.Address ?? ""), "Address");
                form.Add(new StringContent(request.Email ?? ""), "Email");
                form.Add(new StringContent(request.Name ?? ""), "Name");
                form.Add(new StringContent(request.City ?? ""), "City");

                // File handle kare
                if (request.DefaultImage is FileResult file)
                {
                    using var stream = await file.OpenReadAsync();
                    var fileContent = new StreamContent(stream);
                    string mimeType = file.FileName.ToLower() switch
                    {
                        string name when name.EndsWith(".jpg") || name.EndsWith(".jpeg") => "image/jpeg",
                        string name when name.EndsWith(".png") => "image/png",
                        string name when name.EndsWith(".gif") => "image/gif",
                        string name when name.EndsWith(".bmp") => "image/bmp",
                        string name when name.EndsWith(".webp") => "image/webp",
                        _ => "application/octet-stream" 
                    };
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);

                    form.Add(fileContent, "ImageFile", file.FileName);
                }

                var response = await _httpClient.PostAsync(Endpoints.EditProfile, form);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<ListerModel>(responseBody, options);

                return result ?? new ListerModel
                {
                    ResponseCode = "500",
                    ResponseMessage = "Empty response",
                    ExistUser = null
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateProfile API Exception: " + ex.Message);
                return new ListerModel
                {
                    ResponseCode = "500",
                    ResponseMessage = "Exception occurred",
                    ExistUser = null
                };
            }
        }

        public async Task<ListerItemProfileResponse> OnLoadProfileItem(int? listerId)
        {
            try
            {
                var url = $"{Endpoints.ProfileItem}?ListerId={listerId}";

                var response = await _httpClient.GetAsync(url); 
                response.EnsureSuccessStatusCode();  

                var responseBody = await response.Content.ReadAsStringAsync();     


                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = JsonSerializer.Deserialize<ListerItemProfileResponse>(responseBody, options);
                return result ?? new ListerItemProfileResponse
                {
                    ResponseCode = "500",
                    ResponseMessage = "Empty response",
                    ItemList = new List<ListerItemProfileResult>()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Profile API Exception: " + ex.Message);
                return new ListerItemProfileResponse
                {
                    ResponseCode = "500",
                    ResponseMessage = "Exception occurred",
                    ItemList = new List<ListerItemProfileResult>()
                };
            }
        }

        public async Task<List<BookingHistoryItem>> GetBookingHistoryAsync(int? listerId)
        {
            try
            {
                if (!listerId.HasValue)
                {
                    return new List<BookingHistoryItem>();
                }

               // var url = $"https://eazyonrent.com/api/Lister/bookHistory?ListerId={32}";
                var url = $"{Endpoints.HistoryItme}?ListerId={listerId}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var historyList = JsonSerializer.Deserialize<List<BookingHistoryItem>>(content);
                    return historyList ?? new List<BookingHistoryItem>();
                }

                return new List<BookingHistoryItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading booking history: {ex.Message}");
                return new List<BookingHistoryItem>();
            }
        }

    }
}

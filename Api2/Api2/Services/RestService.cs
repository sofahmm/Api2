using Api2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api2.Services
{
    public class RestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public List<CatItemModel> CatItems { get; set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
           (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

        }
        public async Task DeleteCatItemAsync(CatItemModel item)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, item.Id));
            try
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(uri);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"@@@@@@@@@@////{ex.Message}");
            }
        }
        public async Task<List<CatItemModel>> GetCatItemAsync()
        {
            CatItems = new List<CatItemModel>();
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    CatItems = JsonSerializer.Deserialize<List<CatItemModel>>(content, serializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return CatItems;
        }
        public async Task SaveCatItemAsync(CatItemModel item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                string json = JsonSerializer.Serialize(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@ Success");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

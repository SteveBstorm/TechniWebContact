using DAL.Entities;
using DAL.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ContactService : IContactService
    {
        private HttpClient _client;

        public ContactService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44338/");
        }

        public IEnumerable<Contact> GetAll()
        {
            using (HttpResponseMessage message = _client.GetAsync("api/contact").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
            }
        }

        public Contact GetById(int id)
        {
            using (HttpResponseMessage message = _client.GetAsync("api/contact/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public void Insert(Contact c)
        {
            string json = JsonConvert.SerializeObject(c);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PostAsync("api/contact", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }


                }
            }
        }

        public void Update(Contact c)
        {
            string json = JsonConvert.SerializeObject(c);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PutAsync("api/contact", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }


                }
            }
        }

        public void Delete(int id)
        {
            using (HttpResponseMessage message = _client.DeleteAsync("api/contact/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(message.StatusCode.ToString());
                }
            }
        }
    }
}

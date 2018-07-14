using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Newtonsoft.Json;
using BasicUwp.Models;
using System;
using Contact = BasicUwp.Models.Contact;

namespace BasicUwp.Services
{
    public class ContactService : IContactService
    {
        // private IContactService _contactServiceImplementation;

        // private params
        private const string ServicePort =
            "http://localhost:53181/api/Contacts";
        // public attributes

        // inherited method

        // public method
        public async Task<IEnumerable<Contact>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServicePort);
                return JsonConvert.DeserializeObject<Contact[]>(json);
            }
        }

        public async Task UpdateAsync(Contact contact)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(contact);
                await client.PutAsync(ServicePort + "/" + contact.Id,
                    new StringContent(json, Encoding.UTF8,
                        "application/json"));
                // MIME: file extension name
            }
        }
    }
}
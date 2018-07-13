using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Newtonsoft.Json;
using BasicUwp.Models;
using System;
using Contact = Windows.ApplicationModel.Contacts.Contact;

namespace BasicUwp.Services
{
    public class ContactService : IContactService
    {
        // private IContactService _contactServiceImplementation;

        // private params
        private const string ServiceEndpoint =
            "http://localhost:53181/api/Contacts";
        // public attributes

        // inherited method

        // public method
        public async Task<IEnumerable<Contact>> ListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(ServiceEndpoint);
                return JsonConvert.DeserializeObject<Contact[]>(json);
            }
        }

        public async Task UpdateAsync(Contact contact)
        {

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(contact);
                await client.PutAsync(ServiceEndpoint + "/" + contact.Id,
                    new StringContent(json, Encoding.UTF8,
                        "application/json"));
            }
        }

        internal Task UpdateAsync(Models.Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
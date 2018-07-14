using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicUwp.Models;

namespace BasicUwp.Services
{
    /// <summary>
    /// <interface>contact_person</interface>
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// list_all_contacts
        /// </summary>
        /// <returns>all_contacts</returns>
        Task<IEnumerable<Contact>> ListAsync();

        /// <summary>
        /// update_contacts
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>contacts</returns>
        Task UpdateAsync(Contact contact);
    }
}
using Newtonsoft.Json;
using System;

namespace BasicUwp.DataService.Models
{
    /// <summary>
    /// <class>contact_person</class>
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// <class>primary_key</class>
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// <class>fist_name</class>
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// <class>last_name</class>
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// <class>birthday</class>
        /// </summary>
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// <clas>link</clas>
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// <class>avatar</class>
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// <class>message</class>
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

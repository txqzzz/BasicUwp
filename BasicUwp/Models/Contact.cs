using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BasicUwp.Models
{
    public class Contact
    {
        /// <summary>
        /// <class>primary_key</class>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <class>fist_name</class>
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// <class>last_name</class>
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// <class>birthday</class>
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// <clas>link</clas>
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// <class>avatar</class>
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// <class>message</class>
        /// </summary>
        public string Message { get; set; }
    }
}

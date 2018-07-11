using Microsoft.EntityFrameworkCore;

namespace BasicUwp.DataService.Models
{
    /// <summary>
    /// <class>data_context</class>
    /// </summary>
    public class DataContext: DbContext
    {
        /// <summary>
        //  data_context_constructor
        /// </summary>
        /// <param name="options">data_context_params</param>
        public DataContext(DbContextOptions<DataContext> options) : base(
            options)
        { }

        /// <summary>
        /// <class>contacts_table</class>
        /// </summary>
        public DbSet<Contact> Contacts{ get; set; }
    }
}

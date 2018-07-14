using System;
using System.Linq;
using System.Threading.Tasks;
using BasicUwp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicUwp.UnitTest
{
    [TestClass]
    public class ContactServiceTest
    {
        [TestMethod]
        public async Task TestListAsync()
        {
            var contactservice = new ContactService();
            // we use tolist() to convert ienumerable into list
            // for several times use
            var contacts = (await contactservice.ListAsync()).ToList();
            // var birthday = new DateTime();
            Assert.AreEqual(12,contacts.Count);
            Assert.AreEqual("Kyle", contacts.First().FirstName);
            Assert.AreEqual("Geordie", contacts[10].LastName);
            //Assert.AreEqual("http://facebook.com/se", contacts.Last().Link);
            //Assert.AreEqual("1999",contacts.First().Birthday);
            //Assert.AreEqual("", contacts[10].Lastname);
            
        }
    }
}
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BasicUwp.Services;
using BasicUwp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BasicUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Contact _lastSelectedContact;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void
            SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var contactService = new ContactService();
            await contactService.UpdateAsync(_lastSelectedContact);
        }

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contactservice = new ContactService();
            var contact = await contactservice.ListAsync();
            var firstname = contact.First().FirstName;
            await new MessageDialog(firstname).ShowAsync();
        }
    }

}

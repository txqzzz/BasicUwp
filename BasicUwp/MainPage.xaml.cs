using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using BasicUwp.Models;
using BasicUwp.Services;

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var contacts = ContactListView.ItemsSource as List<Contact>;
            if (contacts == null)
            {
                var contactService = new ContactService();
                contacts = (await contactService.ListAsync()).ToList();
                ContactListView.ItemsSource = contacts;
            }
            if (e.Parameter is Contact contact)
            {
                //await new MessageDialog(contact.FirstName).ShowAsync();
                //FirstNameTextBox.Text = contact.FirstName;
                //LastNameTextBox.Text = contact.LastName;
                //_lastSelectedContact = contact;
                _lastSelectedContact = contacts.FirstOrDefault(p => p.Id == contact.Id);
                FirstNameTextBox.Text = _lastSelectedContact.FirstName;
                LastNameTextBox.Text = _lastSelectedContact.LastName;
                /*
                 * foreach(var c in contacts){
                 *   if (c.Id == contact.Id){
                 *      _lastSelectedContact = c;
                 *      break;
                 *  }
                 * }
                 */

            }
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshContainer.RequestRefresh();
        }

        private async void RefreshContainer_OnRefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
        {
            using (var deferral = args.GetDeferral())
            {
                var contactService = new ContactService();
                var contacts = (await contactService.ListAsync()).ToList();
                ContactListView.ItemsSource = contacts;
            }
        }

        private void ContactListView_OnItemClick(object sender,
            ItemClickEventArgs e)
        {
            var clickedContact = e.ClickedItem as Contact;
            _lastSelectedContact = clickedContact;

            if (AdaptiveStates.CurrentState == DefaultState)
            {
                FirstNameTextBox.Text = clickedContact.FirstName;
                LastNameTextBox.Text = clickedContact.LastName;
            }
            else
            {
                Frame.Navigate(typeof(DetailPage), clickedContact);
            }
        }

        private async void
            SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            _lastSelectedContact.FirstName = FirstNameTextBox.Text;
            _lastSelectedContact.LastName = LastNameTextBox.Text;

            var contactService = new ContactService();
            await contactService.UpdateAsync(_lastSelectedContact);
        }

        private void UpdateForVisualState(VisualState newState,
            VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState &&
                _lastSelectedContact != null)
            {
                Frame.Navigate(typeof(DetailPage), _lastSelectedContact,
                    new SuppressNavigationTransitionInfo());
            }
        }

        private void AdaptiveStates_OnCurrentStateChanged(object sender,
            VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }
    }
}
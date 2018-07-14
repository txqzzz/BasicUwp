using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BasicUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        //private Contact _contact;
        private void OnBackRequested() {
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var contact = e.Parameter as Contact;

            var backStack = Frame.BackStack;
            var backStackCount = backStack.Count;
            if (backStackCount > 0)
            {
                var masterPageEntry = backStack[backStackCount - 1];
                backStack.RemoveAt(backStackCount - 1);
                
                var modifiedEntry = new PageStackEntry(
                    masterPageEntry.SourcePageType, contact,
                    masterPageEntry.NavigationTransitionInfo); 
                backStack.Add(modifiedEntry);
            }

            FirstNameTextBox.Text = contact.FirstName;
            LastNameTextBox.Text = contact.LastName;

        }
       
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnBackRequested();
        }
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO
        }


        /*private void FirstNameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        { // TODO
            _contact.FirstName = FirstNameTextBox.Text;
            PreviewFirstNameTextBlock.Text = _contact.FirstName;
        }

        private void LastNameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _contact.LastName = LastNameTextBox.Text;
            PreviewLastNameTextBlock.Text = _contact.LastName;
        }*/

        public bool ShouldGoToWideState()
        {
            return Window.Current.Bounds.Width >= 720;
        }
        private void NavigateBackForWideState(bool useTransition)
        {
            NavigationCacheMode = NavigationCacheMode.Disabled;

            if (useTransition)
            {
                Frame.GoBack(new EntranceNavigationTransitionInfo());
            }
            else
            {
                Frame.GoBack(new SuppressNavigationTransitionInfo());//cancel the transition
            }
        }
        private void Window_SizeChanged(object sender,
            WindowSizeChangedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                Window.Current.SizeChanged -= Window_SizeChanged; //cancel the relation
                NavigateBackForWideState(false);
            }
        }

        private void DetailPage_BackRequested(object sender,
            BackRequestedEventArgs e)
        {
            e.Handled = true;
            OnBackRequested();
        }
        private void DetailPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                NavigateBackForWideState(true);
            }

            Window.Current.SizeChanged += Window_SizeChanged; //add relation
        }
        private void DetailPage_OnUnloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }
    }
}

using HomeDash.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HomeDash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void NavLoaded(object sender, RoutedEventArgs e)
		{
			foreach (WinUI.NavigationViewItemBase item in NavView.MenuItems)
			{
				if (item is WinUI.NavigationViewItem && item.Tag.ToString() == "HomePage")
				{
					NavView.SelectedItem = item;
					break;
				}
			}
		}

		private void NavSelectionChanged(WinUI.NavigationView sender, WinUI.NavigationViewSelectionChangedEventArgs e)
		{
			;
		}

		private void NavItemInvoked(WinUI.NavigationView sender, WinUI.NavigationViewItemInvokedEventArgs e)
		{
			if (e.IsSettingsInvoked)
			{
				contentFrame.Navigate(typeof(SettingsPage));
			}
			else
			{
				WinUI.NavigationViewItem item = e.InvokedItemContainer as WinUI.NavigationViewItem;
				if (item != null && item.Tag != null)
				{
					if (item.Tag.ToString() == "HomePage")
					{
						contentFrame.Navigate(typeof(HomePage));
					}
					else if (item.Tag.ToString() == "WeatherPage")
					{
						contentFrame.Navigate(typeof(WeatherPage));
					}
					else if (item.Tag.ToString() == "CatsPage")
					{
						contentFrame.Navigate(typeof(CatsPage));
					}
					else  // default to HomePage
					{
						contentFrame.Navigate(typeof(HomePage));
					}
				}
			}
		}
    }
}

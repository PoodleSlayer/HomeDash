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
using HomeDash.ViewModels;
using HomeDash.IoC;
using Autofac;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HomeDash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private readonly Dictionary<string, Type> pageDict = new Dictionary<string, Type>()
		{
			{ HomePage.PageKey, typeof(HomePage) },
			{ WeatherPage.PageKey, typeof(WeatherPage) },
			{ CatsPage.PageKey, typeof(CatsPage) },
		};

        public MainPage()
        {
            this.InitializeComponent();

			DataContext = AppContainer.Container.Resolve<MainPageViewModel>();
			// pee pee poo poo
			// for awwie <3
			//   /\___/\
			//  (   ._. )

			contentFrame.Navigated += ContentFrame_Navigated;
        }

		private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
		{
			ViewModel.CanGoBack = contentFrame.CanGoBack;

			if (contentFrame.SourcePageType == typeof(SettingsPage))
			{
				NavView.SelectedItem = (WinUI.NavigationViewItem)NavView.SettingsItem;
				NavView.Header = "Settings";
			}
			else if (contentFrame.SourcePageType != null)
			{
				var item = pageDict.FirstOrDefault(x => x.Value == e.SourcePageType);
				NavView.SelectedItem = NavView.MenuItems.OfType<WinUI.NavigationViewItem>().First(x => x.Tag.Equals(item.Key));
				NavView.Header = item.Key;
			}

			if (contentFrame.DataContext is HDViewModel)
			{
				NavView.Header = ((HDViewModel)contentFrame.DataContext).PageTitle;
			}
		}

		private void NavLoaded(object sender, RoutedEventArgs e)
		{
			foreach (WinUI.NavigationViewItemBase item in NavView.MenuItems)
			{
				if (item is WinUI.NavigationViewItem && item.Tag.ToString() == HomePage.PageKey)
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
					if (item.Tag.ToString() == HomePage.PageKey)
					{
						contentFrame.Navigate(typeof(HomePage));
					}
					else if (item.Tag.ToString() == WeatherPage.PageKey)
					{
						contentFrame.Navigate(typeof(WeatherPage));
					}
					else if (item.Tag.ToString() == CatsPage.PageKey)
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

		private void NavBackRequested(WinUI.NavigationView sender, WinUI.NavigationViewBackRequestedEventArgs e)
		{
			if (!contentFrame.CanGoBack)
			{
				return;
			}

			if (NavView.IsPaneOpen && (NavView.DisplayMode == WinUI.NavigationViewDisplayMode.Compact || NavView.DisplayMode == WinUI.NavigationViewDisplayMode.Minimal))
			{
				return;
			}

			contentFrame.GoBack();
		}

		private MainPageViewModel ViewModel
		{
			get => DataContext as MainPageViewModel;
		}
    }
}

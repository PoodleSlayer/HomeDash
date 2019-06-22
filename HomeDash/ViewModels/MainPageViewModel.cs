using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDash.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private bool canGoBack = true;
		public bool CanGoBack
		{
			get => canGoBack;
			set
			{
				if (value != canGoBack)
				{
					canGoBack = value;
					RaisePropertyChanged("CanGoBack");
				}
			}
		}
	}
}

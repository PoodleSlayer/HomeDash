using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDash.ViewModels
{
	public abstract class HDViewModel : ViewModelBase
	{
		public abstract string PageTitle { get; }
	}
}

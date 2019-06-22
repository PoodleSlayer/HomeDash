using Autofac;
using HomeDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDash.IoC
{
	public class AppSetup
	{
		public IContainer CreateContainer()
		{
			var containerBuilder = new ContainerBuilder();
			RegisterDependencies(containerBuilder);
			return containerBuilder.Build();
		}

		private void RegisterDependencies(ContainerBuilder cb)
		{
			cb.RegisterType<MainPageViewModel>().SingleInstance();
			cb.RegisterType<CatsPageViewModel>().SingleInstance();
			cb.RegisterType<HomePageViewModel>().SingleInstance();
			cb.RegisterType<SettingsPageViewModel>().SingleInstance();
			cb.RegisterType<WeatherPageViewModel>().SingleInstance();
		}
	}
}

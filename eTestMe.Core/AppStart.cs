using eTestMe.Core.Domain.ViewModel;
using MvvmCross.Core.ViewModels;

namespace eTestMe.Core
{
	public class AppStart : MvxNavigatingObject, IMvxAppStart
	{
		public AppStart()
		{
		}

		public void Start(object hint = null)
		{
            ShowViewModel<LoginViewModel>();
		}
	}

}

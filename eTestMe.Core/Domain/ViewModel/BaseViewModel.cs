using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;

namespace eTestMe.Core.Domain.ViewModel
{
    public class BaseViewModel : MvxViewModel
	{
		public IMvxLanguageBinder TextSource =>
			new MvxLanguageBinder("", GetType().Name);
	}
}

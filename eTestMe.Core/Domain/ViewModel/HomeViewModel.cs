namespace eTestMe.Core.Domain.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
        }

        public void Init()
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}

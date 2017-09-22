using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using eTestMe.Core.Domain.ViewModel;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace eTestMe.Droid.Views
{
    [Activity(Label = "LoginActivity",
			  LaunchMode = LaunchMode.SingleTask,
              ScreenOrientation = ScreenOrientation.Landscape,
			  WindowSoftInputMode = SoftInput.AdjustResize)]
	public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_layout);

			var userNameLayout = (TextInputLayout)FindViewById(Resource.Id.inputLayoutUsername);
			var passwordLayout = (TextInputLayout)FindViewById(Resource.Id.inputLayoutPassword);

			var set = this.CreateBindingSet<LoginActivity, LoginViewModel>();

			set.Bind(userNameLayout)
			   .For(u => u.Error)
			   .To(vm => vm.UsernameFieldError);
			set.Bind(userNameLayout)
			   .For(u => u.ErrorEnabled)
			   .To(vm => vm.UsernameFieldErrorVisibility);

			set.Bind(passwordLayout)
			 .For(u => u.Error)
			   .To(vm => vm.PasswordFieldError);
			set.Bind(passwordLayout)
			   .For(u => u.ErrorEnabled)
			   .To(vm => vm.PasswordFieldErrorVisibility);

			set.Apply();
		}
	}
}
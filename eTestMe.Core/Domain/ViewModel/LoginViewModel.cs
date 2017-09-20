using System;
using eTestMe.Core.Domain.Service;
using eTestMe.Core.Domain.Service.Data;
using MvvmCross.Core.ViewModels;

namespace eTestMe.Core.Domain.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
	    readonly IUserDataService _userDataService;
		readonly IDialogService _dialogService;

		string _username;
		public string Username
		{
			get => _username;
			set => SetProperty(ref _username, value);
		}

		string _usernameFieldError;
		public string UsernameFieldError
		{
			get => _usernameFieldError;
			set => SetProperty(ref _usernameFieldError, value);
		}

		bool _usernameFieldErrorVisibility;
		public bool UsernameFieldErrorVisibility
		{
			get => _usernameFieldErrorVisibility;
			set => SetProperty(ref _usernameFieldErrorVisibility, value);
		}

		string _password;
		public string Password
		{
			get => _password;
			set => SetProperty(ref _password, value);
		}

		string _passwordFieldError;
		public string PasswordFieldError
		{
			get => _passwordFieldError;
			set => SetProperty(ref _passwordFieldError, value);
		}

		bool _passwordFieldErrorVisibility;
		public bool PasswordFieldErrorVisibility
		{
			get => _passwordFieldErrorVisibility;
			set => SetProperty(ref _passwordFieldErrorVisibility, value);
		}

		public MvxCommand LoginCommand { get; private set; }

		public LoginViewModel(IUserDataService userDataService,
							  IDialogService dialogService)
		{
			_userDataService = userDataService;
			_dialogService = dialogService;
			LoginCommand = new MvxCommand(LoginUser);
		}

		protected override void InitFromBundle(IMvxBundle parameters)
		{
			base.InitFromBundle(parameters);
		}

		async void LoginUser()
		{
			if (ValidateFields())
			{
				try
				{
					await _userDataService.Login(Username, Password);
					ShowViewModel<HomeViewModel>();
				}
				catch (Exception)
				{
					_dialogService.ShowMessage(TextSource.GetText("LoginFailedMessage"));
				}
			}
		}

		bool ValidateFields()
		{
            if (string.IsNullOrEmpty(Username))
            {
                UsernameFieldError = TextSource.GetText("UsernameEmptyMessage");
                UsernameFieldErrorVisibility = true;
                return false;
            }

			UsernameFieldErrorVisibility = false;

			if (string.IsNullOrEmpty(Password))
			{
				Password = null;
				PasswordFieldError = TextSource.GetText("PasswordEmptyMessage");
				PasswordFieldErrorVisibility = true;
				return false;
			}

			PasswordFieldErrorVisibility = false;

			return true;
		}
	}
}
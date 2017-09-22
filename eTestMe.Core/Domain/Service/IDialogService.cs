namespace eTestMe.Core.Domain.Service
{
    public interface IDialogService
	{
		void ShowMessage(string message);
        void ShowError(string error);
	}
}

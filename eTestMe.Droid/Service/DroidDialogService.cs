using System;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using eTestMe.Core.Domain.Service;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using static Android.Support.Design.Widget.Snackbar;

namespace eTestMe.Droid.Service
{
    public class DroidDialogService : IDialogService
	{
		public void ShowError(string error)
		{
			var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
			var act = top.Activity;
			var rootLayout = (View)act.FindViewById(Resource.Id.root_layout);

			Snackbar snackBar = Make(rootLayout, error, LengthShort);

			var view = (SnackbarLayout)snackBar.View;

			view.SetBackgroundResource(Resource.Color.red);

			var param = new CoordinatorLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
			{
				Gravity = (int)GravityFlags.Top,
				TopMargin = 0,
				BottomMargin = 0,
				LeftMargin = 0,
				RightMargin = 0,
			};

			var textView = (TextView)view.FindViewById(Resource.Id.text);

			view.LayoutParameters = param;

			snackBar.Show();
		}

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using eTestMe.Core.Domain.ViewModel;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace eTestMe.Droid.Views
{
    [Activity(Label = "eTestMe",
             LaunchMode = LaunchMode.SingleTask,
             ScreenOrientation = ScreenOrientation.Portrait,
             WindowSoftInputMode = SoftInput.AdjustResize)]
    public class HomeActivity : MvxCachingFragmentCompatActivity<HomeViewModel>
    {
		public DrawerLayout DrawerLayout;

		public MvxActionBarDrawerToggle DrawerToggle { get; private set; }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home_layout);

			DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			DrawerToggle = new MvxActionBarDrawerToggle(this,
														DrawerLayout,
														toolbar,
														Resource.String.drawer_open,
														Resource.String.drawer_close);

			DrawerLayout.AddDrawerListener(DrawerToggle);
			DrawerToggle.SyncState();

		}

		protected override void ShowFragment(string tag, int contentId, Bundle bundle, bool forceAddToBackStack = false, bool forceReplaceFragment = false)
		{
			base.ShowFragment(tag, contentId, bundle, forceAddToBackStack, true);
		}
    }
}
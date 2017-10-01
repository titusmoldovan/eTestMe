using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using eTestMe.Core.Domain.ViewModel;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;

namespace eTestMe.Droid.Views
{
    [MvxFragment(typeof(HomeViewModel), Resource.Id.navigation_frame)]
    [Register("xplatformmenus.droid.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        NavigationView _navigationView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.menu_fragment_layout, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            item.SetCheckable(true);

            Navigate(item.ItemId);

            return true;
        }

        async Task Navigate(int itemId)
        {
            switch (itemId)
            {
                case Resource.Id.nav_home:

                    break;

            }
        }
    }
}
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Ramotion.PaperOnboarding;
using System.Collections.Generic;

namespace SimpleDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.onboarding_main_layout);

            PaperOnboardingPage scr1 = new PaperOnboardingPage("Hotels", "All hotels and hostels are sorted by hospitality rating",
                    Color.ParseColor("#678FB4"), Resource.Drawable.hotels, Resource.Drawable.key);
            PaperOnboardingPage scr2 = new PaperOnboardingPage("Banks", "We carefully verify all banks before add them into the app",
                    Color.ParseColor("#65B0B4"), Resource.Drawable.banks, Resource.Drawable.wallet);
            PaperOnboardingPage scr3 = new PaperOnboardingPage("Stores", "All local stores are categorized for your convenience",
                    Color.ParseColor("#9B90BC"), Resource.Drawable.stores, Resource.Drawable.shopping_cart);

            List<PaperOnboardingPage> elements = new List<PaperOnboardingPage>();
            elements.Add(scr1);
            elements.Add(scr2);
            elements.Add(scr3);

            PaperOnboardingEngine engine = new PaperOnboardingEngine(FindViewById(Resource.Id.onboardingRootView), elements, ApplicationContext);
            engine.RightOut += (s, e) => Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "Piazza Ding", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WashnDry
{
	[Activity(Label = "SetupActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class SetupActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.Setup);

			EditText username = FindViewById<EditText>(Resource.Id.Username);
			EditText password = FindViewById<EditText>(Resource.Id.Password);
			EditText email = FindViewById<EditText>(Resource.Id.Email);
			Button createAccountButton = FindViewById<Button>(Resource.Id.CreateAccountButton);

			createAccountButton.Enabled = true;

			createAccountButton.Click += (object sender, EventArgs e) =>
			{
				Context mContext = Android.App.Application.Context;
				AppPreferences ap = new AppPreferences(mContext);
				ap.saveUsername(username.Text);
				ap.savePassword(password.Text);
				ap.saveEmail(email.Text);
				// save preferences for laundry timing in proper format
				// send data over to server to create a unique model for this username
				StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			};
		}
	}
}

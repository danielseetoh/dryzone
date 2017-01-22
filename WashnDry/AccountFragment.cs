﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace WashnDry
{	

	public class AccountFragment : Fragment
	{
		private List<string> mItems;
		private ListView mListView;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			// Create your fragment here



		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			//return base.OnCreateView(inflater, container, savedInstanceState);


			var rootView = inflater.Inflate(Resource.Layout.Account, container, false);
			//var imageId = Resources.GetIdentifier(
			//	"com.companyname.washndry:drawable/earth",
			//	null, null);




			Spinner laundryFrequencySpinner = rootView.FindViewById<Spinner>(Resource.Id.laundryFrequency_Spinner);
			string firstItem = laundryFrequencySpinner.SelectedItem.ToString();
			laundryFrequencySpinner.ItemSelected += (s,e) => {
				string selected = laundryFrequencySpinner.SelectedItem.ToString();
				if (firstItem.Equals(selected)){
					//Toast.MakeText(Context, "Please make a selection", ToastLength.Short).Show();
				}
				else {
					Toast.MakeText(Context, "Selected: "+selected, ToastLength.Short).Show();
				}

			};

			mItems = new List<string>();
			mListView = rootView.FindViewById<ListView>(Resource.Id.laundryTime_ListView);

			mItems.Add("tale");
			mItems.Add("as");
			mItems.Add("old");
			mItems.Add("as");
			mItems.Add("time");

			ArrayAdapter<string> adaptor = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, mItems);
			mListView.Adapter = adaptor;

			return rootView;
		}
	}
}
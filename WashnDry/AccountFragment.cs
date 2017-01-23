
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
		private ListView mListView;
		private Dictionary<int, string> laundryTime;
		private SparseBooleanArray sparseArray;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment

			var rootView = inflater.Inflate(Resource.Layout.Account, container, false);
			//var imageId = Resources.GetIdentifier(
			//	"com.companyname.washndry:drawable/earth",
			//	null, null);

			// Constructors of other classes to get stored data
			AppPreferences userInfo = new AppPreferences(Context);
			ListData data = new ListData();
			laundryTime = data.getLaundryTimeSlots();

			// retrieving data from db
			List<int> laundryTime_Keys = laundryTime.Keys.ToList();
			List<string> laundryTime_Values = laundryTime.Values.ToList();
				// Dummy Data. By right we should get it from AppPreferences.
				List<bool> laundryTime_Checked = new List<bool>();
				laundryTime_Checked.Add(true);
				laundryTime_Checked.Add(false);
				laundryTime_Checked.Add(true);
				laundryTime_Checked.Add(false);
				laundryTime_Checked.Add(true);

			// retrieving UI elements as objects
			TextView name = rootView.FindViewById<TextView>(Resource.Id.name);
			TextView country = rootView.FindViewById<TextView>(Resource.Id.country);
			Button saveChangesButton = rootView.FindViewById<Button>(Resource.Id.saveChanges);
			Spinner laundryFrequencySpinner = rootView.FindViewById<Spinner>(Resource.Id.laundryFrequency_Spinner);
			mListView = rootView.FindViewById<ListView>(Resource.Id.laundryTime_ListView);

			// Array adaptors for the list view
			ArrayAdapter<string> adaptor = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItemMultipleChoice, laundryTime_Values);
			mListView.Adapter = adaptor;
			mListView.ChoiceMode = Android.Widget.ChoiceMode.Multiple;
			mListView.ItemClick += click_event;
			mListView.ItemSelected += onSelection;

			//sparseArray = rootView.FindViewById<ListView>(Resource.Id.laundryTime_ListView).CheckedItemPositions; // Reads the value of the checkboxes (Whether they are selected or not) and then does someting with the data


			// Assigning values to the various UI elements
			name.Text = userInfo.getUsername();
			country.Text = "Japan, Tokyo";
			for (int i = 0; i < laundryTime_Checked.Count; i++)
			{
				mListView.SetItemChecked(laundryTime_Keys[i], laundryTime_Checked[i]);
			}

			// Laundry Frequency Spinner Selector
			string firstItem = laundryFrequencySpinner.SelectedItem.ToString();
			laundryFrequencySpinner.ItemSelected += (s, e) =>
			{
				string selected = laundryFrequencySpinner.SelectedItem.ToString();
				if (firstItem.Equals(selected))
				{
					//do something
				}
				else {
					Toast.MakeText(Context, "Selected: " + selected, ToastLength.Short).Show();
				}

			};

			saveChangesButton.Click += saveChangesEvent;



			return rootView;
		}

		void onSelection(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			// I cannot get this to work for some reason
			Console.WriteLine("Hello");
			//Toast.MakeText(Context, "selected: " + mItems[e.Position], ToastLength.Short).Show();
		}

		void click_event(object sender, AdapterView.ItemClickEventArgs e)
		{
			//Toast.MakeText(Context,"clicked: " + mItems[e.Position], ToastLength.Short).Show();
			// a method that fires when a list item is clicked
			//for (var i = 0; i < sparseArray.Size(); i++)
			//{
			//	Console.Write(sparseArray.KeyAt(i) + "=" + sparseArray.ValueAt(i) + ",");
			//	Toast.MakeText(Context, "Selected: " + sparseArray.KeyAt(i) + "=" + sparseArray.ValueAt(i), ToastLength.Short).Show();
			//}
			var selectedIndex = e.Position.ToString();
			Toast.MakeText(Context, "clicked: " + selectedIndex, ToastLength.Short).Show();
			//throw new NotImplementedException();
		}

		void saveChangesEvent(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		void saveChangesEvent()
		{
			Toast.MakeText(Context, "changes saved", ToastLength.Short).Show();
		}
}
}

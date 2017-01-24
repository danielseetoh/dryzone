
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
	public static class DataTransformers
	{
		public static string sparseArrayToString(SparseBooleanArray mArray)
		{
			String mString = "";
			for (var i = 0; i < mArray.Size(); i++)
				mString += mArray.ValueAt(i) + ",";

			return mString.TrimEnd(',');
		}
	}
}

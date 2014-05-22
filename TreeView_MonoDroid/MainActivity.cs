using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json.Linq;

namespace TreeView_MonoDroid
{
	[Activity (Label = "TreeView_MonoDroid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private TreeView _treeView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

//			_treeView = FindViewById<TreeView> (Resource.Id.list_view);
//
//			_treeView.InitWithJson ();
//			_treeView.GoToSourceEvent += (object sender, EventArgs e) => {
//
//				var eventArg = e as RowSelectEventArgs;
//				if (eventArg.node.nodeType == "file")
//					Toast.MakeText(this,eventArg.node.title,ToastLength.Short).Show();
//				else
//					Toast.MakeText(this,"This is an empty folder",ToastLength.Short).Show();
//			};
		}
	}
}




























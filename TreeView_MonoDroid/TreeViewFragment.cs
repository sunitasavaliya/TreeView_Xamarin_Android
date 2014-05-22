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
using Newtonsoft.Json.Linq;

namespace TreeView_MonoDroid
{
	public class TreeViewFragment : Fragment
	{

		private int nodeID = 0;
		List<TreeNode> _initialNodes = new List<TreeNode> ();
		TreeView treeView;
		View _current;
		public event EventHandler GoToFileSource;



		public void OnCreate (Bundle savedInstanceState , string Json)
		{
			base.OnCreate (savedInstanceState);
			InitWithJson ();
		}


		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Create your fragment here

			InitWithJson ();

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			_current = inflater.Inflate (Resource.Layout.treeview_fragment_layout, container, false);
		
			treeView = _current.FindViewById <TreeView> (Resource.Id.list_view);
			treeView.InitWithData (_initialNodes);
			treeView.GoToSourceEvent += (object sender, EventArgs e) => {

				if (GoToFileSource != null){
					GoToFileSource(this,e);
				}
			};
			return _current;
		}


		public void InitWithJson ()
		{
			var input = @"{'title': 'Root Folder', 'type':'folder','filepath':'', 'children' :[{'title': 'Subfolder -- 1','type':'folder','filepath':'', 'children' :[{'title': 'Subsubfolder ----A','type':'folder','filepath':'', 'children' :[{'title': 'This file name is very ... very long .... !!! ... This file name is very ... very long .... !!!.... This file name is very ... very long .... !!!This file name is very ... very long .... !!! ... This file name is very ... very long .... !!!.... This file name is very ... very long .... !!!nd', 'type':'file','filepath':'when click file, go to another controller','children' :[]}]},{'title': 'Empty','type':'folder', 'filepath':'','children' :[]}]},{'title': 'Subfolder','type':'folder','filepath':'', 'children' :[{'title': 'Another File','type':'file','filepath':'Go to Another Page ... ', 'children' :[]}]}]}";
			var jsonInput = JObject.Parse (input);
			ConvertJSONObject (null,jsonInput);
		}

		private void ConvertJSONObject (TreeNode parent, JObject input)
		{
			var node = new TreeNode ();

			node.title = input ["title"].ToString ();
			node.nodeType = input ["type"].ToString ();
			node.filePath = input ["filepath"].ToString ();
			node.level = (parent == null) ? 1 : parent.level + 1;
			node.id = nodeID.ToString();
			node.parentId = (parent == null) ? null : parent.id;
			node.hasParent = (parent == null) ? false : true;
			nodeID++;
			var children = input ["children"];
			node.hasChild = true;

			_initialNodes.Add (node);
			foreach ( var c in children)
			{
				ConvertJSONObject (node,JObject.Parse(c.ToString()));
			}



		}



	}
}


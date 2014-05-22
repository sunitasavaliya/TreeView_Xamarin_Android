using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using System.Collections.Generic;


namespace TreeView_MonoDroid
{
	public class TreeViewAdapter : BaseAdapter
	{
		Context _context;
		Cell _cell;
		LayoutInflater _inflater;
		List<TreeNode> _nodes;

		public TreeViewAdapter (Context context, List<TreeNode> nodes) 
		{
			_nodes = nodes;
			_context = context;
		}

		public override int Count {
			get {
				return _nodes.Count;
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return _nodes [position];
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				if (_inflater == null) {
					_inflater = LayoutInflater.FromContext (_context);
				}

				_cell = new Cell ();
				convertView = _inflater.Inflate (Resource.Layout.treeview_cell_layout, parent, false);
				_cell.icon = convertView.FindViewById<ImageView> (Resource.Id.icon);
				_cell.title = convertView.FindViewById <TextView> (Resource.Id.title);

				convertView.SetTag (Resource.Layout.treeview_cell_layout, _cell);
			} else {
				_cell = (Cell)convertView.GetTag (Resource.Layout.treeview_cell_layout);
			}

			if (_nodes [position].hasChild) {
				if (_nodes [position].nodeType == "folder") {
					_cell.icon.SetImageResource (Resource.Drawable.folder);
				}else{
					_cell.icon.SetImageResource (Resource.Drawable.file);
				}
				_cell.icon.Visibility = ViewStates.Visible;
			} else {
				_cell.icon.SetImageResource (Resource.Drawable.folder);
				_cell.icon.Visibility = ViewStates.Visible;
			}

			_cell.title.Text = _nodes [position].title;
			_cell.icon.SetPadding (25*(_nodes[position].level),0,0,0);

			return convertView;
		}
			
		private class Cell :Java.Lang.Object
		{
			public ImageView icon { set; get; }
			public TextView title { set; get; }
		}
	}
}


using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json.Linq;

namespace TreeView_MonoDroid
{

	public class TreeView : ListView
	{
		List<TreeNode> _allNodes;
		List<TreeNode> _currentShowNodes;
		List<TreeNode> _tempNodes;




		Dictionary<string, List<TreeNode>> _deleteMap = new Dictionary<string, List<TreeNode>>();

		TreeViewAdapter _treeViewAdapter;

		public event EventHandler GoToSourceEvent;

		public TreeView ( Context context, Android.Util.IAttributeSet attrs ) : base (context,attrs)
		{
			_allNodes = new List<TreeNode> ();
			_currentShowNodes = new List<TreeNode> ();

			_treeViewAdapter = new TreeViewAdapter (context, _currentShowNodes);
			this.Adapter = _treeViewAdapter;



		}
			

		public void InitWithData (List<TreeNode> allNodes)
		{
			_allNodes.AddRange (allNodes);
			GetFirstLevelElements ();
			_treeViewAdapter.NotifyDataSetChanged ();
		}

		public void GetFirstLevelElements ()
		{
			if (_currentShowNodes == null) {
				_currentShowNodes = new List<TreeNode> ();
			} else {
				_currentShowNodes.Clear ();
			}

			foreach (var n in _allNodes)
			{
				if (n.level == 1) {
					_currentShowNodes.Add (n);
				}
			}
		}

		private List<TreeNode> GetChildNodesFromAllById (string parentId)
		{
			ClearTempNodes ();
			foreach (var n in _allNodes)
			{
				if(n.parentId != null)
				{
					if (n.parentId.ToLower () == parentId.ToLower ())
						_tempNodes.Add (n);
				}

			}
			return _tempNodes;
		}

		private List<TreeNode> GetChildNodesFromCurrentById (string parentId)
		{
			ClearTempNodes ();
			foreach (var n in _currentShowNodes) {
				if (n.parentId != null)
				{
					if (n.parentId.ToLower () == parentId.ToLower ())
						_tempNodes.Add (n);
				}

			}
			return _tempNodes;
		}


		private Boolean DelAllChildNodesByParentId (string parentId)
		{
			List<TreeNode> childNodes = GetChildNodesFromCurrentById (parentId);
			List<TreeNode> delChildNodes = null;

			if (_deleteMap.ContainsKey(parentId))
			{
				delChildNodes = _deleteMap [parentId];
			}

			if (delChildNodes == null) {
				delChildNodes = new List<TreeNode> ();
				_deleteMap.Add (parentId, delChildNodes);
			} else {
				delChildNodes.Clear ();
			}

			foreach (var c in childNodes) {
				if (c.hasChild && c.fold)
					delChildNodes.Add (c);
			}

			if (delChildNodes.Count > 0)
			{
				foreach ( var c in delChildNodes)
					DelAllChildNodesByParentId (c.id);
			}
				
			DelDirechtChildElementsByParentId (parentId); 
			return true;
		}

		private Boolean DelDirechtChildElementsByParentId (String parentId)
		{
			if (_currentShowNodes == null || _currentShowNodes.Count == 0)
				return false;

			for ( var i = _currentShowNodes.Count -1; i>=0; i--)
			{
				if (_currentShowNodes[i].parentId != null)
				{
					if (_currentShowNodes[i].parentId.ToLower() == parentId.ToLower())
					{
						_currentShowNodes [i].fold = false;
						_currentShowNodes.RemoveAt (i);
					}
				}

			}
			return true;
		}


		public override Boolean PerformItemClick (Android.Views.View view, int position, long id)
		{
			var node = _currentShowNodes[position];
			if (node.hasChild) {
				if (!node.fold) {
					_currentShowNodes.InsertRange (position + 1, GetChildNodesFromAllById (node.id));
				} else {
					var success = DelAllChildNodesByParentId (node.id);
					if (!success)
						return false;
				}
				node.fold = !node.fold;
				_treeViewAdapter.NotifyDataSetChanged ();
			}
				

			if ( GetChildNodesFromAllById(_currentShowNodes[position].id).Count == 0)
			{
				if (GoToSourceEvent != null) {


					GoToSourceEvent (this, new RowSelectEventArgs () {node = _currentShowNodes[position] });
				}
					
			}
			return true;
		}


		// helper functions

		private void ClearTempNodes ()
		{
			if (_tempNodes == null) {
				_tempNodes = new List<TreeNode> ();
			} else {
				_tempNodes.Clear ();
			}
		}
	}

	public class RowSelectEventArgs : EventArgs
	{
		public TreeNode node { set; get; }
	}

}














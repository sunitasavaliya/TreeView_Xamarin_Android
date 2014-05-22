using System;

namespace TreeView_MonoDroid
{
	public class TreeNode : Java.Lang.Object
	{
		public String id { set; get; }
		public String title { set; get; }
		public String parentId { set; get; }
		public String nodeType { set; get; }
		public String filePath { set; get; }

		public Boolean hasParent  = false;
		public Boolean hasChild  = false;
		public Boolean childShow = false;
		public Boolean fold = false;

		public int level = -1;
	
		public TreeNode (){}
	}
}


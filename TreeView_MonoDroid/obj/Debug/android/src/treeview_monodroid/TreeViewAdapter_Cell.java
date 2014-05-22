package treeview_monodroid;


public class TreeViewAdapter_Cell
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TreeView_MonoDroid.TreeViewAdapter/Cell, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TreeViewAdapter_Cell.class, __md_methods);
	}


	public TreeViewAdapter_Cell () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TreeViewAdapter_Cell.class)
			mono.android.TypeManager.Activate ("TreeView_MonoDroid.TreeViewAdapter/Cell, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

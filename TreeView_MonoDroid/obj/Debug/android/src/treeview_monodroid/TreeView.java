package treeview_monodroid;


public class TreeView
	extends android.widget.ListView
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_performItemClick:(Landroid/view/View;IJ)Z:GetPerformItemClick_Landroid_view_View_IJHandler\n" +
			"";
		mono.android.Runtime.register ("TreeView_MonoDroid.TreeView, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TreeView.class, __md_methods);
	}


	public TreeView (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == TreeView.class)
			mono.android.TypeManager.Activate ("TreeView_MonoDroid.TreeView, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public TreeView (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == TreeView.class)
			mono.android.TypeManager.Activate ("TreeView_MonoDroid.TreeView, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public TreeView (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == TreeView.class)
			mono.android.TypeManager.Activate ("TreeView_MonoDroid.TreeView, TreeView_MonoDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean performItemClick (android.view.View p0, int p1, long p2)
	{
		return n_performItemClick (p0, p1, p2);
	}

	private native boolean n_performItemClick (android.view.View p0, int p1, long p2);

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

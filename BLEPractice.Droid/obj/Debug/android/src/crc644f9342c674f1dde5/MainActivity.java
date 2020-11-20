package crc644f9342c674f1dde5;


public class MainActivity
	extends crc648d9adcc6b772c31e.MvxAppCompatApplication_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:()V:GetOnCreateHandler\n" +
			"";
	}

	public MainActivity ()
	{
		mono.MonoPackageManager.setContext (this);
	}


	public void onCreate ()
	{
		n_onCreate ();
	}

	private native void n_onCreate ();

	private java.util.ArrayList refList;
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

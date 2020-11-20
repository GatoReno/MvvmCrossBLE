package crc642c51e6dc03a22590;


public class MainPageView
	extends crc642c51e6dc03a22590.BaseView_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("BLEPractice.Droid.Views.MainPageView, BLEPractice.Droid", MainPageView.class, __md_methods);
	}


	public MainPageView ()
	{
		super ();
		if (getClass () == MainPageView.class)
			mono.android.TypeManager.Activate ("BLEPractice.Droid.Views.MainPageView, BLEPractice.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

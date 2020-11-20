package crc642c51e6dc03a22590;


public class BaseView_1
	extends crc648d9adcc6b772c31e.MvxAppCompatActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("BLEPractice.Droid.Views.BaseView`1, BLEPractice.Droid", BaseView_1.class, __md_methods);
	}


	public BaseView_1 ()
	{
		super ();
		if (getClass () == BaseView_1.class)
			mono.android.TypeManager.Activate ("BLEPractice.Droid.Views.BaseView`1, BLEPractice.Droid", "", this, new java.lang.Object[] {  });
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

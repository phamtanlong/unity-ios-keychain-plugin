using UnityEngine;
using System.Runtime.InteropServices;

public class KeyChain 
{	
	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void initialize(string serviceID);
	[DllImport("__Internal")] private static extern string getString(string key, string defaultValue);
	[DllImport("__Internal")] private static extern void setString(string key, string value);	
	[DllImport("__Internal")] private static extern void deleteKey(string key);	
	[DllImport("__Internal")] private static extern void printOutAllItems();
	#endif

	public static void Initialize()
	{
		#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string bundleID = Application.identifier;
			initialize(bundleID); 
			printOutAllItems();
		}
		#endif
	}

	public static string GetString(string key, string defaultValue = "")
	{
		#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{ return getString(key, defaultValue); }
		else
		{ return ""; }
		#else
		return "";
		#endif
	}

	public static void SetString(string key, string value)
	{ 
		#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{ setString(key, value); }
		#endif
	}

	public static void DeleteKey(string key)
	{
		#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{ deleteKey(key); }
		#endif
	}

	public static void PrintOutAllKeys()
	{
		#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{ printOutAllItems(); }
		#endif
	}
}

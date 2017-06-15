using UnityEngine;
using System.Runtime.InteropServices;

public class KeyChain 
{	
	#if UNITY_IPHONE || UNITY_STANDALONE_OSX

	[DllImport("__Internal")] private static extern void initialize(string serviceID);
	[DllImport("__Internal")] private static extern string getString(string key, string defaultValue);
	[DllImport("__Internal")] private static extern void setString(string key, string value);	
	[DllImport("__Internal")] private static extern void deleteKey(string key);	
	[DllImport("__Internal")] private static extern void printOutAllItems();

	#endif

	public static void Initialize()
	{
		#if UNITY_IPHONE || UNITY_STANDALONE_OSX

		string bundleID = Application.identifier;
		initialize(bundleID); 
		printOutAllItems();

		#else
		throw new System.NotImplementedException();
		#endif
	}

	public static string GetString(string key, string defaultValue = "")
	{
		#if UNITY_IPHONE || UNITY_STANDALONE_OSX 
		return getString(key, defaultValue); 
		#else
		throw new System.NotImplementedException();
		#endif
	}

	public static void SetString(string key, string value)
	{ 
		#if UNITY_IPHONE || UNITY_STANDALONE_OSX 
		setString(key, value); 
		#else
		throw new System.NotImplementedException();
		#endif
	}

	public static void DeleteKey(string key)
	{
		#if UNITY_IPHONE || UNITY_STANDALONE_OSX  
		deleteKey(key); 
		#else
		throw new System.NotImplementedException();
		#endif
	}

	public static void PrintOutAllKeys()
	{
		#if UNITY_IPHONE || UNITY_STANDALONE_OSX 
		printOutAllItems();
		#else
		throw new System.NotImplementedException();
		#endif
	}
}

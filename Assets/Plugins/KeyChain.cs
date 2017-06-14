using UnityEngine;
using System.Runtime.InteropServices;

public class KeyChain 
{	
	#if UNITY_IPHONE || UNITY_STANDALONE_OSX
	
	[DllImport("__Internal")]
	private static extern string getKeyChainUser();
	
	public static string BindGetKeyChainUser()
	{
		return getKeyChainUser();
	}
	
	[DllImport("__Internal")]
	private static extern void setKeyChainUser(string userId, string uuid);
	
	public static void BindSetKeyChainUser(string userId, string uuid)
	{
		setKeyChainUser(userId, uuid);
	}
	
	[DllImport("__Internal")]
	private static extern void deleteKeyChainUser();
	
	public static void BindDeleteKeyChainUser()
	{
		deleteKeyChainUser();
	}
	
	[DllImport("__Internal")]
	private static extern void setJSONData(string jsonString);	
	
	public static void StoreJSONData(string jsonString)
	{
		setJSONData(jsonString);
	}

	[DllImport("__Internal")]
	private static extern string getJSONData();

	public static string GetJSONData()
	{
		return getJSONData();
	}

	#endif
}

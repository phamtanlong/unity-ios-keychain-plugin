using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataMessenger 
{
	public static System.Action<SceneData> OnSceneDataUpdated;

	public static void SceneDataUpdated(SceneData newData)
	{
		if(OnSceneDataUpdated != null)
		{ OnSceneDataUpdated(newData); }
	}
}
using UnityEngine;

public class DataSaver : MonoBehaviour 
{
	private void Start()
	{
		ListenToEvents();
		LoadData();
	}

	private void ListenToEvents()
	{
		DataMessenger.OnSceneDataUpdated += SceneDataUpdated;
	}

	private void LoadData()
	{
		string jsonString = KeyChain.GetJSONData();
		if(string.IsNullOrEmpty(jsonString))
		{ return; }

		SceneData loadedData = JsonUtility.FromJson<SceneData>(jsonString);
		SceneDataManager.ReplaceSceneData(loadedData);
	}

	private void SceneDataUpdated(SceneData sceneData)
	{
		string jsonString = JsonUtility.ToJson(sceneData);
		KeyChain.StoreJSONData(jsonString);
	}
}
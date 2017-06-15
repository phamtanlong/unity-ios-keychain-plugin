using UnityEngine;

public class DataSaver : MonoBehaviour 
{
	private const string _sceneDataID = "SceneData";

	private void Start()
	{
		ListenToEvents();
		Initialize();
		LoadData();
	}

	private void ListenToEvents()
	{
		DataMessenger.OnSceneDataUpdated += SceneDataUpdated;
	}

	private void Initialize()
	{
		KeyChain.Initialize();
	}

	private void LoadData()
	{
		string jsonString = KeyChain.GetString(_sceneDataID);
		if(string.IsNullOrEmpty(jsonString))
		{ return; }

		SceneData loadedData = JsonUtility.FromJson<SceneData>(jsonString);
		SceneDataManager.ReplaceSceneData(loadedData);
	}

	private void SceneDataUpdated(SceneData sceneData)
	{
		string jsonString = JsonUtility.ToJson(sceneData);
		KeyChain.SetString(_sceneDataID, jsonString);
	}
}
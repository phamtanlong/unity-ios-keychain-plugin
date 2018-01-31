using UnityEngine;

public class SceneDataManager : MonoBehaviour
{
	private static SceneData _sceneData = null;

	public static void ReplaceSceneData(SceneData sceneData)
	{
		_sceneData = sceneData;
		DataMessenger.SceneDataUpdated(_sceneData);
	}

	public static void UpdateBackgroundColor(Color newColor)
	{
		_sceneData.BackgroundColor = newColor;
		DataMessenger.SceneDataUpdated(_sceneData);
	}

	private void Awake()
	{
		ReplaceSceneData(new SceneData());
	}
}
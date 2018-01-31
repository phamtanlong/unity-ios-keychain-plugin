using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour 
{
	private Camera localCamera = null;

	private void Awake()
	{
		StoreMembers();
		ListenToEvents();
	}

	private void StoreMembers()
	{
		this.localCamera = GetComponent<Camera>();
	}

	private void ListenToEvents()
	{
		DataMessenger.OnSceneDataUpdated += SceneDataUpdated;
	}

	private void SceneDataUpdated(SceneData newData)
	{
		this.localCamera.backgroundColor = newData.BackgroundColor;
	}
}
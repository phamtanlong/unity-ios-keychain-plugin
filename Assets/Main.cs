using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	string currentUUID = "";
	string saveUUID = "";

	void Update () {}

	void OnGUI () {

		GUILayoutOption[] ops = new GUILayoutOption[]{};

		GUI.skin.label.fontSize = 30;
		GUI.skin.textArea.fontSize = 30;
		GUI.skin.button.fontSize = 30;

		if (GUILayout.Button ("UUID", ops)) {
			currentUUID = SystemInfo.deviceUniqueIdentifier;
			Debug.Log ("CurrentUUID: [" + currentUUID + "]");
		}
		
		GUILayout.TextArea (currentUUID, ops);

		if (GUILayout.Button ("Load UUID", ops)) {
			saveUUID = KeyChain.BindGetKeyChainUser ();
			Debug.Log ("LoadUUID: [" + saveUUID + "]");
		}

		GUILayout.TextArea (saveUUID, ops);

		if (GUILayout.Button ("Save UUID", ops)) {
			currentUUID = SystemInfo.deviceUniqueIdentifier;
			KeyChain.BindSetKeyChainUser ("0", currentUUID);
			Debug.Log ("SaveUUID: [" + currentUUID + "]");
		}

		if (GUILayout.Button ("Delete UUID", ops)) {
			KeyChain.BindDeleteKeyChainUser ();
		}

	}
}

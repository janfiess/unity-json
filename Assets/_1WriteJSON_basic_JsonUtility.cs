// Transform objects to a JSON-formatted string and save it into a file.
// Only works from Unity 5.3 on with its new JSONUtility class.
// basic -  without Object arrays
// creating {"name":"Fabi","level":4711,"tags":["Beginner","Fast"]}

using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class _1WriteJSON_basic_JsonUtility : MonoBehaviour {
	void Start () {
		
		/**
		 * 1. Create some objects and store them into a JSON string
		 */

		ObjectData myObject = new ObjectData();
		myObject.name = "Fabi";
		myObject.level = 4711;
		List<string> tags =new List<string>();
		tags.Add ("Beginner");
		tags.Add ("Fast");
		myObject.tags = tags.ToArray();

		string jsonString = JsonUtility.ToJson(myObject);
		Debug.Log (jsonString);
		// logs {"name":"Fabi","level":4711,"tags":["Beginner","Fast"]}

		/**
		 * 2. Save JSON-formatted string in text file
		 */

		//System.IO.File.WriteAllText (Application.persistentDataPath + "/saveJSON.json");
		System.IO.File.WriteAllText (Application.dataPath + "/Resources/Json_basic.json", jsonString);
	}
}

[Serializable]
public class ObjectData {
	public string name;
	public int level;
	public string [] tags;
}
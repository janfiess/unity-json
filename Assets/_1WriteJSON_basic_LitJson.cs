// Transform objects to a JSON-formatted string and save it into a file.
// using LitJson 
// basic - without Object arrays
// creating {"name":"Fabi","level":4711,"tags":["Beginner","Fast"]}

using UnityEngine;
using LitJson;
using System.IO;
using System.Collections.Generic;

public class _1WriteJSON_basic_LitJson : MonoBehaviour {
	void Start () {

		/**
		 * 1. Create some objects and store them into a JSON string
		 */

		List<string> tags =new List<string>();
		tags.Add ("Beginner");
		tags.Add ("Fast");
		string [] tags_array = tags.ToArray();

		ObjectData_LitJson mainObject = new ObjectData_LitJson ("Fabi", 4711, tags_array);

		JsonData generatedJsonString = JsonMapper.ToJson (mainObject);
		Debug.Log (generatedJsonString);
		// logs {"name":"Fabi","level":4711,"tags":["Beginner","Fast"]}

		/**
		 * 2. Save JSON-formatted string in text file
		 */

		File.WriteAllText(Application.dataPath+"/Resources/Json_basic.json", generatedJsonString.ToString());
	}
}

public class ObjectData_LitJson{
	public string name;
	public int level;
	public string [] tags;
	public ObjectData_LitJson(string name, int level, string[] tags){
		this.name = name;
		this.level = level;
		this.tags = tags;
	}
}
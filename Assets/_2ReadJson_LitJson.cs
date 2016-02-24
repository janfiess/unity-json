// Read JSON File and transform the string to objects
// using LitJson

using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Collections.Generic;

public class _2ReadJson_LitJson : MonoBehaviour {
	void Start () {

		/**
		 * 1. Fetch JSON-formatted string from text file
		 */

		// string jsonString = "{ \"name\": \"Fabi\", \"level\": \"4711\", \"tags\": [\"Beginner\",\"Fast\"] }";
		string jsonString = File.ReadAllText (Application.dataPath + "/Resources/Json_basic.json");

		/**
		 * 2. Transform JSON-formatted text into object
		 */

		JsonData myObject = JsonMapper.ToObject (jsonString);

		List<string> tagsList = new List<string> ();
		for (int i=0; i < myObject ["tags"].Count; i++) {
			tagsList.Add(myObject["tags"][i].ToString());
		}

		foreach (string tag in tagsList) {
			Debug.Log ("Print List Item: " + tag); // logs Beginner, then Fast
		}
	}
}
// Read JSON File and transform the string to objects
// Only works from Unity 5.3 on with its new JSONUtility class.

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class _2ReadJson_JsonUtility : MonoBehaviour{
	private void Start (){

		/**
		 * 1. Fetch JSON-formatted string from text file
		 */

		// string jsonString = "{ \"name\": \"Fabi\", \"level\": \"4711\", \"tags\": [\"Beginner\",\"Fast\"] }";
		string jsonString = File.ReadAllText (Application.dataPath + "/Resources/Json_basic.json");
		// Debug.Log(Application.dataPath);

		/**
		 * 2. Transform JSON-formatted text into object
		 */

		ObjectData myObject = JsonUtility.FromJson<ObjectData> (jsonString);
	
		Debug.Log ("Whole JSON String: "+jsonString);
		foreach (string tag in myObject.tags) {
			Debug.Log ("Print List Item: " + tag); // logs Beginner, then Fast
		}
	}
}
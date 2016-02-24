// Transform objects to a JSON-formatted string and save it into a file.
// Only works from Unity 5.3 on with its new JSONUtility class.
// storing nested objects in array
// creating {"highscore":[{"name":"MagicMike","scores":8828},{"name":"MadMax","scores":4711}]}

using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class _3WriteJson_ObjectArray_JsonUtility : MonoBehaviour {
	public MainObjectData_JsonUtility mainObject;
	public InnerObjectData_JsonUtility innerObject;

	List <InnerObjectData_JsonUtility> objectList = new List<InnerObjectData_JsonUtility> ();


	public InnerObjectData_JsonUtility createSubObject(string name, int scores){
		InnerObjectData_JsonUtility myInnerObject = new  InnerObjectData_JsonUtility();
		myInnerObject.name = name;
		myInnerObject.scores = scores;
		return myInnerObject;
	}

	void Start () {
		
		/**
		 * 1. Create some objects and store them into a JSON string
		 */

		objectList.Add (createSubObject ("MagicMike", 8828));
		objectList.Add (createSubObject ("MadMax", 4711));

		mainObject.highscore = objectList.ToArray();

		string jsonString = JsonUtility.ToJson(mainObject);
		Debug.Log ("generated JsonString: " + jsonString);
		// logs {"highscore":[{"name":"MagicMike","scores":8828},{"name":"MadMax","scores":4711}]}

		/**
		 * 2. Save JSON-formatted string in text file
		 */

		File.WriteAllText(Application.dataPath+"/Resources/Json_ObjectArray.json", jsonString);
	}
}

[Serializable]
public class MainObjectData_JsonUtility {
	public InnerObjectData_JsonUtility [] highscore;
}

[Serializable]
public class InnerObjectData_JsonUtility {
	public string name;
	public int scores;
}
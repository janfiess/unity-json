// Reading an array with nested object stored in a JSON-formatted text file. Changing objects and adding more objects
// using JsonUtility
// At start: {"highscore":[{"name":"BadBoy","scores":4711}]} 
// After step 5: {"highscore":[{"name":"BadBoy","scores":4711},{"name":"MagicMike","scores":8828}]}
// After step 7: {"highscore":[{"name":"BadBoy","scores":4712},{"name":"MadMax","scores":1234},{"name":"Amazing Angus","scores":6454},{"name":"Good Guys","scores":1936}]}

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class _4Update_ObjectArray_JsonUtility : MonoBehaviour {
	void Start () {
		
		/**
		 * 1. Fetch text from file
		 */

		string jsonString = File.ReadAllText (Application.dataPath + "/Resources/Json_UpdateObjectArray.json");
		Debug.Log ("JSON-String before: " + jsonString);
		// logs {"highscore":[{"name":"BadBoy","scores":4711}]}

		/**
		 * 2. Transform JSON formatted text into object
		 */

		MainObjectData_upd_JsonUtility mainObject = JsonUtility.FromJson<MainObjectData_upd_JsonUtility> (jsonString);
		Debug.Log("Size of array before: " + mainObject.highscore.Length); // 1

		List<string> name_list = new List<string> ();
		List<int> scores_list = new List<int> ();

		for (int i=0; i < mainObject.highscore.Length; i++) {
			name_list.Add(mainObject.highscore[i].name.ToString());
			scores_list.Add(int.Parse(mainObject.highscore[i].scores.ToString()));
		}

		/**
		 * 3. Enlarge the JSON Object
		 */

		name_list.Add ("MadMax");
		scores_list.Add (1234);

		/**
		 * 4. Change entries in JSON object
		 * BadBoy bekommt einen Extrapunkt
		 */

		int position=-1;
		for (int i = 0; i < name_list.Count; i++) {
			if (name_list [i] == "BadBoy") {
				position = i;
				break;
			}
		}
		if (position > -1)
			scores_list [position] += 1;

		/**
		 * 5. Create some nested objects in an array again and store them back into a JSON string
		 */

		List<InnerObjectData_upd_JsonUtility> innerObjects_list = new List<InnerObjectData_upd_JsonUtility> ();
		for (int i = 0; i < name_list.Count; i++) {
			InnerObjectData_upd_JsonUtility myInnerObject = new  InnerObjectData_upd_JsonUtility();
			myInnerObject.name = name_list[i];
			myInnerObject.scores = scores_list[i];
			innerObjects_list.Add (myInnerObject);
		}

		mainObject.highscore = innerObjects_list.ToArray();

		jsonString = JsonUtility.ToJson(mainObject);
		Debug.Log ("JSON-String thereafter: " + jsonString);
		// logs {"highscore":[{"name":"BadBoy","scores":4711},{"name":"MagicMike","scores":8828}]}
		Debug.Log("Size of array thereafter: " + mainObject.highscore.Length); // 2

		/**
		 * 6. Save JSON-formatted string in text file
		 */

		//File.WriteAllText(Application.dataPath+"/Resources/Json_UpdateObjectArray.json", jsonString.ToString());

		/**
		 * 7. Quickly adding more objects without touching existing contents, thus faster (not possible with LitJson)
		 */

		mainObject = JsonUtility.FromJson<MainObjectData_upd_JsonUtility> (jsonString);
		List<InnerObjectData_upd_JsonUtility> someList = new List<InnerObjectData_upd_JsonUtility>(mainObject.highscore);

		someList.Add (createSubObject ("Amazing Angus", 6454));
		someList.Add (createSubObject ("Good Guys", 1936));

		mainObject.highscore = someList.ToArray();

		jsonString = JsonUtility.ToJson(mainObject);
		Debug.Log ("Quickly added one more object without analyzing contents: " + jsonString);
		// logs {"highscore":[{"name":"BadBoy","scores":4712},{"name":"MadMax","scores":1234},{"name":"Amazing Angus","scores":6454},{"name":"Good Guys","scores":1936}]}
		Debug.Log("Size of array thereafter: " + mainObject.highscore.Length); // 4

		/**
		 * 8. Save JSON-formatted string in text file
		 */

		//File.WriteAllText(Application.dataPath+"/Resources/Json_UpdateObjectArray.json", jsonString.ToString());
	}

	public InnerObjectData_upd_JsonUtility createSubObject(string name, int scores){
		InnerObjectData_upd_JsonUtility myInnerObject = new  InnerObjectData_upd_JsonUtility();
		myInnerObject.name = name;
		myInnerObject.scores = scores;
		return myInnerObject;
	}
}

[Serializable]
public class MainObjectData_upd_JsonUtility {
	public InnerObjectData_upd_JsonUtility [] highscore;
}

[Serializable]
public class InnerObjectData_upd_JsonUtility {
	public string name;
	public int scores;
}
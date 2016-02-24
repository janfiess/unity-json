// Reading an array with nested object stored in a JSON-formatted text file. Changing objects and adding more objects
// using LitJson
// At start: {"highscore":[{"name":"BadBoy","scores":4711}]}
// After step 5: {"highscore":[{"name":"BadBoy","scores":4712},{"name":"MadMax","scores":1234}]}

using UnityEngine;
using LitJson;
using System.IO;
using System.Collections.Generic;


public class _4Update_ObjectArray_LitJson : MonoBehaviour {
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

		JsonData myObject = JsonMapper.ToObject (jsonString);
		Debug.Log("Size of array before: " + myObject["highscore"].Count); // 1

		List<string> name_list = new List<string> ();
		List<int> scores_list = new List<int> ();

		for (int i=0; i < myObject ["highscore"].Count; i++) {
			name_list.Add(myObject["highscore"][i]["name"].ToString());
			scores_list.Add(int.Parse(myObject["highscore"][i]["scores"].ToString()));
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

		List<InnerObjectData_upd_LitJson> innerObjects_list = new List<InnerObjectData_upd_LitJson> ();
		for (int i = 0; i < name_list.Count; i++) {
			innerObjects_list.Add (new InnerObjectData_upd_LitJson (name_list [i], scores_list [i]));
		}
		InnerObjectData_upd_LitJson[] innerObjects_array = innerObjects_list.ToArray();

		MainObjectData_upd_LitJson_new mainObject = new MainObjectData_upd_LitJson_new (innerObjects_array);

		jsonString = JsonMapper.ToJson (mainObject);
		Debug.Log ("JSON-String thereafter: " + jsonString);
		// logs {"highscore":[{"name":"BadBoy","scores":4712},{"name":"MadMax","scores":1234}]}
		myObject = JsonMapper.ToObject (jsonString);
		Debug.Log("Size of array thereafter: " + myObject["highscore"].Count); // 2

		/**
		 * 6. Save JSON-formatted string in text file
		 */

		//File.WriteAllText(Application.dataPath+"/Resources/Json_UpdateObjectArray.json", jsonString.ToString());

		/**
		 * 7. Quickly adding more objects without touching existing contents, thus faster is NOT possible with LitJson, however with JsonUtility.
		 * 
		 * Reason: Using JsonUtility, you work with instances of the classes MainObjectData and SubObjectData for both
		 * encoding and decoding a JSON-formatted string. When decoding the string you get an array of the type InnerObjectData.
		 * Thus you can simply add more instances of the class InnerObjectData to this list/array. So you needn't analyse the
		 * whole data structure when you simply want to add more objects without changing the rest.
		 * Using LitJson you only need the instances of the classes MainObjectData and SubObjectData for encoding the 
		 * JSON-formatted string, but NOT for decoding. When decoding you don't get an array of the type InnerObjectData. 
		 * You get an object of the type LitJson.JsonData. It's not possible to add instances of InnerObjectData to it.
		 * At best, you get a useless string like this: {"highscore":[{"name":"BadBoy","scores":4711}"{\"name\":\"MagicMike\",\"scores\":8828}"]}
		 */

	}
}

public class MainObjectData_upd_LitJson_new{
	public InnerObjectData_upd_LitJson [] highscore;
	public MainObjectData_upd_LitJson_new(InnerObjectData_upd_LitJson [] highscore){
		this.highscore = highscore;
	}
}

public class InnerObjectData_upd_LitJson{
	public string name;
	public int scores;
	public InnerObjectData_upd_LitJson(string name, int scores){
		this.name = name;
		this.scores = scores;
	}
}
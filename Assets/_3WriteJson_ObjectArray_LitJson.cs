// Transform objects to a JSON-formatted string and save it into a file.
// using LitJson
// storing nested objects in array
// creating {"highscore":[{"name":"MagicMike","scores":8828},{"name":"MadMax","scores":4711}]}

using UnityEngine;
using LitJson;
using System.IO;
using System.Collections.Generic;


public class _3WriteJson_ObjectArray_LitJson : MonoBehaviour {
	void Start () {

		/**
		 * 1. Create some nested objects in an array and store them into a JSON string
		 */

		List<InnerObjectData_LitJson> innerObjects_list = new List<InnerObjectData_LitJson> ();
		innerObjects_list.Add(new InnerObjectData_LitJson ("MagicMike", 8828));
		innerObjects_list.Add(new InnerObjectData_LitJson ("MadMax", 4711));
		InnerObjectData_LitJson[] innerObjects_array = innerObjects_list.ToArray();

		MainObjectData_LitJson mainObject = new MainObjectData_LitJson (innerObjects_array);

		JsonData jsonString = JsonMapper.ToJson (mainObject);
		Debug.Log ("generated JsonString: "+ jsonString);
		// logs {"highscore":[{"name":"MagicMike","scores":8828},{"name":"MadMax","scores":4711}]}

		/**
		 * 2. Save JSON-formatted string in text file
		 */

		File.WriteAllText(Application.dataPath+"/Resources/Json_ObjectArray.json", jsonString.ToString());
	}
}

public class MainObjectData_LitJson{
	public InnerObjectData_LitJson [] highscore;
	public MainObjectData_LitJson(InnerObjectData_LitJson [] highscore){
		this.highscore = highscore;
	}
}

public class InnerObjectData_LitJson{
	public string name;
	public int scores;
	public InnerObjectData_LitJson(string name, int scores){
		this.name = name;
		this.scores = scores;
	}
}
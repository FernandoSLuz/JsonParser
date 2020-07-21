using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson; //Implemented for better manipulation of json data
using System.IO;
using UnityEngine.Networking;
using TMPro;
public class Json_Manager : MonoBehaviour
{
	//The prefabs to create the sheet
	public GameObject rowPrefab;
	public GameObject colPrefab;
	//Panel where the objects will be instantiated
	public Transform parent;
	private IEnumerator Start()
	{
		//Populate json file on streamingAssets path
		string filePath = Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json");
		UnityWebRequest www = UnityWebRequest.Get(filePath);
		yield return www.SendWebRequest();
		string json = www.downloadHandler.text;
		//convert json string into object
		JsonData data = JsonMapper.ToObject(json);
		Populate(data);
	}
	
	public void Populate(JsonData data){
		//create list with all headers, and then populate with the ones in json
		List<string> ColumnHeaders = new List<string>();
		foreach (JsonData item in data["ColumnHeaders"]){
			ColumnHeaders.Add((string)item);
		}
		//Create first row with title 
		InstantiateRowAndColumns(new List<string>() { (string)data["Title"] });
		//Create second row with guide columns 
		InstantiateRowAndColumns(ColumnHeaders);
		//Loop through Data array and then populate each row with all data
		foreach (JsonData item in data["Data"])
		{
			InstantiateRowAndColumns(ColumnHeaders, item);
		}
	}
	public void InstantiateRowAndColumns(List<string> tempColumnHeaders, JsonData data = null)
	{
		GameObject row = Instantiate(rowPrefab, parent, false);
		foreach(var item in tempColumnHeaders)
		{
			GameObject col = Instantiate(colPrefab, row.transform, false);
			TextMeshProUGUI text = col.GetComponentInChildren<TextMeshProUGUI>();
			//if that is null, then we know is title or guide collumns
			if(data == null){
				text.fontStyle = FontStyles.Bold;
				text.text = item;
			}else{
				//Verify if the object contains the specific key
				if (JsonDataContainsKey(data, item))
				{
					text.text = (string)data[item];
				}
				else
				{
					//if not, just show that on the sheet
					text.text = "--";
				}
			}
		}
	}
	// Json utility method to verify if key exist in specified object
	static public bool JsonDataContainsKey(JsonData data, string key)
	{
		bool result = false;
		if (data == null)
			return result;
		if (!data.IsObject)
		{
			return result;
		}
		IDictionary tdictionary = data as IDictionary;
		if (tdictionary == null)
			return result;
		if (tdictionary.Contains(key))
		{
			result = true;
		}
		return result;
	}
}

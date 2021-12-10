using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem 
{
    public static void SaveGame ( GameManager gm){
		Debug.Log("Save Game");
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/ilove.me";
		FileStream stream = new FileStream(path, FileMode.Create);
		GMData data = new GMData(gm);
		formatter.Serialize(stream,data);
		stream.Close();
		
		
		
		
	}
	
	
	public static GMData LoadGame(){
		string path = Application.persistentDataPath + "/ilove.me";
		if(File.Exists(path)){
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			GMData data = formatter.Deserialize(stream) as GMData;
			stream.Close();
			return data;
			
		}
		return null;
		
	}
	
	
	
}

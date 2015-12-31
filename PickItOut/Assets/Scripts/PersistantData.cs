using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PersistantData : MonoBehaviour {

	public static bool debugMode = false;
	public static UserData userData;

	// Use this for initialization
	void Awake () {
		BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (Application.persistentDataPath + "/PickItOut.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/PickItOut.dat", FileMode.Open);
			PersistantData.userData = (UserData)bf.Deserialize (file);
			file.Close ();
		} else {
			PersistantData.userData = new UserData();
			FileStream file = File.Open (Application.persistentDataPath + "/PickItOut.dat", FileMode.Create);
			bf.Serialize(file, PersistantData.userData);
			file.Close ();
		}
	}

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/PickItOut.dat", FileMode.Create);
		bf.Serialize(file, PersistantData.userData);
		file.Close ();
	}

	public static void ClearData() {
		BinaryFormatter bf = new BinaryFormatter ();
		PersistantData.userData = new UserData();
		FileStream file = File.Open (Application.persistentDataPath + "/PickItOut.dat", FileMode.Create);
		bf.Serialize(file, PersistantData.userData);
		file.Close ();
	}
}

[Serializable]
public class UserData {
	public DateTime lastAd = DateTime.MinValue;
	public int numAdsWatched = 0;
}

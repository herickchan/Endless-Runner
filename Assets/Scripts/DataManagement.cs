using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManage;

    public int highScore;
    public int score;
    public int coinsCollected;
    public bool gameOn = false;
    public bool playerDed = false;

    private BinaryFormatter binForm;
    private FileStream file;

	void Awake () {
	    if (dataManage == null) {
            DontDestroyOnLoad (gameObject);
            dataManage = this;
        } else if (dataManage != this) {
            Destroy (gameObject);
        }
	}

   public void SaveData () {
        binForm = new BinaryFormatter();
        file = File.Create (Application.persistentDataPath + "/gameInfo.dat");
        gameData data = new gameData();
        if (score > highScore) { 
            data.highScore = score;
        } else {
            data.highScore = highScore;
        }
        data.coinsCollected = coinsCollected;
        binForm.Serialize (file, data);
        file.Close();
    }

    public void LoadData () {
        score = 0;
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat")) {
            binForm = new BinaryFormatter();
            file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)binForm.Deserialize (file);
            file.Close();
            highScore = data.highScore;
            coinsCollected = data.coinsCollected;
        }
    }
}

[Serializable]
public class gameData {
    public int highScore;
    public int coinsCollected;
}

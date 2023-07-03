using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSignleton : MonoBehaviour
{
    public static DataSignleton Instance;

    private string saveLocation;
    public string playerName;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        saveLocation = Application.persistentDataPath + "/savefile.json";

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSaveData();
    }

    public void checkHighScore(int score)
    {
        if(score > highScore){
            highScoreName = playerName;
            highScore = score;
            WriteSaveData();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void WriteSaveData()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(saveLocation, json);
    }

    public void LoadSaveData()
    {
        if (File.Exists(saveLocation))
        {
            string json = File.ReadAllText(saveLocation);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}

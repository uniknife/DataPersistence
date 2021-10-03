using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string bestPlayerName;
    public int bestScore;
    private string playerName;
    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/savefile.json";

        if (DataManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void UpdatePlayerName(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveBestScore(int score)
    {
        SaveData data = new SaveData();
        if (score > bestScore)
        {
            data.playerName = playerName;
            data.score = score;
            bestPlayerName = playerName;
            bestScore = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(path, json);
        }
    }

    public void LoadBestScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            playerName = data.playerName;
            bestScore = data.score;
        }
    }
}

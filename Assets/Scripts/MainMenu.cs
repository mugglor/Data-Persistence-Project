using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public string playerName;
    public int score;
    public string bestPlayerName;
    public int bestPlayerScore;
    // Start is called before the first frame update

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();

    }

    public void StartGame(string inputName)
    {

        if (inputName.Length > 0)
        {
            playerName = inputName;
            SceneManager.LoadScene("main");
        }
    }

    public void Exit()
    {
        SavePlayerData();


        Application.Quit();

    }

    public void SavePlayerData()
    {
        BestPlayer data = new BestPlayer();
        data.name = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer data = JsonUtility.FromJson<BestPlayer>(json);

            bestPlayerName = data.name;
            bestPlayerScore = data.score;
        }
    }



    class BestPlayer
    {
        public string name;
        public int score;

    }
}

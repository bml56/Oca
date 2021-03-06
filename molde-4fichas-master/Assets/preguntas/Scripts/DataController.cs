﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    private RoundData[] allRoundData;
    private string gameDataFileName = "QuestionsAndAnswers.json";
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("menu");
        LoadGame();
        
        //SceneManager.LoadScene("oca");
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    private void LoadGame()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        string filePath2 = Path.Combine(Application.streamingAssetsPath, "");  
        if (File.Exists(filePath) || File.Exists(filePath2 + "/" + gameDataFileName))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("No se puede cargar las preguntas");
        }
    }
}
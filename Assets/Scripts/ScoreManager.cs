using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string scorerName;
    public TMP_Text bestScoreMenu;
    public int BestPoint;
    public string BestScorerName;
    public string textTest = "string show?";

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log(textTest);
        Debug.Log(BestScorerName);
        Debug.Log(scorerName);
        LoadPoint();
        bestScoreMenu.text = "Best Score : "+BestScorerName+ " : " + BestPoint;
        
    }

    [System.Serializable]
    class SaveData
    {
        public int BestPoint;
        public string BestScorerName;
        public string ScorerName;
    }

    public void SavePoint()
    {
        SaveData data = new SaveData();
        data.BestPoint = BestPoint;
        data.BestScorerName = BestScorerName;



        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPoint()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPoint = data.BestPoint;
            BestScorerName = data.BestScorerName;
            

        }
    }

    public void SaveScorer()
    {
        SaveData data = new SaveData();
        data.ScorerName = scorerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefilescorer.json", json);
    }
    public void LoadScorer()
    {
        string path = Application.persistentDataPath + "/savefilescorer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scorerName = data.ScorerName;
        }

    }
}
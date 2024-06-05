using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_InputField scorerName;
    public TMP_Text bestScoreMenu;
    public int BestPoint;
    public string BestScorerName;
    

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        bestScoreMenu.text = "Best Score : "/*+BestScorerName*/+" : " + BestPoint;
        Debug.Log(BestScorerName);
    }

   [System.Serializable]
   class SaveData
    {
        public int BestPoint;
        public string BestScorerName;
        //public string ScorerName;
    }

    public void SavePoint()
    {
        SaveData data = new SaveData();
        data.BestPoint = BestPoint;
        data.BestScorerName = BestScorerName;
        //data.ScorerName = scorerName.text;
        
        
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
            //scorerName.text = data.ScorerName;

        }
    }
}

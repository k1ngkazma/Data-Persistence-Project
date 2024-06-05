using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField inputField;
   public void StartNew()
    {
        SceneManager.LoadScene(1);
        ScoreManager.Instance.SavePoint();
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    
    }
    //Gives user input name to scoremanager
    public void NewNameSelected()
    {
       
       ScoreManager.Instance.scorerName = inputField;
    }

    public void ResetBestScore()
    {
        ScoreManager.Instance.BestPoint = 0;
        ScoreManager.Instance.SavePoint();
    }
}

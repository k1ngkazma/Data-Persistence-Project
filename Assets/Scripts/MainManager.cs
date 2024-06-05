using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public TMP_Text ScoreText;
    public GameObject GameOverText;
    public TMP_Text BestScoreText;
    //public Text BestScoreNumber;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;
    private string currentScorer;

    
    // Start is called before the first frame update
    void Start()
    {
        
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        

        Debug.Log(ScoreManager.Instance.scorerName);
        ScoreManager.Instance.LoadPoint();
        ScoreManager.Instance.LoadScorer();
        BestScoreText.text = "Best Score : " + ScoreManager.Instance.BestScorerName + " : " + ScoreManager.Instance.BestPoint;
        Debug.Log(ScoreManager.Instance.scorerName);
        Debug.Log(ScoreManager.Instance.BestScorerName);
        Debug.Log(ScoreManager.Instance.BestPoint);
    }

    private void Update()
    {
        if (!m_Started)
        {
            
            ScoreManager.Instance.LoadPoint();
            BestScoreText.text = "Best Score : " + ScoreManager.Instance.BestScorerName + " : " + ScoreManager.Instance.BestPoint;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);

                

            }
        }
        else if (m_GameOver)
        {
            SetBestScore();
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                

            }
        }
        
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void SetBestScore()
    {
        ScoreManager.Instance.LoadPoint();
        
        if (m_Points>ScoreManager.Instance.BestPoint)
        {
           
                ScoreManager.Instance.BestScorerName = ScoreManager.Instance.scorerName;
                ScoreManager.Instance.BestPoint = m_Points;
                ScoreManager.Instance.SavePoint();
                //ScoreManager.Instance.SaveScorer();
            Debug.Log("best scorer name"+ScoreManager.Instance.BestScorerName);
            
           

        }
        BestScoreText.text = "Best Score : " +ScoreManager.Instance.BestScorerName+" : " + ScoreManager.Instance.BestPoint;
    }

  

 

}

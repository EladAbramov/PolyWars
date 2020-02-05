using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int highScore;
    Text HighS;
    // Start is called before the first frame update
    void Start()
    {
        HighS = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("highScore");
        ShowHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.scoreValue > highScore)
        {
            highScore = ScoreManager.scoreValue;
            StoreHighScore();
           
        }

    }

    void StoreHighScore()
    {
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
        ShowHighScore();
    }

    void ShowHighScore()
    {
        HighS.text = "High Score: " + highScore;
    }
}

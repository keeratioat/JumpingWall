using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GamePlayManager : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI highScoreText;

    int score = 0;
   
     void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }
    public void scoreUp() {
        score++;
        textScore.text = score.ToString();
    }
    public void bestOfScore() {
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = score.ToString();
        }
    }
   
    public void loadSceen(string str) {
        SceneManager.LoadScene(str);
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScoreText.text = "0";
    }
}

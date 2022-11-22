using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Text txtScore;
    public Text bTxtScore;
    private int cScore = 0;
    private int bScore;
    void Start()
    {
        bScore = PlayerPrefs.GetInt("B_SCORE", 0); //값 가져옴
        DispScore(0);
    }
    public void DispScore(int score)
    {
        cScore += score;
        txtScore.text = "Score <color=#ff0000>" + cScore.ToString() + "</color>";
        
        if (bScore < cScore){
            bScore = cScore;
            PlayerPrefs.SetInt("B_SCORE", bScore); //값 설정함
        }

        bTxtScore.text = "Best Score <color=#ff0000>" + bScore.ToString() + "</color>";
    }
}
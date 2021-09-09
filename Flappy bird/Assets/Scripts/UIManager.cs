using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

    
{
    public Text pointText;
    public Text maxScoreText;

    public int points;
    private int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        int maxScore = PlayerPrefs.GetInt("maxscore", 0);
        pointText.text = "0";
        maxScoreText.text = "Max Score: " + maxScore;
        
    }

    public void AddPoint()
    {
        points += 1;
        pointText.text = "" + points;

        if (maxScore < points)
        {
            maxScore = points;
            PlayerPrefs.SetInt("maxscore", points);
            maxScoreText.text = "Max Score: " + maxScore;
        }
    }
}

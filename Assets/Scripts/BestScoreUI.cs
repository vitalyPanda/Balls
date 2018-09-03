using UnityEngine;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    private Text scoreText;
    public int BestScore
    {
        get
        {
            if (PlayerPrefs.HasKey("BestScore"))
                return PlayerPrefs.GetInt("BestScore");
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("BestScore", value);
        }
    }

    public void SetBestScore(int score)
    {
        if (BestScore < score)
        {
            BestScore = score;
            SetText();
        }

    }
    private void SetText()
    {
        scoreText.text = "Best score : " + BestScore;
    }
    private void Awake()
    {
        scoreText = GetComponent<Text>();
        SetText();
    }
}

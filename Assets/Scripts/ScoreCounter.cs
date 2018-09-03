using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text scoreText;
    private int score = -1;
    public int GetScore()
    {
        return score;
    }
    private Animator animator;
    private void Awake()
    {
        AddScore();
    }
    public void SetScore(int score)
    {
        animator.SetTrigger("Shuffle");
        this.score = score;
        scoreText.color = HelperClass.GetColor(score, .9f);
        scoreText.text = "Score : " + score;
    }
    public void AddScore()
    {
        if (!scoreText) scoreText = GetComponent<Text>();
        if (!animator) animator = GetComponent<Animator>();
        animator.SetTrigger("Shuffle");
        score++;
        scoreText.color = HelperClass.GetColor(score, .9f);
        scoreText.text = "Score : " + score;
    }
}

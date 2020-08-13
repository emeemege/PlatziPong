using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public Text playerScoreText;
    public Text enemyScoreText;
    public AudioSource pointSound;
    public int scoreToWin = 3;
    int playerScore = 0;
    int enemyScore = 0;

    private void OnTriggerEnter2D(Collider2D ball)
    {
        if(gameObject.tag == "player")
        {
            enemyScore++;
            UpdateScoreLabel(enemyScoreText, enemyScore);
        }
        else if(gameObject.tag == "enemy")
        {
            playerScore++;
            UpdateScoreLabel(playerScoreText, playerScore);
        }
        pointSound.Play();
        CheckScore();
        ball.GetComponent<BallBehaviour>().gameStarted = false;
    }

    private void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }

    private void CheckScore()
    {
        if(playerScore >= scoreToWin)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if(enemyScore >= scoreToWin)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }
}

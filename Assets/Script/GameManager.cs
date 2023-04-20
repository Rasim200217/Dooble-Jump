using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;
    public TMP_Text scoreText;

    public GameObject GameOverPanel;
    public TMP_Text currentText;
    public TMP_Text highScoreText;
    public Button restartButton;

    public Camera mainCam;
    public Image backgroundImage;
    private int randomIndex;
    public Color[] colorChange;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        randomIndex = Random.Range(0, colorChange.Length);
        ChangeColor();
    }


    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        GameOverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        ApplyColor();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("Score", score);
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        GameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    void ApplyColor()
    {
        if(score == 2)
        {
            ChangeColor();
        }else if(score == 5)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        mainCam.backgroundColor = colorChange[randomIndex];
        backgroundImage.color = colorChange[randomIndex];
    }
}

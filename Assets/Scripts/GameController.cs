using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public Text highScoreText;

    void Start()
    {
        //PlayerPrefs.SetFloat("HighScore", 0);
        highScoreText.text = "High score: " + PlayerPrefs.GetFloat("HighScore").ToString("0.#");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToHowToPlay()
    {
        SceneManager.LoadScene("How to play");

    }
    public void ResetScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
        highScoreText.text = "High score: " + PlayerPrefs.GetFloat("HighScore").ToString("0.#");
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}

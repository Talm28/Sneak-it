using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsGameFunctions : MonoBehaviour {

    public GameObject musicSlider;
    public GameObject soundEffectSlider;


    void Start()
    {
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
        soundEffectSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sound effect");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetMusic(float newMusic)
    {
        PlayerPrefs.SetFloat("Music", newMusic);
    }

    public void SetSoundEffect(float newMusic)
    {
        PlayerPrefs.SetFloat("Sound effect", newMusic);
    }
    public void ResetScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
    }
}

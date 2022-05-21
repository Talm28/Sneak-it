using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {

    public GameObject gameController;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject particleSystem;
    public AudioSource coinAudio;
    public AudioSource taDaAudio;

    GameObject backgroundsound;
    float musicVolume;

    public Text coinsText;
    int coins = 0;
    public Text finalTimeText;
    public Text finalCoinsText;
    public Text finalScoreText;
    public Text highScoreText;

    Transform playerPosition;
    SpriteRenderer playerSprite;
    public bool isTouched = false;

	void Start () {
        playerPosition = GetComponent<Transform>();
        playerSprite = GetComponent<SpriteRenderer>();
        coinsText.text = "Coins: " + coins.ToString();
        backgroundsound = GameObject.FindGameObjectsWithTag("music")[0];
        coinAudio.volume = PlayerPrefs.GetFloat("Sound effect");
        taDaAudio.volume = PlayerPrefs.GetFloat("Sound effect");
        musicVolume = PlayerPrefs.GetFloat("Music");
        backgroundsound.GetComponent<DontDestroy>().isPlay = true;

	}

    void Update()
    {

        if (Input.touchCount > 0)
        {
            //Touch pause mode
            if (gameController.GetComponent<GameFunction>().gameStatus == "Pause")
            {
                if (isTouched)
                {
                    backgroundsound.GetComponent<AudioSource>().volume = musicVolume;
                    playerSprite.enabled = false;
                    pausePanel.SetActive(false);
                    gameController.GetComponent<GameFunction>().gameStatus = "Play";
                    

                }
            }
            //Touch play mode
            if (gameController.GetComponent<GameFunction>().gameStatus == "Play")
            {

                
                if (isTouched)
                {
                    backgroundsound.GetComponent<AudioSource>().volume = musicVolume;
                    playerPosition.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 2));
                }
            }

            //Start mode
            if (gameController.GetComponent<GameFunction>().gameStatus == "Start")
            {
                if (musicVolume > 0.4f)
                    backgroundsound.GetComponent<AudioSource>().volume = 0.4f;
                
                if (isTouched)
                {
                    playerPosition.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 2));
                    playerSprite.enabled = false;

                }

            }
        }

        //unthouch start mode
        if (gameController.GetComponent<GameFunction>().gameStatus == "Start")
        {
            if (musicVolume > 0.4f)
                backgroundsound.GetComponent<AudioSource>().volume = 0.4f;
            if (!isTouched)
            {

                playerSprite.enabled = true;

            }
        }
        
        //unthouch play mode
        if (gameController.GetComponent<GameFunction>().gameStatus == "Play")
        {
            if (!isTouched)
            {
                if (musicVolume > 0.4f)
                    backgroundsound.GetComponent<AudioSource>().volume = 0.4f;
                playerSprite.enabled = true;
                pausePanel.SetActive(true);
                gameController.GetComponent<GameFunction>().gameStatus = "Pause";

            }
        }
    }
		


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finger")
        {
            isTouched = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            gameController.GetComponent<GameFunction>().gameStatus = "Dead";
            finalTimeText.text = "Time: " + gameController.GetComponent<PlatformSpawn>().levelTimer.ToString("0.#");
            finalCoinsText.text = "Coins: " + coins.ToString() + " x 5 = " + coins * 5;
            finalScoreText.text = "Final score: " + (gameController.GetComponent<PlatformSpawn>().levelTimer + coins * 5).ToString("0.#");
            if (PlayerPrefs.GetFloat("HighScore") < (gameController.GetComponent<PlatformSpawn>().levelTimer + coins * 5))
            {
                taDaAudio.Play();
                PlayerPrefs.SetFloat("HighScore",gameController.GetComponent<PlatformSpawn>().levelTimer + coins * 5);
                particleSystem.SetActive(true);
            }
            gameOverPanel.SetActive(true);
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString("0.#");

        }
        if (col.gameObject.tag == "Coin")
        {
            coinAudio.Play();
            Destroy(col.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins.ToString();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finger")
        {
            isTouched = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        gameController.GetComponent<PlatformSpawn>().Restart();
        gameController.GetComponent<CoinSpawner>().Restart();
        coins = 0;
        PlayerPrefs.SetFloat("Music", musicVolume);
        
    }



}

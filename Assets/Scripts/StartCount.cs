using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour {

    public Text startCountText;
    public GameObject gameController;

    float timer = 0;
    float delay = 1f;
    int counter = 3;

	void Start () {
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound effect");
	}
	

	void Update () {

        timer += Time.deltaTime;
        if(timer >delay)
        {
            timer = 0;
            switch(counter)
            {

                case 3:
                    startCountText.text = "2";
                    break;
                case 2:
                    startCountText.text = "1";
                    break;
                case 1:
                    startCountText.text = "Go!";
                    break;
                case 0:
                    gameController.GetComponent<GameFunction>().gameStatus = "Play";
                    Destroy(this.gameObject);
                    break;
            }
            counter--;
        }
        
        
		
	}
}

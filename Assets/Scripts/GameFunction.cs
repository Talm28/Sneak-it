using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFunction : MonoBehaviour {

    public string gameStatus;

	void Start () {
        gameStatus = "Start";
	}
	

    public void BackToTheMenu()
    {
        SceneManager.LoadScene("Menu");
        GameObject.FindGameObjectsWithTag("music")[0].GetComponent<DontDestroy>().isPlay = false;

    }
}

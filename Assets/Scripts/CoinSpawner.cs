using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    public GameObject coinPrefab;
    public GameObject gameController;

    float timer;

	void Start () {
	}
	

	void Update () {

        if (gameController.GetComponent<GameFunction>().gameStatus == "Play")
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                if (Random.Range(1, 8) == 1)
                {
                    Instantiate(coinPrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                }
            }

        }
        

	}

    public void Restart()
    {
        timer = 0f;
    }
}

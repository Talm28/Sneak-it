using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControll : MonoBehaviour {

    float timer = 0f;


	void Start () {
		
	}
	
	void Update () {

        if (GameObject.Find("Game controller").GetComponent<GameFunction>().gameStatus == "Play")
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                Destroy(this.gameObject);
            }

        }
        if (GameObject.Find("Game controller").GetComponent<GameFunction>().gameStatus == "Dead")
        {
            Destroy(this.gameObject);
        }
        
	}
}

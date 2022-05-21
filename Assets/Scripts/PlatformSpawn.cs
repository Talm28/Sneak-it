using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawn : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject gameController;


    public Text timeText;

    float timeToSpawn = 1f;
    float spawnTimer = 0f;

    public float levelTimer = 0;


	void Start () {
        platformPrefab.GetComponent<PlatformMovement>().setSpeed(-150);
        platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(0);
        timeText.text = "Time: 0.00";


	}
	

	void Update () {

        if(gameController.GetComponent<GameFunction>().gameStatus == "Play")
        {
            //timer for spawn platform
            spawnTimer += Time.deltaTime;
            if (spawnTimer > timeToSpawn)
            {

                Instantiate(platformPrefab, new Vector3(Random.Range(-2.5f, 2.5f), 6, 0), Quaternion.identity);
                spawnTimer = 0;
            }

            //timer for level progress
            levelTimer += Time.deltaTime;
            platformPrefab.GetComponent<PlatformMovement>().setSpeed(-250 - (levelTimer * 125 * Time.deltaTime));
            if (timeToSpawn > 0.1f)
            {
                timeToSpawn -= 0.005f * Time.deltaTime;
            }
            if (levelTimer > 25 && levelTimer < 25.1)
            {
                platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(25);
            }
            else if (levelTimer > 30 && levelTimer < 30.1)
            {
                platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(-30);
            }
            else if (levelTimer > 35 && levelTimer < 35.1)
            {
                platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(40);
            }
            else if (levelTimer > 45 && levelTimer < 45.1)
            {
                platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(-45);
            }
            else if (levelTimer > 60 && levelTimer < 60.1)
            {
                platformPrefab.GetComponent<PlatformMovement>().setHorizSpeed(50);
            }


            //update time text
            timeText.text = "Time: " + levelTimer.ToString("0.#");
        }

        


    }

    public void Restart()
    {
        spawnTimer = 0f;
        timeToSpawn = 1f;
        levelTimer = 0f;
    }
}

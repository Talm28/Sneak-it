using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

    public GameObject platformPrefab;

    float timer;
    float timeToSpawn = 1.5f;


	void Start () {
        platformPrefab.GetComponent<PtalformStartMovement>().speed = -100;
	}

	void Update () {

        timer += Time.deltaTime;
        if(timer >timeToSpawn)
        {
            timer = 0;
            Instantiate(platformPrefab, new Vector3(Random.Range(-2.5f, 2.5f), 6, 0), Quaternion.identity);
        }

	}
}

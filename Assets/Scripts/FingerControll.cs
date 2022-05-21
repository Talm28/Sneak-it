using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerControll : MonoBehaviour {

    Transform fingerPosition;

	void Start () {
        fingerPosition = GetComponent<Transform>();
	}
	
	
	void Update () {

        if(Input.touchCount>0)
        {
            fingerPosition.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 10));

        }
        else
        {
            fingerPosition.position = new Vector3(-6, 6, 0);
        }
		
	}

    
}

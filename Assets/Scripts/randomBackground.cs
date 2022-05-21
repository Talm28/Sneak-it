using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomBackground : MonoBehaviour {

    public Sprite background_1;
    public Sprite background_2;
    public Sprite background_3;
    public Sprite background_4;
    public Sprite background_5;
    public Sprite background_6;
    public Sprite background_7;
    public Sprite background_8;

	void Start () {
        int randomNum = Random.Range(1, 9);
        switch(randomNum)
        {
            case 1:
                GetComponent<Image>().sprite = background_1;
                break;
            case 2:
                GetComponent<Image>().sprite = background_2;
                break;
            case 3:
                GetComponent<Image>().sprite = background_3;
                break;
            case 4:
                GetComponent<Image>().sprite = background_4;
                break;
            case 5:
                GetComponent<Image>().sprite = background_5;
                break;
            case 6:
                GetComponent<Image>().sprite = background_6;
                break;
            case 7:
                GetComponent<Image>().sprite = background_7;
                break;
            case 8:
                GetComponent<Image>().sprite = background_8;
                break;
        }
	}
	
}

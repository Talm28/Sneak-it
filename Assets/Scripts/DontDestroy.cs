using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public bool isPlay = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if(!isPlay)
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
        }
        
    }

       
}

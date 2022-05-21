using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMovement : MonoBehaviour {

    public float speed;
    public float horizSpeed;
    Rigidbody2D rb;




	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {

        if (GameObject.Find("Game controller").GetComponent<GameFunction>().gameStatus == "Play")
        {
            rb.velocity = new Vector2(horizSpeed * Time.deltaTime, speed * Time.deltaTime);

            if (transform.position.y < -6)
            {
                Destroy(this.gameObject);
            }

            if (transform.position.x > 2.5 || transform.position.x < -2.5)
            {
                horizSpeed = -horizSpeed;
            }
        }
        if (GameObject.Find("Game controller").GetComponent<GameFunction>().gameStatus == "Pause")
        {
            rb.velocity = new Vector2(0,0);
        }
        if (GameObject.Find("Game controller").GetComponent<GameFunction>().gameStatus == "Dead")
        {
            Destroy(this.gameObject);
        }

        


	}


    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void setHorizSpeed(float newSpeed)
    {
        horizSpeed = newSpeed;
    }

}

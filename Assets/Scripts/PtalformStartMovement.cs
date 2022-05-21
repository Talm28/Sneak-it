using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtalformStartMovement : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {


            rb.velocity = new Vector2(0, speed * Time.deltaTime);

            if (transform.position.y < -6)
            {
                Destroy(this.gameObject);
            }






    }

}

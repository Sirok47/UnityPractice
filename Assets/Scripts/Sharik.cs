using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sharik : MonoBehaviour
{     float horizontalInput;
      public float speed;
      public float jumpHeight;
      int kadri;
      protected Rigidbody2D shar;
      private bool yaNaZemle;
      
      // Start is called before the first frame update
    void Start()
    {
        shar = GetComponent<Rigidbody2D>();
        yaNaZemle=false;
    }

    // Update is called once per frame
    void Update()
    {     
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * Time.deltaTime *speed*horizontalInput);
        if (Math.Abs(shar.velocity.x)<10) shar.AddForce(Vector2.right * Time.deltaTime *speed*horizontalInput*100);



        if (Input.GetKeyDown(KeyCode.Space) && yaNaZemle )
        {
            shar.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
            yaNaZemle=false;
            
        }

    }


    void OnCollisionEnter2D(Collision2D predmet)
    {

          if (predmet.gameObject.tag == "Zemlya") yaNaZemle=true;



    }

}

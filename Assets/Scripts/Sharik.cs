using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sharik : MonoBehaviour
{     
      public float speed;
      public float jumpHeight;
      protected Rigidbody2D shar;
      private bool yaNaZemle;
      private bool yaNaStene;
      public float timer=1; 
      public bool play=true; 
      private int wallJumped=0;
      public GameObject granata;
      
      
      // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timer;
        shar = GetComponent<Rigidbody2D>();
        yaNaZemle=false;
    }

    // Update is called once per frame
    void Update()
    {     
        shar.AddForce(Vector2.right * Time.deltaTime *speed*Input.GetAxis("Horizontal")*100);
        shar.AddForce(new Vector2((float)Math.Pow((shar.velocity.x),2)*(shar.velocity.x<0?1:-1),0)*Time.deltaTime*10);

        if (Input.GetKeyDown(KeyCode.Space)) JumpAttempt();


        if (Input.GetKeyDown(KeyCode.G)) BrosokGranati();


        
        if (Input.GetKeyDown(KeyCode.Escape) && play) {timer=0; play=false;}
        else if (Input.GetKeyDown(KeyCode.Escape) && !play) {timer=1; play=true;}
        Time.timeScale = timer;
    }

    public void NaZemle(bool pravda)
    {
        yaNaZemle=pravda;
        if (pravda) wallJumped=0;
    }

    public void NaStene(bool pravda)
    {
        yaNaStene=pravda;
    }

    void JumpAttempt()
    {
        if (yaNaZemle){
            shar.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
            yaNaZemle=false;
        } else if (wallJumped<2 && yaNaStene){
            shar.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
            wallJumped++;
        }
    }


    void BrosokGranati()
    {
        Instantiate(granata, transform).GetComponent<Rigidbody2D>().AddForce(new Vector2(100,0), ForceMode2D.Impulse);


    }


}

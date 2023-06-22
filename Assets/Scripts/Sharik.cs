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
      private float timer=1; 
      private bool play=true; 
      private int wallJumped=0;
      public GameObject granata;
      private DateTime metka;
      public double cooldown=1;
      private DateTime cd;
      
      
      // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timer;


        shar = GetComponent<Rigidbody2D>();
        yaNaZemle=false;


        cd=new DateTime().AddSeconds(cooldown);
        
    }

    // Update is called once per frame
    void Update()
    {     
        shar.AddForce(Vector2.right * Time.deltaTime *speed*Input.GetAxis("Horizontal")*100);
        shar.AddForce(new Vector2((float)Math.Pow((shar.velocity.x),2)*(shar.velocity.x<0?1:-1),0)*Time.deltaTime*10);


        if (Input.GetKeyDown(KeyCode.Space)) JumpAttempt();

        
        if ((Input.GetKeyDown(KeyCode.G)) && (DateTime.Now.Subtract(metka)>cd.Subtract(new DateTime()))) BrosokGranati();


        
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
        float direction = (float)Math.Sqrt(Math.Pow(shar.velocity.x,2)+Math.Pow(shar.velocity.y,2))/10;
        Instantiate(granata, transform).GetComponent<Rigidbody2D>().AddForce(new Vector2(shar.velocity.x/direction,shar.velocity.y/direction), ForceMode2D.Impulse);
        metka = DateTime.Now;

    }

     void OnGUI()
    {
        TimeSpan counter=cd.Subtract(new DateTime()).Subtract(DateTime.Now.Subtract(metka));
       
        int w = Screen.width, h = Screen.height;
 
        GUIStyle style = new GUIStyle();
 
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 5 / 100; 
        style.normal.textColor = Color.black;
        string text=counter.Seconds.ToString()+"."+((int)((double)(counter.Milliseconds)/100)).ToString();
        if (DateTime.Now.Subtract(metka)<cd.Subtract(new DateTime())) GUI.Label(rect, text, style);
       
       
    }
 
}

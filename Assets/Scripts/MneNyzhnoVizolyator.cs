using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MneNyzhnoVizolyator : MonoBehaviour
{  
    public float yravnoveshennost;
    public GameObject strelka;
    public GameObject sharik;
    protected Rigidbody2D shar;
  

    // Start is called before the first frame update
    void Start()
    {   
       
        strelka.transform.eulerAngles=new Vector3(0,0,-125);
        shar = sharik.GetComponent<Rigidbody2D>();
        
    }




    // Update is called once per frame
    void LateUpdate()
    {
       strelka.transform.eulerAngles= new Vector3(0,0,180/yravnoveshennost*Math.Abs(shar.velocity.x) - 125);
    }
}

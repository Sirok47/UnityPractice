using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharik : MonoBehaviour
{     float horizontalInput;
      public float speed;
      public float jumpHeight;
      int kadri;
      
      // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime *speed*horizontalInput);
        
       // if (Input.GetAxis("Jump")!=0) kadri=(int)(1/Time.deltaTime);
      //  if (kadri!=0) {transform.Translate(Vector3.up * Time.deltaTime *jumpHeight); kadri--;}


         if (Input.GetAxis("Jump")!=0) transform.Translate(Vector3.up * Time.deltaTime *jumpHeight);
        


        

    }
}

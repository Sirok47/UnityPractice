using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Podoshva : MonoBehaviour
{ public Sharik sharik;

    // Start is called before the first frame update
    void Start()
    {
       // sharik = GetComponent<Sharik>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D predmet)
    {

          if (predmet.gameObject.tag == "Zemlya") sharik.NaZemle();

    
    
    }
}

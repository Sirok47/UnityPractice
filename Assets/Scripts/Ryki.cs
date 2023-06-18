using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ryki : MonoBehaviour
{ public Sharik sharik;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D predmet)
    {
          if (predmet.gameObject.tag == "Zemlya") sharik.NaStene(true);
    }

    void OnCollisionExit2D(Collision2D predmet)
    {
          if (predmet.gameObject.tag == "Zemlya") sharik.NaStene(false);
    }
}

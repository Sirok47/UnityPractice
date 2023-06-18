using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Vzriv : MonoBehaviour
{   
    public float granataVzorvetsyaCherez;
    private Collider2D[] zhertvi=new Collider2D[10];
    private CircleCollider2D Aoe;


    // Start is called before the first frame update
    void Start()
    {    
          Aoe = GetComponent<CircleCollider2D>();
          
          
          //Thread.Sleep(granataVzorvetsyaCherez); 
         Invoke("Podriv",granataVzorvetsyaCherez);


          
    }

    
    void Podriv()
    {   
        
      Debug.Log("SKIDISH");

      ContactFilter2D filtyr= new ContactFilter2D();
      filtyr.useTriggers=true;


      Aoe.OverlapCollider( filtyr, zhertvi);
       
          foreach(Collider2D zhertva in zhertvi)
        {   Debug.Log(zhertva); 
           try { zhertva.gameObject.GetComponent<Health>().takeDamage(50); }
           catch {}

        } 
        Debug.Log("ny"+zhertvi); 

        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
        
    }


}

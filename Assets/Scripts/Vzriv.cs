using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Vzriv : MonoBehaviour
{   
    public float granataVzorvetsyaCherez;
    private Collider2D[] zhertvi=new Collider2D[100];
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
      Aoe.OverlapCollider(new ContactFilter2D(), zhertvi);
       
      foreach(Collider2D zhertva in zhertvi)
      {   
        try { zhertva.gameObject.GetComponent<Health>().takeDamage(50); }
        catch {}
      } 

      Destroy(transform.parent.gameObject);
      Destroy(gameObject);
        
    }


}

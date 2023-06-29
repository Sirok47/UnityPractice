using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private CapsuleCollider2D Aoe;

    public bool IsClear(){
        Aoe = GetComponent<CapsuleCollider2D>();
        Collider2D[] zhertvi=new Collider2D[100];
        Aoe.OverlapCollider(new ContactFilter2D(), zhertvi);
       
        foreach(Collider2D zhertva in zhertvi)
        {  
            if (zhertva.gameObject.tag=="Zemlya"){
                Destroy(gameObject);
                return true; 
            }
        }
        Destroy(gameObject);
        return false;    
    }
}

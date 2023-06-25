using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroRange : MonoBehaviour
{
    private AIforEnemies ai;
    
    void Start(){
        ai = GetComponentInParent<AIforEnemies>();
    }

    void OnTriggerEnter2D(Collider2D colider){ai.playerInRange=true;}

    void OnTriggerExit2D(Collider2D colider){ai.playerInRange=false;}

    void OnTriggerStay2D(Collider2D colider){
        if (colider.gameObject.tag=="Player"){ai.target=colider.transform.position;}
    }
}

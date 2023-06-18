using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public int hp=100;
   

    public void takeDamage(int Damage)
    {
     hp-=Damage;
      Debug.Log(hp+"VAS POVREDILI");
     if (hp<=0) perish();
    }


    void perish()
    {    
         
        Destroy(gameObject);
       if (gameObject.name.Equals("Sharik")) { Debug.Log("zakrivayus"); Time.timeScale = 0; }
    }
}

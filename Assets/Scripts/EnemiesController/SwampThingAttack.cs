using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampThingAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DealDamage(gameObject victim, int damage){
        victim.GetComponent<Health>();
    }
}

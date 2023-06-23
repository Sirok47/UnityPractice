using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTrigger : MonoBehaviour
{
    private AIforEnemies enemy; 
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        enemy= GetComponentInParent<AIforEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Zemlya") enemy.SafetyGetter(isRight,true);
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag=="Zemlya") enemy.SafetyGetter(isRight,false);
    }
}

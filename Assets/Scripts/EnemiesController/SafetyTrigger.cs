using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTrigger : MonoBehaviour
{
    private enemy = GetComponentInParent<AIforEnemies>();
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider2D collider)
    {
        if (collider.tag="Zemlya") enemy.SafetyGetter(isRight,true);
    }
    void OnTriggerExit(Collider2D collider)
    {
        if (collider.tag="Zemlya") enemy.SafetyGetter(isRight,false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIforEnemies : MonoBehaviour
{
    public bool isLeftSafe;
    public bool isRightSafe;
    public Vector2 target;
    private RigigBody2D rigidB;
    Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        rigidB=GetComponent<Rigidbody2D>();
        Invoke("MakeDecision",4);
    }

    // Update is called once per frame
    void Update()
    {
        if (target){
            if (target.x>transform.x && isRightSafe){
                rigidB.velocity.x=4;
            }
            if (target.x<transform.x && isLeftSafe){
                rigidB.velocity.x=-4;
            }
        } else {rigidB.velocity.x=0;}
    }

    private void MakeDecision()
    {
        switch (rnd.Next(1, 3))
        {
            //Stand still
            1:
            //Move a bit
            2:
            target=new Vector2(transform.x+rnd.Next(-10.10))
            break;
            //Randomly attack
            3:

            default:
        }
        Invoke("MakeDecision",rnd.Next(3, 5));
    }

    private void PerformAttack()
    {

    }

    public void SafetyGetter(bool isRight, bool safety){
        if (isRight) {isRightSafe=safety;}
        else {isLeftSafe=safety;}
    }
}
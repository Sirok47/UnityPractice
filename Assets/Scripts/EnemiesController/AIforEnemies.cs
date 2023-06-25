using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIforEnemies : MonoBehaviour
{
    bool isLeftSafe;
    bool isRightSafe;
    public bool playerInRange;
    public Vector2 target;
    public float monsterSpeed=10;
    private Rigidbody2D rigidB;
    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        rigidB=GetComponent<Rigidbody2D>();
        Invoke("MakeDecision",4);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Vector2.positiveInfinity) {
            if (target.x>transform.position.x && isRightSafe){
                rigidB.MovePosition(new Vector2(transform.position.x + monsterSpeed * Time.deltaTime, transform.position.y));
            }
            if (target.x < transform.position.x && isLeftSafe)
            {
                rigidB.MovePosition(new Vector2(transform.position.x - monsterSpeed * Time.deltaTime, transform.position.y));
            }
            else target =  Vector2.positiveInfinity; 
        } 
    }

    private void MakeDecision()
    {
        if (!playerInRange) switch (rnd.Next(1, 3))
        { 
            //Stand still
            case 1: 
                target = Vector2.positiveInfinity;  break;
            //Move a bit
            case 2:
                target = new Vector2(transform.position.x + rnd.Next(-50,50), transform.position.y);
            break;
            //Randomly attack
            case  3:
            
            break;
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
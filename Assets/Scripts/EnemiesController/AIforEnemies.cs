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
    protected SwampThingAttack attackScript;
    public bool inAir=false;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite=GetComponent<SpriteRenderer>();
        attackScript=GetComponent<SwampThingAttack>();
        rigidB=GetComponent<Rigidbody2D>();
        Invoke("MakeDecision",4);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !inAir) attackScript.PerformAttack(target);
    }

    void FixedUpdate(){
        if (target != Vector2.positiveInfinity) {
            if (target.x>transform.position.x && (isRightSafe || inAir)){
                rigidB.AddForce(new Vector2((monsterSpeed-rigidB.velocity.x)*rigidB.mass,0),ForceMode2D.Impulse);
                sprite.flipX=true;
            }
            if (target.x < transform.position.x && (isLeftSafe || inAir)){
                rigidB.AddForce(new Vector2((Math.Abs(rigidB.velocity.x)-monsterSpeed)*rigidB.mass,0),ForceMode2D.Impulse);
                sprite.flipX=false;
            }
            else target = Vector2.positiveInfinity; 
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
        Invoke("MakeDecision",rnd.Next(2, 5));
    }

    public void SafetyGetter(bool isRight, bool safety){
        if (isRight) {isRightSafe=safety;}
        else {isLeftSafe=safety;}
    }

    void OnCollisionEnter2D(Collision2D predmet)
    {
          if (predmet.gameObject.tag == "Zemlya") inAir=false;
    }

    void OnCollisionExit2D(Collision2D predmet)
    {
          if (predmet.gameObject.tag == "Zemlya") inAir=true;
    }
}



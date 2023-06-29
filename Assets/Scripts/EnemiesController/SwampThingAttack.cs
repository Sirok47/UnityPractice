using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampThingAttack : MonoBehaviour
{
    public int attackDamage=20;
    Rigidbody2D enemy;
    Vector2 attackForceScale;
    public float attackForce=10;
    public float cooldown=1;
    private Cooldown attackCD;

    void Start(){
        attackCD=new Cooldown(cooldown);
        enemy=GetComponent<Rigidbody2D>();
        attackForceScale=new Vector2(attackForce,(float)(attackForce*1.3));
    }
    
    public void PerformAttack(Vector2 target){
        if (attackCD.IsPassed()) {
            DashAttack(target);
            attackCD.LeaveTimeStamp();
        }
    }

    void DashAttack(Vector2 target){
        enemy.AddForce(Vector2.Scale(new Vector2(target.x-transform.position.x,target.y-transform.position.y+20).normalized,attackForceScale),ForceMode2D.Impulse);
    }

    void DealDamage(GameObject victim, int damage){
        victim.GetComponent<Health>().takeDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D colider){
        try{DealDamage(colider.gameObject, attackDamage);}
        catch{}
    } 
}

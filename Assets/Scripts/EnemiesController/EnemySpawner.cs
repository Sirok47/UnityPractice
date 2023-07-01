using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    public float spawnInterval=5;
    public GameObject detector;
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy",5);
    }

    void SpawnEnemy(){
        Vector3 spawnLocation = new Vector3(player.transform.position.x+rnd.Next(5,10)*(rnd.Next(0,1)==0?1:-1),player.transform.position.y+4,0);
        GameObject nuCheTam=Instantiate(detector,spawnLocation,new Quaternion());
        if (nuCheTam.GetComponent<CollisionDetector>().IsClear()){
            Instantiate(enemy,spawnLocation,new Quaternion());
        }
        Invoke("SpawnEnemy",spawnInterval);
    }
}



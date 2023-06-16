using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;



public class PodrivHohlov : MonoBehaviour
{
    public int kievVzorvetsyaCherez;

    // Start is called before the first frame update
    void Start()
    {
        Thread.Sleep(kievVzorvetsyaCherez); 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

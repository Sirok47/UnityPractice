using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cooldown
{   
    private DateTime cd;
    private DateTime timeStamp;
    // Start is called before the first frame update
    public Cooldown(float cooldown){
        cd=new DateTime().AddSeconds((int)cooldown);
    }
    public void LeaveTimeStamp(){
        timeStamp=DateTime.Now;
    }
    public bool IsPassed(){
        return DateTime.Now.Subtract(timeStamp)>cd.Subtract(new DateTime());
    }
    public TimeSpan GetCurrentCD(){
        return cd.Subtract(new DateTime()).Subtract(DateTime.Now.Subtract(timeStamp));
    }
}

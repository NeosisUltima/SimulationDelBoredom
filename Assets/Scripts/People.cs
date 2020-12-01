using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class People
{
    public Color co;
    public float age;
    public int gender;
    public float deathRate;
    public float killRate;
    public float deathAge;

    public People(Color color, int gender,float deathrate, float killrate,float deathAge)
    {
        co = color;
        this.age = 0;
        this.gender = gender;
        deathRate = deathrate;
        killRate = killrate;
        this.deathAge = deathAge;
    }

    public People(People p,int gender)
    {
        co = p.co;
        this.age = 0;
        this.gender = gender;
        deathRate = p.deathRate;
        killRate = p.killRate;
        deathAge = p.deathAge;
    }

}

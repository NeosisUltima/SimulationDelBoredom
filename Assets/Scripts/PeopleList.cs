using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleList : MonoBehaviour
{
    //Keeps a list of people types that can easily be updated if necessary
    public List<People> PeopleTypes;

    // Start is called before the first frame update
    void Awake()
    {
        PeopleTypes = new List<People>
        {
            new People(Color.red,Random.Range(1,3),0.1f,2.0f,60f),
            new People(new Color(0.4406737f,0.08410467f,0.6603774f),Random.Range(1,3),.24f,0.75f,55f),
            new People(Color.blue,Random.Range(1, 3),.15f,0.3f,65f),
            new People(Color.green,Random.Range(1, 3),.2f,0.2f,70f),
            new People(Color.yellow,Random.Range(1, 3),.25f,0.243f,80f),
            new People(new Color(1f,0.3872941f,0f),Random.Range(1, 3),.17f,0.5f,75f)
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Person : MonoBehaviour
{
    public People thisPerson;
    private SpriteRenderer sr;
    private Transform myTrans;
    private BoxCollider2D bc2d;
    //private bool outOfField = false;
    private bool gaveBirth = false;
    public bool OutOfField = false;

    public int adultAge = 0;
    [SerializeField]
    private PeopleList pl;
    public GameObject PersonPrefab;

    public float killChance = 0;
    public float birthChance = 90f;

    [SerializeField]
    private float moveDistance = 10f;
    [SerializeField]
    private float moveRate = 3f;
    [SerializeField]
    private float ageRate = 5f;
    private float agetime = 0f;
    private float movetime = 0f;
    private float birthRate = 4f;
    private float birthtime = 0f;
    private float deathRate = 8f;
    private float deathTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<PeopleList>();
        myTrans = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        killChance = thisPerson.killRate;
    }

    //Moves a person a certain distance
    public void MovePerson()
    {
        transform.localPosition += new Vector3((Random.Range(moveDistance * -1, moveDistance)), (Random.Range(moveDistance * -1, moveDistance)),0);
    }

    //Checks to see if a person dies based on the death rate
    public void Death()
    {
        float chance = Random.Range(0f, 1.0f);
        if(chance < thisPerson.deathRate)
        {
            GameObject.Find("Population").GetComponent<PeopleLibrary>().death++;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = thisPerson.co;

        movetime += Time.deltaTime;
        agetime += Time.deltaTime;
        deathTime += Time.deltaTime;

        if (OutOfField)
        {
            myTrans.localPosition = new Vector2(0f, 0f);
            OutOfField = false;
        }

        if (gaveBirth)
        {
            birthtime += Time.deltaTime;
            if(birthtime >= birthRate)
            {
                gaveBirth = false;
                birthtime = 0;
            }
        }

        if(movetime >= moveRate)
        {
            MovePerson();

            movetime = 0;
        }

        if(agetime >= ageRate)
        {
            thisPerson.age++;
            agetime = 0;
        }

        if(thisPerson.age >= thisPerson.deathAge)
        {
            Death();
        }


        if (deathTime >= deathRate)
        {
            Death();
            deathTime = 0;
        }
    }

    //Reupdates list and destroys object
    public void Kill(GameObject obj)
    {
        GameObject.Find("Population").GetComponent<PeopleLibrary>().kills++;
        GameObject.Find("Population").GetComponent<PeopleLibrary>().death++;
        Destroy(obj);
    }

    //Creates a new person after 2 People collide with each other.
    public void Birth(People myColor, People theirColor)
    {
        GameObject babyObject;
        babyObject = Instantiate(PersonPrefab,this.transform.parent, false);       


        if (myColor.co == Color.red)
        {
            int chance = Random.Range(1, 4);
            if (theirColor.co == Color.yellow)
            {
                if(chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[0];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[5];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[4];
            }
            if (theirColor.co == Color.blue)
            {
                if (chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[0];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[1];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[2];
            }
            if (theirColor.co == Color.red)
            {
                babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[0];
            }

        }
        else if (myColor.co == Color.blue)
        {
            int chance = Random.Range(1, 4);

            if (theirColor.co == Color.yellow)
            {
                if (chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[2];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[3];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[4];
            }
            if (theirColor.co == Color.red)
            {
                if (chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[2];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[1];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[0];
            }
            if (theirColor.co == Color.blue)
            {
                babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[2];
            }
        }
        else if (myColor.co == Color.yellow)
        {
            int chance = Random.Range(1, 4);

            if (theirColor.co == Color.red)
            {
                if (chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[4];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[5];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[0];
            }
            if (theirColor.co == Color.blue)
            {
                if (chance == 1) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[4];
                else if (chance == 2) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[3];
                else if (chance == 3) babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[2];
            }
            if (theirColor.co == Color.yellow)
            {
                babyObject.GetComponent<Person>().thisPerson = pl.PeopleTypes[4];
            }
        }
        else
        {
            int chance = Random.Range(1, 3);
            if (chance == 1)
                babyObject.GetComponent<Person>().thisPerson = new People(myColor,Random.Range(1,3));
            else
                babyObject.GetComponent<Person>().thisPerson = new People(theirColor, Random.Range(1, 3));
        }
        gaveBirth = true;
        babyObject.GetComponent<Person>().MovePerson();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    //Check is person is leaving field
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            OutOfField = false;
        }
    }

    //Repositions the person if leaving field
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            float chance = Random.Range(0f, 100f);
            if (chance < killChance)
            {                
                Kill(collision.gameObject);
            }
            else if(chance > killChance && chance <= birthChance)
            {
                if (thisPerson.age >= adultAge && collision.gameObject.GetComponent<Person>().thisPerson.age >= adultAge && !gaveBirth)
                {
                    Birth(thisPerson, collision.gameObject.GetComponent<Person>().thisPerson);
                }
            }
        }

        if (collision.gameObject.tag == "Environment")
        {
            OutOfField = true;
        }
    }
}

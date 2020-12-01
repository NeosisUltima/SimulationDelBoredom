using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetEnvironment : MonoBehaviour
{
    private TitleSettings ts;
    private SpriteRenderer sr;
    private Transform gTrans;
    private BoxCollider2D bc2d;
    private int MaxPopulation = 500;
    [SerializeField]
    private PeopleList pl;

    public GameObject PersonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ts = GameObject.Find("SetUpNextScene").GetComponent<TitleSettings>();
        bc2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        gTrans = GetComponent<Transform>();
        SetUpSize();
        pl = GetComponent<PeopleList>();
        SetUpPopulation();
        Destroy(ts.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPopulation();
    }

    //Checks to see if area is overpopulated
    public void CheckPopulation()
    {
        print(this.gameObject.transform.childCount);
        if(this.gameObject.transform.childCount > MaxPopulation)
        {
            this.gameObject.transform.GetChild(0).GetComponent<Person>().Kill(this.gameObject.transform.GetChild(0).gameObject);
        }
    }

    //Sets up environement size based off title settings
    public void SetUpSize()
    {
        gTrans.localScale = new Vector2(gTrans.localScale.x *(ts.Width/100), gTrans.localScale.y * (ts.Height / 100));
    }


    //Adds a person to the field of a certain color
    public void SetUpPopulation()
    {
        for(int i = 0; i < ts.population; i++)
        {
            int colorchoice = Random.Range(0, 6);
            GameObject set = Instantiate(PersonPrefab, this.transform, true);
            set.GetComponent<Person>().thisPerson = pl.PeopleTypes[colorchoice];
            set.GetComponent<Person>().adultAge = ts.adolescence;
            set.GetComponent<Person>().MovePerson();
        }
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Main");
    }
}

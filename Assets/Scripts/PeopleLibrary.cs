using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeopleLibrary : MonoBehaviour
{
    public TextMeshProUGUI NmRed, NmPurp, NmBlue, NmGrn, NmYellow, NmOrng,NmDeath,NmKills, CurPop;
    public int death = 0, kills = 0, pop = 0;
    public GameObject Environment;
    // Start is called before the first frame update
    void Start()
    {
    }

    //Updates the information given on the left side of the program.
    public void UpdateList()
    {
        int red = 0;
        int blue = 0;
        int yellow = 0;
        int purple = 0;
        int green = 0;
        int orange = 0;
        pop = 0;
        foreach(Transform t in Environment.transform)
        {
            People thisP = t.gameObject.GetComponent<Person>().thisPerson;
            if (thisP.co == Color.red) red += 1;
            else if (thisP.co == new Color(0.4406737f, 0.08410467f, 0.6603774f)) purple += 1;
            else if (thisP.co == Color.blue) blue += 1;
            else if (thisP.co == Color.green) green += 1;
            else if (thisP.co == Color.yellow) yellow += 1;
            else if (thisP.co == new Color(1f,0.3872941f,0f)) orange += 1;
            pop++;

        }

        NmRed.text = red.ToString();
        NmPurp.text = purple.ToString();
        NmBlue.text = blue.ToString();
        NmGrn.text = green.ToString();
        NmYellow.text = yellow.ToString();
        NmOrng.text = orange.ToString();
        NmKills.text = kills.ToString();
        NmDeath.text = death.ToString();
        CurPop.text = "Pop: " + pop;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateList();
    }
}

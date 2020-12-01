using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSettings : MonoBehaviour
{

    public int Width = 0;
    public int Height = 0;
    public int population = 0;
    public int adolescence = 0;
    public int MaxHeight = 500;
    public int MaxWidth = 500;
    public TMP_InputField HeightSet, WidthSet, PopSet,AgeSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //set environment width
    public void SetWidth(string i)
    {
        Width = Convert.ToInt32(i);
        if(Width < 50)
        {
            Width = 50;
        }
        else if (Height > MaxWidth)
        {
            Height = MaxWidth;
        }
    }
    //sets environment height
    public void SetHeight(string i)
    {
        Height = Convert.ToInt32(i);
        if (Height < 50)
        {
            Height = 50;
        }
        else if (Height > MaxHeight)
        {
            Height = MaxHeight;
        }
    }
    //sets starting population size
    public void SetPopulation(string i)
    {
        population = Convert.ToInt32(i);

        if(population < 10)
        {
            population = 10;
        }
        else if (population > 1000)
        {
            population = 1000;
        }
    }
    //Sets age person can start having children
    public void SetAdultAge(string i)
    {
        adolescence = Convert.ToInt32(i);

        if (adolescence < 10)
        {
            population = 10;
        }
        else if (adolescence > 20)
        {
            population = 20;
        }
    }

    public void SetButton()
    {
        SetWidth(WidthSet.text);
        SetHeight(HeightSet.text);
        SetPopulation(PopSet.text);
        SetAdultAge(AgeSet.text);
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Environment");
    }
}

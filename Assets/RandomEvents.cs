using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class RandomEvents : MonoBehaviour
{
    public int sandalyaRandom;
    public int paltoRandomizer; // günahlar,sevaplar
    public int hayvanTipi;
    public int cicekRandomizer;

    public int YearLoop;
    public static int shoes;
    public static int scenarioWomanOrKid;
    public int ScenarioGoodOrBad;

    public GameObject palto;
    public static bool isBadPalto;
    [SerializeField] GameObject[] SandalyePelus;
    [SerializeField] GameObject[] cicektip;
    void Start()
    {
        sandalyaRandom =UnityEngine.Random.Range(0,3);
        paltoRandomizer = UnityEngine.Random.Range(0, 2);
        hayvanTipi = UnityEngine.Random.Range(0, 2);
        cicekRandomizer = UnityEngine.Random.Range(0, 3);
        shoes = UnityEngine.Random.Range(0,2);


        scenarioWomanOrKid = UnityEngine.Random.Range(1, 3);
        ScenarioGoodOrBad = UnityEngine.Random.Range(1, 3);

        if(scenarioWomanOrKid == 2)
            YearLoop = UnityEngine.Random.Range(2006, 2013);
        else 
            YearLoop = UnityEngine.Random.Range(1970, 1990);

        if (ScenarioGoodOrBad == 1)
            isBadPalto = true;
        else
            isBadPalto = false;



        SandalyePelus[sandalyaRandom].SetActive(true);
        cicektip[cicekRandomizer].SetActive(true);
    }

    // Update is called once per frame
    
}

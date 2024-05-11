using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DataCheckSO_Question : MonoBehaviour
{
    public SO_QuestionScript[] SODatabase_Question;                                                                                 
    public GameObject[] Cards;
    public int listnumber;
   

    private void Start()
    {
        int pp = 2;
        PlayerPrefs.SetInt("quest1", pp);
        Invoke("ListManager", 0);
        Invoke("trueAnswer", 0);
    }
   

    private void OnEnable()
    {
        ClickedControl.isClicked += classWorks;
    }
    private void OnDisable()
    {
        ClickedControl.isClicked -= classWorks;
    }
    void classWorks()
    {
        objectNumberIncrease();
        ListManager();
        trueAnswer();
    }
    private void objectNumberIncrease()
    {
        Debug.Log("touch");
        if (listnumber < SODatabase_Question.Length - 1)
            listnumber = listnumber + 1;
    }
    void ListManager()
    {
        Cards[0].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[0].answer;
        Cards[1].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[1].answer;
        Cards[2].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[2].answer;
    }
    void trueAnswer()
    {
        for (int i = 0; i < SODatabase_Question[listnumber].answerSODatas.Count; i++)
        {
            if (SODatabase_Question[listnumber].answerSODatas[i].indexes == PlayerPrefs.GetInt(SODatabase_Question[listnumber].answerSODatas[i].playerPrefsName))
            {
                SODatabase_Question[listnumber].answerSODatas[i].isTrue = true;
                Debug.Log(PlayerPrefs.GetInt(SODatabase_Question[listnumber].answerSODatas[i].playerPrefsName));
            }
        }

    }






}

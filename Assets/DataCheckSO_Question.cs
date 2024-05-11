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

    [SerializeField] TextMeshProUGUI text;
    public string lines;
    public float textSpeed;
    
    
    private void Start()
    {
        string a = "quest1Index1";
        PlayerPrefs.SetString(a, a);
        Invoke("ListManager", 0);
        Invoke("trueAnswer", 0);
        StartCoroutine(TypeLine());
        CardCount();
        SystemSaveTool.instance.LoadJson();
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
        trueAnswer();
        nextDialogue();
        CardCount();
    }
    private void objectNumberIncrease()
    {
        Debug.Log("touch");
        if (listnumber < SODatabase_Question.Length - 1)
            listnumber = listnumber + 1;
    }
   
    void trueAnswer()
    {
        for (int i = 0; i < SODatabase_Question[listnumber].answerSODatas.Count; i++)
        {

            if (PlayerPrefs.HasKey(SODatabase_Question[listnumber].answerSODatas[i].QuestBasedTrueValue))
            {
                SODatabase_Question[listnumber].answerSODatas[i].isTrue = true;
                Debug.Log(PlayerPrefs.GetInt(SODatabase_Question[listnumber].answerSODatas[i].QuestBasedTrueValue));
                if (SODatabase_Question[listnumber].answerSODatas[i].QuestBasedTrueValue == "")
                    Debug.Log("playerprefs ismi gir " + listnumber + " " + i);
            }
            else
                SODatabase_Question[listnumber].answerSODatas[i].isTrue = false;


        }

    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void CardCount()
    {
        foreach(GameObject i in Cards)
        {
            i.gameObject.SetActive(false);
        }

        for (int i = 0; i < SODatabase_Question[listnumber].answerSODatas.Count; i++)
        {
            
            if (PlayerPrefs.HasKey(SODatabase_Question[listnumber].answerSODatas[i].FoundCheckName))
            {
                Cards[i].gameObject.SetActive(true);
                Cards[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[i].answer;
            }
               

        }
    }
    void nextDialogue()
    {
        text.text = String.Empty;
        lines = SODatabase_Question[listnumber].question;
        StartCoroutine(TypeLine());
    }





}

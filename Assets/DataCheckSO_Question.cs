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
    int cardChecker;

    [SerializeField] TextMeshProUGUI text;
    public string lines;
    public float textSpeed;
    
    
    private void Start()
    {
        
        Invoke("ListManager", 0);
        Invoke("trueAnswer", 0);
        StartCoroutine(TypeLine());
        SystemSaveTool.instance.LoadJson();
        CardCount();
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
        for (int b = 0; b < SODatabase_Question[listnumber].answerSODatas.Count; b++)
        {

            if (SODatabase_Question[listnumber].answerSODatas[b].QuestCheck == true)
            {
                if (SystemSaveTool.instance.booleans.BoyFavoriteAnimal == SODatabase_Question[listnumber].answerSODatas[b].answer || SystemSaveTool.instance.booleans.FavoriteFlower == SODatabase_Question[listnumber].answerSODatas[b].answer)
                     SODatabase_Question[listnumber].answerSODatas[b].isTrue = true;
                else
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = false;
            }
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
        foreach(string i in SystemSaveTool.instance.booleans.dataCheck)
        {
            for (int b = 0; b < SODatabase_Question[listnumber].answerSODatas.Count; b++)
            {

                if (SODatabase_Question[listnumber].answerSODatas[b].FoundCheckName == i)
                {
                    cardChecker = cardChecker + 1;
                    Cards[cardChecker].gameObject.SetActive(true);
                    Cards[cardChecker].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[b].answer;
                }
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

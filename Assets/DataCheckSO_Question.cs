using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class DataCheckSO_Question : MonoBehaviour
{
    public SO_QuestionScript[] SODatabase_Question;                                                                                 
    public GameObject[] Cards;
    public GameObject[] CardIdles;
    public int listnumber;
    int cardChecker;
    int i = 0;
    [SerializeField] TextMeshProUGUI text;
    public string lines;
    public float textSpeed;

    bool isBoyAnimalCheck;
    bool FavoriteFlower;
    bool shoeAnimType;

    int trueCounter;
    int falseCounter;

    private void Start()
    {
        Invoke("CardRest", 0);
        Invoke("ListManager", 0);
        Invoke("trueAnswer", 0);
        Invoke("nextDialogue", 0);
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
        checkTrue();
        objectNumberIncrease();
        trueAnswer();
        nextDialogue();
        CardCount();
        CoroutineTextEvent();
    }
    private void objectNumberIncrease()
    {
        Debug.Log(PlayerPrefs.GetInt("inputGo"));
        Debug.Log("touch");
        if (listnumber < SODatabase_Question.Length-1)
            listnumber = listnumber + 1;
        cardChecker = 0;
        Cards[cardChecker].GetComponent<SpriteRenderer>().DOFade(0, .5f);
    }
   
    void trueAnswer()
    {
        for (int b = 0; b < SODatabase_Question[listnumber].answerSODatas.Count; b++)
        {

            if (SODatabase_Question[listnumber].answerSODatas[b].QuestCheck == true)
            {
                if((SystemSaveTool.instance.booleans.BoyFavoriteAnimal == SODatabase_Question[listnumber].answerSODatas[b].answer) && !isBoyAnimalCheck)
                {
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = true;
                    isBoyAnimalCheck = true;
                }
                else
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = false;

                if((SystemSaveTool.instance.booleans.FavoriteFlower == SODatabase_Question[listnumber].answerSODatas[b].answer) && !FavoriteFlower)
                {
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = true;
                    FavoriteFlower = true;
                }
                else
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = false;

                if((SystemSaveTool.instance.booleans.shoeAnimType == SODatabase_Question[listnumber].answerSODatas[b].answer) && !shoeAnimType)
                {
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = true;
                    shoeAnimType = true;
                }
                else
                {
                    SODatabase_Question[listnumber].answerSODatas[b].isTrue = false;
                    
                }

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
        foreach (GameObject i in Cards)
        {
            i.gameObject.SetActive(false);
        }

        foreach (string i in SystemSaveTool.instance.booleans.dataCheck)
        {
            for (int b = 0; b < SODatabase_Question[listnumber].answerSODatas.Count; b++)
            {

                if (SODatabase_Question[listnumber].answerSODatas[b].FoundCheckName == i)
                {
                    Cards[cardChecker].GetComponent<SpriteRenderer>().DOFade(1,.5f);
                    Cards[cardChecker].gameObject.SetActive(true);
                    Cards[cardChecker].GetComponent<SpriteRenderer>().sprite = SODatabase_Question[listnumber].answerSODatas[b].sprite;
                    Cards[cardChecker].transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SODatabase_Question[listnumber].answerSODatas[b].answer;
                    cardChecker = cardChecker + 1;
                 
                }
               
               
            }
           
        }
        
    }

    void CoroutineTextEvent()
    {
        StopAllCoroutines();
        text.text = string.Empty;
        StartCoroutine(TypeLine());

    }

    void checkTrue()
    {
        Debug.Log(PlayerPrefs.GetInt("inputGo"));
        
        if (SODatabase_Question[listnumber].answerSODatas[PlayerPrefs.GetInt("inputGo")].isTrue)
        {
            trueCounter++;
            Debug.Log("true");
        }
        else if(SODatabase_Question[listnumber].answerSODatas[PlayerPrefs.GetInt("inputGo")].isTrue == false)
        {
            falseCounter++;
            Debug.Log("false");
        }
        
    }
 
    void nextDialogue()
    {

        
        if (i < 4)
        {
            text.text = String.Empty;
            lines = SODatabase_Question[i].question;
            StartCoroutine(TypeLine());
            i = i + 1;
        }
        else if (i == 4)
        {
            if (trueCounter > falseCounter)
                SceneManager.LoadScene(2);
            else if(trueCounter<= falseCounter)
                SceneManager.LoadScene(3);

        }
            Debug.Log("end");

        Debug.Log(i);
    }
    
}

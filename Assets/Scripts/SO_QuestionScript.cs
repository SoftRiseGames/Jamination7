using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestionSO", menuName = "ScriptableObjects/QuestionSO")]
public class SO_QuestionScript : ScriptableObject
{
    public List<SO_AnswerScript> answerSODatas;
    public string question;
}

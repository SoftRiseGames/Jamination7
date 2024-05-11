
using UnityEngine;
[CreateAssetMenu(fileName = "AnswerSO", menuName = "ScriptableObjects/AnswerSO")]
public class SO_AnswerScript : ScriptableObject
{
    public string answer;
    public string playerPrefsName;
    public int indexes;
    public bool isTrue;
    public bool isSpecialQuestion;
    public SO_QuestionScript nextQuestion;
  
}

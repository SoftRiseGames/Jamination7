
using UnityEngine;
[CreateAssetMenu(fileName = "AnswerSO", menuName = "ScriptableObjects/AnswerSO")]
public class SO_AnswerScript : ScriptableObject
{
    public string answer;
    public string TrueIndexControl;
    public string FoundCheckName;
    public int indexes;
    public bool isTrue;
    public bool isSpecialQuestion;
    public SO_QuestionScript nextQuestion;
}

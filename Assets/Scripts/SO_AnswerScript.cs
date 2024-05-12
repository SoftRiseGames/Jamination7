
using UnityEngine;
[CreateAssetMenu(fileName = "AnswerSO", menuName = "ScriptableObjects/AnswerSO")]
public class SO_AnswerScript : ScriptableObject
{
    public string answer;
    public string FoundCheckName;
    public bool QuestCheck;
    public bool isTrue;
    public bool isSpecialQuestion;
    public SO_QuestionScript nextQuestion;
    public Sprite sprite;
}

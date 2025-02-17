using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set {; } 
    }
    [SerializeField]private TMP_Text _questionText;
    [SerializeField] private TMP_Text[] _answers = new TMP_Text[3];
    [SerializeField] private Vector2 _randomnessRange;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        ChangeQuestionText("70 + 8 ?");
    }
    void ChangeQuestionText(string questionString)
    {
        _questionText.text = questionString;
        ChangeAnswers(78);
    }
    void ChangeAnswers (int correctValue)
    {
        int randomAnswer = Random.Range(0,_answers.Length - 1);
        TMP_Text correctAnswer = _answers[randomAnswer];
        foreach(TMP_Text answer in _answers)
        {
            if(answer == correctAnswer)
            {
                answer.text = correctValue.ToString();
            }
            else
            {
                int offset = (int)Random.Range(_randomnessRange.x, _randomnessRange.y);
                while(offset == 0)
                {
                     offset = (int)Random.Range(_randomnessRange.x, _randomnessRange.y);
                }
                answer.text = (correctValue + offset).ToString();

            }
        }
    }
    
}

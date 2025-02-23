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
    [SerializeField] private Vector2 _answersRandomnessRange;
    [SerializeField] Vector2Int[] _randomQuestionAnswers = new Vector2Int[2];
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
        ChangeQuestionText();
    }
     public void ChangeQuestionText()
    {
        int result;
        Vector2Int paramater = CreateEquation(out result);
        _questionText.text = paramater.x + " + " + paramater.y + " ?";
        ChangeAnswers(result);
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
                int offset = (int)Random.Range(_answersRandomnessRange.x, _answersRandomnessRange.y);
                while(offset == 0)
                {
                     offset = (int)Random.Range(_answersRandomnessRange.x, _answersRandomnessRange.y);
                }
                answer.text = (correctValue + offset).ToString();

            }
        }
    }
    Vector2Int CreateEquation(out int result)
    {
        int first = Random.Range(_randomQuestionAnswers[0].x, _randomQuestionAnswers[0].y);
        int second = Random.Range(_randomQuestionAnswers[1].x, _randomQuestionAnswers[1].y);
        result = first + second;
        return new Vector2Int(first, second);
        
    }
    
}

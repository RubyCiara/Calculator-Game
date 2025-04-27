using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

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
    [SerializeField] List<EquationType> equationTypes;
    private int _currentCorrectAnswer;
    private EquationType _currentEquationType;
    public Slider hSlider;
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
        EventBus<SelectAnswer>.OnEvent += CheckAnswer;
    }
    void Start()
    {
        ChangeQuestionText();
        hSlider.value = 40;
    }
    private void OnDestroy()
    {
        EventBus<SelectAnswer>.OnEvent -= CheckAnswer;
    }
    public void ChangeQuestionText()
    {
        int result;
        int randomEquation = Random.Range(0, equationTypes.Count);
        _currentEquationType = equationTypes[randomEquation];
        Vector2Int paramater = _currentEquationType.CreateEquation(_randomQuestionAnswers[0], _randomQuestionAnswers[1], out result);
        switch (_currentEquationType)
        {
            case Addition:
                _questionText.text = paramater.x +" + " +paramater.y + " ?";
                break;
            case Substraction:
                _questionText.text = paramater.x + " - " + paramater.y + " ?";
                break;
            case Multiplication:
                _questionText.text = paramater.x + " x " + paramater.y + " ?";
                break;
            case Division:
                _questionText.text = paramater.x + " : " + paramater.y + " ?";
                break;
            default:
                _questionText.text = paramater.x + " @ " + paramater.y + " ?";
                Debug.LogError("Invalid EquationType");
                break;
        }
        ChangeAnswers(result);
    }
    void ChangeAnswers (int correctValue)
    {
        _currentCorrectAnswer = correctValue;
        int randomAnswer = Random.Range(0,_answers.Length);
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

    void CheckAnswer(SelectAnswer e) 
    {
        if (e.answer == _currentCorrectAnswer)
        {
            Debug.Log("correctAnswer");
            ChangeQuestionText();
        }
        else
        {
            Debug.Log("Try Again");
            hSlider.value -= 10;
            if (hSlider.value == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
           
        }
    }
    
}

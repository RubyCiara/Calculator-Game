using UnityEngine;
using TMPro;


public class AnswersButtonScript : MonoBehaviour
{
    [SerializeField]private TMP_Text _buttonText;

public void BroadcastAnswer()
    {
        string text = _buttonText.text;
        int answerValue;
        int.TryParse(text, out answerValue);
        EventBus<SelectAnswer>.Publish(new SelectAnswer(answerValue));
       
    }
}


using UnityEngine;
using TMPro;

public class AddAnswer : MonoBehaviour
{
    public TextMeshPro AnswerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //if there is an answer text, assign the anwser from the generate answer equation script
        if (AnswerText == null)
        {
            Debug.Log("Text is not assigned");
        }
        var newEquation = EquationGeneration.GenerateRandomEquation();
        AnswerText.text = newEquation.xValue.ToString();
    }

    
}
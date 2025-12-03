using UnityEngine;
using TMPro;

public class AddAnswer : MonoBehaviour
{
    public TextMeshPro AnswerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (AnswerText == null)
        {
            Debug.Log("Text is not assigned");
        }
        var newEquation = EquationGeneration.GenerateRandomEquation();
        AnswerText.text = newEquation.xValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
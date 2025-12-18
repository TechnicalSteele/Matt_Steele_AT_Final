using UnityEngine;
using TMPro;

public class AnswerBoxs : MonoBehaviour
{
    public TextMeshPro AnswerText;

    public void SetValue(int value)
    {
        AnswerText.text = value.ToString();
    }
    
    
}

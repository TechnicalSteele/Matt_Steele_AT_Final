using TMPro;
using UnityEngine;

public class AddValue : MonoBehaviour
{

    public TextMeshPro EquationText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //if there is an equation, add the equation that was randomly generated from equation generation
        if(EquationText ==  null)
        {
            Debug.Log("Text is not assigned");
        }
        var newEquation = EquationGeneration.GenerateRandomEquation();
        EquationText.text = newEquation.equation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using TMPro;
using UnityEngine;

public class AddValue : MonoBehaviour
{

    public TextMeshPro EquationText;

    

    

    private void Awake()
    {
        //if there is no equation, add the equation that was randomly generated from equation generation
        if (EquationText == null)
        {
            Debug.Log("Text is not assigned");
        }
        var newEquation = EquationGeneration.RandomEquation();
        EquationText.text = newEquation.equation;

    }

    private void OnDestroy()
    {
        EquationText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections.Generic;

public class OnButtonPress : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Button button;
    //public GameObject EquationSpawn;
    public TextMeshPro ButtonEquationText;
    [SerializeField] private List<AnswerBoxs> answerBoxes;
    [SerializeField] private int answerOffset = 5;
    private int correctAnswer;
    

    private void Start()
    {
        Button equationBtn = button.GetComponent<Button>();
        equationBtn.onClick.AddListener(OnClick);
    }

   

    /* Equation did not spawn, Thank you Unity Docs! (https://docs.unity3d.com/530/Documentation/ScriptReference/UI.Button-onClick.html)
     * public void Spawn()
    {
        Debug.Log("Should work here?");
    }
   
    */

    private void OnClick()
    {

        if (ButtonEquationText == null)
        {
            Debug.Log("Text is not assigned");
        }
        var newEquation = EquationGeneration.RandomEquation();
        ButtonEquationText.text = newEquation.equation;

        if (answerBoxes == null)
        {
            Debug.Log("Text is not assigned");
        }

        
        answerBoxes[Random.Range(0,3)].SetValue(newEquation.xValue);
        newEquation.xValue = correctAnswer;
        RandomBox();

         

        /*GameObject spawned = Instantiate(EquationSpawn,
            socket.attachTransform.position,
            socket.attachTransform.rotation);

        XRGrabInteractable grab = spawned.GetComponent<XRGrabInteractable>();

        if (grab != null)
        {
            socket.StartManualInteraction(grab as IXRSelectInteractable);
        }
        */
        Debug.Log("Button Pressed!!");
    }

    private void RandomBox()
    {
        
        int randomNumber;
        for(int i = 1; i < answerBoxes.Count; i++)
        {
            
            int minNumber = correctAnswer - answerOffset;
            int maxNumber = correctAnswer + answerOffset;
            randomNumber = Random.Range(minNumber, maxNumber);

            if(randomNumber != correctAnswer)
            {
                answerBoxes[i].SetValue(randomNumber);
            }
            
            
        }
    }
    
}

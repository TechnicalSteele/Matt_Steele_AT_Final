using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    private float buttonCooldown;
    

    //https://www.youtube.com/watch?v=tcatvGLvCDc&t=752s great video on statics
    //took use of {get; private set} used it differently (i dont need 200 of them)
    public static int TheCorrectAnswer { get; private set;}
    

    private void Start()
    {
        
       button.onClick.AddListener(OnClick);
    }

   

    /* Equation did not spawn, Thank you Unity Docs! (https://docs.unity3d.com/530/Documentation/ScriptReference/UI.Button-onClick.html)
     * public void Spawn()
    {
        Debug.Log("Should work here?");
    }
   
    */

    private void OnClick()
    {

        //if (ButtonEquationText == null)
        //{
           // Debug.Log("Text is not assigned");
       // }
       if(buttonCooldown <= 0)
        {
            buttonCooldown = 0.5f;
        }
        var newEquation = EquationGeneration.RandomEquation();
        ButtonEquationText.text = newEquation.equation;

        if (answerBoxes == null)
        {
            Debug.Log("Text is not assigned");
        }

        //was accidently resetting the xvalue to 0 as correctAnswer is not given a value
         //answerBoxes[Random.Range(0,3)].SetValue(newEquation.xValue);
        //newEquation.xValue = correctAnswer;
        //sets correctAnswer to what ever the answer to the equation is
        correctAnswer = newEquation.xValue;
        TheCorrectAnswer = correctAnswer;
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

    private void Update()
    {
        if(buttonCooldown <= 0)
        {
            buttonCooldown -= Time.deltaTime;
        }
    }

    

    private void RandomBox()
    {

        //Sets a random box to a random prefab
        // https://www.youtube.com/watch?v=uAmbzST1mS0 - link to tutorial where I took int correctBox = Random.Range(0, answerBoxes.Count); from
        
        int correctBox = Random.Range(0, answerBoxes.Count);
        
        //sets that prefab to have the correct answer
        answerBoxes[correctBox].SetValue(correctAnswer);
        
        for(int i = 0; i < answerBoxes.Count; i++)
        {
            int minNumber = correctAnswer - answerOffset;
            int maxNumber = correctAnswer + answerOffset;
            int randomNumber = Random.Range(minNumber,maxNumber);

            //if in the loop, the correctbox is chosen, igonore it.
            //I previously didnt have this check so correct box got overridden to be a wrong answer.
            if ( i == correctBox)
            {
                continue;
            }
           
            while (randomNumber == correctAnswer)
            {
                randomNumber = Random.Range(minNumber, maxNumber);

            }
            answerBoxes[i].SetValue(randomNumber);


        }
    }
    
}

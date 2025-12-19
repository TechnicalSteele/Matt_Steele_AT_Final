using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;


public class IsRight : MonoBehaviour , IPointerClickHandler
{

    [SerializeField] private Material m_AnswerBox;
    [SerializeField] private Material m_Is_Right;
    [SerializeField] private Material m_Is_Wrong;
    private int answer;

    public void OnPointerClick(PointerEventData locationData)
    {
        Debug.Log("this kinda works gang");
       
        
        if(answer == EquationGeneration.RandomEquation().xValue)
        {
            GetComponent<MeshRenderer>().material = m_Is_Right;
        }
        GetComponent<MeshRenderer>().material = m_Is_Wrong;

    }
    



    
}

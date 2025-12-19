using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class AnswerBoxs : MonoBehaviour
{
    public Button button;
    public TextMeshPro AnswerText;
    private int value;
    private int checkAnswer;
    public Material m_Is_Right;
    public Material m_Is_Wrong;
    public Material m_Is_Norm;
    private float AnswerTime;

    private MeshRenderer render;

    private void Start()
    {
        button.onClick.AddListener(OnAnswerClick);
    }

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }

    public void SetValue(int updateValue)
    {
        value = updateValue;
        
        AnswerText.text = updateValue.ToString();


    }
    public void Update()
    {
        if (AnswerTime >= 0)
        {
            AnswerTime -= Time.deltaTime;
        }

        else if (AnswerTime <= 0)
        {
            render.material = m_Is_Norm;
        }
    }


    private void OnAnswerClick()
    {
        
        Debug.Log(checkAnswer);

        if (AnswerTime <= 0)
        {
            AnswerTime = 2.5f;
        }
            if (value == OnButtonPress.TheCorrectAnswer)
            {
                Debug.Log("it works yay");
                render.material = m_Is_Right;
            }
            else
            {
                Debug.Log("Nope :(");
                render.material = m_Is_Wrong;
            }

        

        

    }
    
    
}

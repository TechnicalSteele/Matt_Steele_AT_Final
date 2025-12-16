using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WhiteBoardPlace : MonoBehaviour
{

    [SerializeField] private InputActionReference confirmPress;
    [SerializeField] private GameObject WhiteboardSpawn;
    [SerializeField] private GameObject Preview;

    private bool confirmed;

    XRGrabInteractable interactable;

    private void Awake()
    {
        Debug.Log("PlaceScript is on");
        interactable = GetComponent<XRGrabInteractable>();
    }
    public  void OnEnable()
    {
        Debug.Log("Please?");
        //HoldInteraction. -= confirmWhiteBoard;
        confirmPress.action.Enable();

    }
    private void OnDisable()
    {
        confirmPress.action.performed -= confirmWhiteBoard;
    }
    
    
    /*private void OnDestroy()
    {
        Debug.Log("Destroyed!!");
    }
    purely for testing to see if script was implementing correctly
   */ 



    void confirmWhiteBoard(InputAction.CallbackContext callback)
    {
        if(confirmed)
        {
            return;
        }
        confirmed = true;
        Debug.Log("It Works!");

        Instantiate(WhiteboardSpawn, transform.position,transform.rotation);
        Destroy(Preview);
    }

}

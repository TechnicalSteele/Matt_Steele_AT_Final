using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WhiteBoardPlace : MonoBehaviour
{
    XRGrabInteractable interactable;

    private void Awake()
    {
        Debug.Log("PlaceScript is on");
        interactable = GetComponent<XRGrabInteractable>();
    }
    public  void OnEnable()
    {
        Debug.Log("Please?");
        interactable.selectEntered.AddListener(confirmWhiteBoard);
    }
    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(confirmWhiteBoard);
    }
    private void OnDestroy()
    {
        Debug.Log("Destroyed!!");
    }


    void confirmWhiteBoard(SelectEnterEventArgs args)
    {
        Debug.Log("It Works!");
    }

}

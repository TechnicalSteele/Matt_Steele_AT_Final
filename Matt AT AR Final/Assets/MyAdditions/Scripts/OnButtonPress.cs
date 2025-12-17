using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.UI;

public class OnButtonPress : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Button button;
    public GameObject EquationSpawn;

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
        GameObject spawned = Instantiate(EquationSpawn,
            socket.attachTransform.position,
            socket.attachTransform.rotation);

        XRGrabInteractable grab = spawned.GetComponent<XRGrabInteractable>();

        if (grab != null)
        {
            socket.StartManualInteraction(grab as IXRSelectInteractable);
        }
        Debug.Log("Button Pressed!!");
    }
    
}

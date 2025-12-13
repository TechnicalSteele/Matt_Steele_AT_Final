using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Offsets : MonoBehaviour
{
    //2 offsets that can be chaged in inspector, one for spawning and one for while grabbing

    public Vector3 offset = new Vector3(0, 0.2f, 0);
    public Vector3 grabOffset = new Vector3(0, 0.25f, 0);

    private XRGrabInteractable grabInteractable;
    private GameObject attachPoint;



    void Start()
        
    {
        //dont think this is needed but keeping incase that changes
        transform.position += offset;
    }

    private void Awake()
    {
        InitializeGrabInteractable();
         
    }

    private void OnEnable()
    {
        // InitializeGrabInteractable(); called in both awake and onEnable now
        if (grabInteractable == null)
        {
            InitializeGrabInteractable();
        }
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(ApplyGrabOffset);
            grabInteractable.selectExited.AddListener(RemoveGrabOffset);

        }
        
    }
    private void OnDisable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(ApplyGrabOffset);
            grabInteractable.selectExited.RemoveListener(RemoveGrabOffset);

        }
       
    }

    private void InitializeGrabInteractable()
    {

        /*originally in awake but had issues where it would not be active before onEnable 
         * so first few attempts to spawn failed
         * this function is called in both to get rid of that issue
          */
        if(grabInteractable != null)
        {
            return;
        }
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("No GrabInteractable at:", gameObject);
            return;
        }
        if (grabInteractable.attachTransform == null)
        {
            attachPoint = new GameObject("GrabAttachPoint");
            attachPoint.transform.SetParent(transform);
            attachPoint.transform.localPosition = Vector3.zero;
            attachPoint.transform.localRotation = Quaternion.identity;
            grabInteractable.attachTransform = attachPoint.transform;

        }

        else
        {
            attachPoint = grabInteractable.attachTransform.gameObject;
        }

       
    }

    void ApplyGrabOffset(SelectEnterEventArgs args)
    {
        grabInteractable.attachTransform.localPosition = grabOffset;
    }

    void RemoveGrabOffset (SelectExitEventArgs args)
    {
        grabInteractable.attachTransform.localPosition = Vector3.zero;
    }

   
}

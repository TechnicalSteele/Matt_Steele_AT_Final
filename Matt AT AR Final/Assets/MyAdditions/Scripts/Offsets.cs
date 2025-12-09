using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Offsets : MonoBehaviour
{
    //2 offsets that can be chaged in inspector, one for spawning and one for while grabbing

    public Vector3 offset = new Vector3(0, 0.2f, 0);
    public Vector3 grabOffset = new Vector3(0, 0.25f, 0);

    public XRGrabInteractable grabInteractable;
    private Transform originalAttach;
    private GameObject attachPoint;



    void Start()
        
    {
        transform.position += offset;
    }

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        {
            if(grabInteractable.attachTransform == null)
            {
                attachPoint = new GameObject("GrabAttachPoint");
                attachPoint.transform.SetParent(transform);
                grabInteractable.attachTransform = attachPoint.transform;
            }

            else
            {
                attachPoint = grabInteractable.attachTransform.gameObject;
            }

            originalAttach = grabInteractable.attachTransform;

        }
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(ApplyGrabOffset);
        grabInteractable.selectExited.AddListener(RemoveGrabOffset);
    }
    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(ApplyGrabOffset);
        grabInteractable.selectExited.RemoveListener(RemoveGrabOffset);
    }

    void ApplyGrabOffset(SelectEnterEventArgs args)
    {
        grabInteractable.attachTransform.localPosition = grabOffset;
    }

    void RemoveGrabOffset (SelectExitEventArgs args)
    {
        grabInteractable.attachTransform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

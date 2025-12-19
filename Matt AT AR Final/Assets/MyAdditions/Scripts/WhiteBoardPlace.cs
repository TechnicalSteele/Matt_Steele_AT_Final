using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class WhiteBoardPlace : MonoBehaviour
{

    [SerializeField] private InputActionReference confirmPress;
    [SerializeField] private GameObject WhiteboardSpawn;
    [SerializeField] private GameObject Preview;
    [SerializeField] private ObjectSpawner ObjectSpawner;
    

    private static bool placed;
    private static bool previewPlaced;


    private Vector3 lastPos;
    private Quaternion lastRot;

    private bool confirmed;
    //used as increment but ended up being pointless
   // private int numOfWhiteBoards = 0;

    XRGrabInteractable interactable;

    private void Awake()
    {
        Debug.Log("PlaceScript is on");
        interactable = GetComponent<XRGrabInteractable>();
    }
    public  void OnEnable()
    {
        if(placed || previewPlaced)
        {
            Destroy(gameObject);
            
            return;
        }

        

        if(!WhiteBoardHasSpawned.CanPlace())
        {
            Debug.Log("No More then 1 Whiteboard!");
            Destroy(gameObject);
            return;
        }
        Debug.Log("Please?");
        if(ObjectSpawner != null)
        {
            ObjectSpawner.enabled = false;
        }

        //one of many null issues...
        if(confirmPress == null)
        {
            Debug.LogError("Confirming not assigned!!");
        }

        confirmPress.action.performed += confirmWhiteBoard;
        confirmPress.action.Enable();

        previewPlaced = true;

    } 
    private void OnDisable()
    {
        if(confirmPress != null)
        {

            confirmPress.action.performed -= confirmWhiteBoard;
        }
        
    }


    
    private void OnDestroy()
    {
        Debug.Log("Destroyed!!");
        previewPlaced = false;
    }
   
   
    private void Update()
    {
        //updates current position so prefab can spawn on top of it
        lastPos = transform.position;
        lastRot = transform.rotation;
    }



    //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/api/UnityEngine.InputSystem.InputAction.CallbackContext.html
    //
    void confirmWhiteBoard(InputAction.CallbackContext callback)
    {
        if(confirmed)
        {
            
           return;
           
        }
        confirmed = true;
        Debug.Log("It Works!");

        transform.SetParent(null);
        gameObject.SetActive(false);

       //placed = false;
        if (ObjectSpawner != null)
        {
            ObjectSpawner.enabled = true;
        }
         Destroy(Preview);
        previewPlaced = false;
        Instantiate(WhiteboardSpawn, lastPos, lastRot);
        // numOfWhiteBoards += 1;
        //Debug.Log(numOfWhiteBoards);
    }

}

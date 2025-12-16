using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Samples.ARStarterAssets;

public class Offsets : MonoBehaviour
{
    public Vector3 offset = new Vector3();
    private bool applied;

    

    private void LateUpdate()
    {
        if (applied)
        {
            Debug.Log("Somethings not right here");
            return;
        }
        applied = true;
        transform.position += transform.rotation * offset;
        Debug.Log("Should have offset!");

    }

    

 
}

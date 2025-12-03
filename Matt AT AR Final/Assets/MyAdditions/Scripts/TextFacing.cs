using UnityEngine;

public class TextFacing : MonoBehaviour
{

    //makes sure text is always facing camera

    //isnt perfect, subject to change
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera == null)
            return;


        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}

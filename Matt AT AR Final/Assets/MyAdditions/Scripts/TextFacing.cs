using UnityEngine;

public class TextFacing : MonoBehaviour
{
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

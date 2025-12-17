using UnityEngine;

public class WhiteBoardHasSpawned : MonoBehaviour
{
    private static bool hasSpawned;
    
    //checking to see if object script is attached to is spawned.
    
    // is a static so i can keep seperate and reference in WhiteBoardPlace
    public static bool CanPlace()
    {
        return !hasSpawned;
    }

    private void Awake()
    {
        hasSpawned = true;
    }
    private void OnDestroy()
    {
        hasSpawned = false;
    }

}

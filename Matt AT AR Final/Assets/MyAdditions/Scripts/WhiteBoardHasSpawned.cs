using UnityEngine;

public class WhiteBoardHasSpawned : MonoBehaviour
{
    private static bool hasSpawned;
    

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

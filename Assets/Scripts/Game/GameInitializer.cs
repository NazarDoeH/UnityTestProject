using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private bool hideMouseCursor = true;
    void Start()
    { 
        GameManager.instance.HideCursor(hideMouseCursor);
    }
}

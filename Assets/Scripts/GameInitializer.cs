using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private bool hideMouseCursor;
    void Awake()
    {
        Cursor.visible = hideMouseCursor;
        Cursor.lockState = hideMouseCursor ? CursorLockMode.Locked : CursorLockMode.None;
    }
}

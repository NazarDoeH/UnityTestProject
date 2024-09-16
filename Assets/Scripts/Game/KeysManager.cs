using UnityEngine;

public class KeysManager : MonoBehaviour
{
    //UI manager
    private UIManager uiManager;

    //Doors to open
    [Header("Doors")]
    [SerializeField] Door door;

    //Keys
    [Header("DEBUG")]
    [SerializeField] private int keysNumber; //Just for debug purposes

    private int currentKeysNumber;

    public void IncreaseKeysNumber()
    {
        keysNumber++;
        GameManager.instance.uiManager.UpdateKeysCounter(keysNumber, currentKeysNumber);
    }
    public void DecreaseKeysNumver()
    {
        if (currentKeysNumber + 1 <= keysNumber) currentKeysNumber++;

        GameManager.instance.uiManager.UpdateKeysCounter(keysNumber, currentKeysNumber);

        if (currentKeysNumber == keysNumber) door.OpenDoor();
    }

    
}

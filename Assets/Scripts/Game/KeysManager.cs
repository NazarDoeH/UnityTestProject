using UnityEngine;

//Manages key-related actions
public class KeysManager : MonoBehaviour
{    
    //Doors to open
    [Header("Doors")]
    [SerializeField] Door door;

    //Keys
    [Header("DEBUG")]
    [SerializeField] private int keysNumber; //Just for debug purposes

    private int currentKeysNumber;

    //Increases the total number of keys
    public void IncreaseKeysNumber()
    {
        keysNumber++;
        GameManager.instance.uiManager.UpdateKeysCounter(keysNumber, currentKeysNumber);
    }
    //Decreases the current number of keys
    public void DecreaseKeysNumver()
    {
        if (currentKeysNumber + 1 <= keysNumber) currentKeysNumber++;

        GameManager.instance.uiManager.UpdateKeysCounter(keysNumber, currentKeysNumber);

        if (currentKeysNumber == keysNumber) door.OpenDoor();
    }   
}
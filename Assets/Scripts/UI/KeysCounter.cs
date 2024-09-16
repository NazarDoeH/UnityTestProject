using TMPro;
using UnityEngine;

//Script is responsible for updating a counter display
[RequireComponent(typeof(TMP_Text))]
public class KeysCounter : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
    }

    //Updates the displayed key count. The current number of collected keys is compared to
    //the total number of required keys
    public void UpdateCounter(int keysNumber, int currentKeysNumber)
    {
        textMeshPro.text = currentKeysNumber + "/" + keysNumber;
    }
}

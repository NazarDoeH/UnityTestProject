using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class KeysCounter : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TMP_Text>();
    }

    public void UpdateCounter(int keysNumber, int currentKeysNumber)
    {
        textMeshPro.text = currentKeysNumber + "/" + keysNumber;
    }
}

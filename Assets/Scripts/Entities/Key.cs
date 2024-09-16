using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void Start()
    {
        GameManager.instance.keysManager.IncreaseKeysNumber();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        GameManager.instance.keysManager.DecreaseKeysNumver();
        Destroy(gameObject);
    }

}

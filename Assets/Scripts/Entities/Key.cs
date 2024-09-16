using ScriptableObjects;
using UnityEngine;

//Handles the player's interaction with the key pickup object
public class Key : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] SoundEffect keysPickupSFX;
    private void Start()
    {
        GameManager.instance.keysManager.IncreaseKeysNumber();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        GameManager.instance.keysManager.DecreaseKeysNumver();
        keysPickupSFX.Play();
        Destroy(gameObject);
    }

}

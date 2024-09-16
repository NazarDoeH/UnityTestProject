using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    //Trigger game finish when the player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.instance.FinishGame(true);
    }
}

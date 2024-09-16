using ScriptableObjects;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    //Animation controler
    [SerializeField] Animator animator;
    //Audio
    [SerializeField] SoundEffect openSFX;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoorTrigger");
        openSFX.Play(audioSource);
    }
}

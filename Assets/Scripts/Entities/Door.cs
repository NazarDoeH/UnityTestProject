using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    //Animation controler
    [SerializeField] Animator animator;

    private void Start()
    {
         animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoorTrigger");
    }
}

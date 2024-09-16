using ScriptableObjects;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    //Mouse cursor
    [SerializeField] private bool hideMouseCursor = true;
    //Music
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private SoundEffect music;

    void Start()
    { 
        GameManager.instance.HideCursor(hideMouseCursor);

        music.Play(playerSource);
    }
}

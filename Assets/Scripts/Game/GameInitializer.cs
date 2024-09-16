using ScriptableObjects;
using UnityEngine;

//Initializes the game state at the start of the game.
public class GameInitializer : MonoBehaviour
{

    //Mouse cursor
    [SerializeField] private bool hideMouseCursor = true;
    //Music
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private SoundEffect music;

    //Hide the cursor and start music
    void Start()
    { 
        GameManager.instance.HideCursor(hideMouseCursor);
        music.Play(playerSource);
    }
}

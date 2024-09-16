using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Managers
    [Header("Managers")]
    [SerializeField] public UIManager uiManager;
    [SerializeField] public KeysManager keysManager;

    //Player camera controler
    [SerializeField] private PlayerCameraController playerCameraContorler;

    //Game pause
    private bool isGamePaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    //Check if the pause key is pressed
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            uiManager.SetPauseMenuState(!isGamePaused);
    }


    //Level restart
    public void RestartLevel()
    {
        PauseGame(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Exit game
    public void ExitGame()
    {
        Application.Quit();
    }
    //Game pause
    public void PauseGame(bool state)
    {
        Time.timeScale = state ? 0.0f : 1.0f;
        playerCameraContorler.SetCameraLock(state);
        isGamePaused = state;
    }
    //Mouse cursor
    public void HideCursor(bool state)
    {
        Cursor.visible = !state;
        Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
    }
    public void FinishGame(bool didPlayerWin)
    {
        uiManager.OpenRestartPanel(didPlayerWin);
    }
}

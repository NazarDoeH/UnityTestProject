using TMPro;
using UnityEngine;

//Manages the UI elements of the game
public class UIManager : MonoBehaviour
{
    //UI
    //Pause panel
    [Header("UI elements")]
    [SerializeField] private GameObject pausePanel;

    //Restart panel
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private TMP_Text restartTitle;
    //Restart panel title
    [SerializeField] private string loseText = "You have\nDIED";
    [SerializeField] private string winText = "You have\nSURVIVED";

    //General ui
    [SerializeField] private KeysCounter keysCounter;

    public void SetPauseMenuState(bool state)
    {
        GameManager.instance.PauseGame(state);
        GameManager.instance.HideCursor(!state);
        pausePanel.SetActive(state);
    }

    public void OpenRestartPanel(bool didPlayerWin)
    {
        GameManager.instance.PauseGame(true);
        GameManager.instance.HideCursor(false);
        string titleText = didPlayerWin ? winText : loseText;
        restartTitle.text = titleText;

        restartPanel.SetActive(true);
    }

    public void UpdateKeysCounter(int keysNumber, int currentKeysNumber)
    {
        keysCounter.UpdateCounter(keysNumber, currentKeysNumber);
    }
}

using TMPro;
using UnityEngine;

//Script responsible for counting and displaying elapsed time.
//The time is displayed in hours, minutes, seconds, and milliseconds.
[RequireComponent(typeof(TMP_Text))]
public class TimeCounter : MonoBehaviour
{
    //General
    private TMP_Text textMeshPro;

    //Time
    private float time;
    private void Awake()
    {
        textMeshPro = GetComponent<TMP_Text>();
        time = 0;
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        time += Time.deltaTime;

        //Calculate hours, minutes, seconds, and milliseconds from the elapsed time
        int hr = Mathf.FloorToInt(time / 3600f);
        int min = Mathf.FloorToInt((time % 3600f) / 60f);
        int sec = Mathf.FloorToInt(time % 60f);
        int ms = Mathf.FloorToInt((time * 1000f) % 1000);

        textMeshPro.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hr, min, sec, ms);
    }
}

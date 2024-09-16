using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

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

        int hr = Mathf.FloorToInt(time / 3600f);
        int min = Mathf.FloorToInt((time % 3600f) / 60f);
        int sec = Mathf.FloorToInt(time % 60f);
        int ms = Mathf.FloorToInt((time * 1000f) % 1000);

        textMeshPro.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hr, min, sec, ms);
    }
}

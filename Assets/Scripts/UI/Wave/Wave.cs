using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public Image waveImage;
    private Text waveText;

    private void Awake()
    {
        waveText = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        WaveTextUpdate();
    }

    private void Update()
    {
        if (waveImage.GetComponent<RectTransform>().sizeDelta.x <= this.GetComponent<RectTransform>().sizeDelta.x)
        {
            waveImage.GetComponent<RectTransform>().sizeDelta += new Vector2(waveImage.GetComponent<RectTransform>().localScale.x + Time.deltaTime * 5f, 0);
        }
    }

    private void WaveTextUpdate()
    {
        GameManager.IncreaseWave();
        waveText.text = string.Format("WAVE {0}", GameManager.Instance.Wave);
        waveImage.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 50);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public static Wave Instance {get; private set;}

    public Image waveImage;
    private Text waveText;
    bool isStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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

        if(isStarted && GameManager.Instance.conMonstersList.Count <= 0)
        {
            isStarted = false;
            WaveTextUpdate();
        }
    }

    public static void WaveTextUpdate()
    {
        GameManager.IncreaseWave();
        Wave.Instance.waveText.text = string.Format("WAVE {0}", GameManager.Instance.WaveVal);
        Wave.Instance.waveImage.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 50);
        Wave.Instance.isStarted = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private int wave = 0;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
        }
    }

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
    }

    public static void IncreaseWave()
    {
        GameManager.Instance.Wave++;
    }
}

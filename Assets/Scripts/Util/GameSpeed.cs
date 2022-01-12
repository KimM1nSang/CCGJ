using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    private float gSpeed = 1.0f;
    private Button gSpeedButton;
    private Text gSpeedText;

    private void Awake()
    {
        gSpeedButton = GetComponent<Button>();
        gSpeedText = gSpeedButton.GetComponentInChildren<Text>();

        gSpeedButton.onClick.AddListener(() => GameSpeedControll());
        gSpeedText.text = string.Format("X{0:N1}", gSpeed);
    }

    public void GameSpeedControll() // 대충 만들어놓은거 (1배속, 1.5배속, 2배속 가능하도록)
    {
        switch(gSpeed)
        {
            case 1.0f:
            case 1.5f:
            gSpeed += 0.5f;
                break;
            case 2.0f:
            gSpeed -= 1.0f;
                break;
            default:
                break;
        }

        gSpeedText.text = string.Format("X{0:N1}", gSpeed);
        Time.timeScale  = gSpeed;
    }
}

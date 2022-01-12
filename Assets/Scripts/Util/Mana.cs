using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image manaImg;
    public Text manaText;
    Vector2 manaImgSize;

    private void Awake() {
        manaImg.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 30);
    }

    private void Update()
    {
        float manaSizeX = Mathf.Clamp(manaImgSize.x += Time.deltaTime * 30, 0, 400);
        manaImg.GetComponent<RectTransform>().sizeDelta = new Vector2(manaSizeX, 30);

        if(manaSizeX % 40 < 1)
        manaText.text = $"{manaSizeX / 40f:N0}";
    }
}

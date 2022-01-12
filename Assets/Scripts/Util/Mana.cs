using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image manaImg;
    public Text manaText;
    Vector2 manaImgSize;

    float mana;

    private void Awake() {
        manaImg.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 30);
    }

    private void Update()
    {
        float manaSizeX = Mathf.Clamp(manaImgSize.x += Time.deltaTime * 30, 0, 400);
        manaImg.GetComponent<RectTransform>().sizeDelta = new Vector2(manaSizeX, 30);

        if(manaSizeX % 40 < 1)
        {
            mana = manaSizeX / 40f;
            manaText.text = $"{mana:N0}";
        }
    }

    public void UseSkill(float cost)
    {
        if(mana >= cost)
        {
            mana -= cost;
            manaText.text = $"{mana:N0}";
            manaImg.GetComponent<RectTransform>().sizeDelta = new Vector2(mana * 40, 30);
        }
    }
}

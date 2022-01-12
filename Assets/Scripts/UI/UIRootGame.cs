using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootGame : MonoBehaviour
{
    /*[SerializeField]
    private Image testImage;*/
    public Image HpBar;
    public Text HpText;

    public Button Skill1Btn;
    public Button Skill2Btn;

    public Button gameSpeedBtn;

    public Button menuBtn;

    public GameObject gameOverPanel;

    public Text dieReasonText;
    void Awake()
    {
        GameSceneClass.gUiRootGame = this;
    }

    private void Update() 
    {
        //HpBar.rectTransform.localScale = new Vector3(curHp / maxHp, 1, 1);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*List<string> keyList = new List<string>(Global.spritesDic.Keys);
            int randomIdx = Random.Range(0, keyList.Count - 1);
            
            testImage.sprite = Global.spritesDic[keyList[randomIdx]];
            testImage.SetNativeSize();*/
        }
    }

    public void TestFunc()
    {
        print("call UIRootGame");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

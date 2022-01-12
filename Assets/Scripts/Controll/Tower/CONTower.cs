using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTower : CONCharacter
{
    public override void Start()
    {
        base.Start();
        CharacterSetup(1000, 0, 5, 0, Vector3.zero, 0, 1000);
    }
    public override void DieEnter()
    {
        print("DiE");
        GameSceneClass.gUiRootGame.dieReasonText.text = $"끝난 원인 : {dieReason.charName}";
        GameSceneClass.gUiRootGame.GameOver();
        base.DieEnter();
    }
    public override void Damage(float damage, CONCharacter dieReason = null)
    {
        base.Damage(damage, dieReason);
        GameSceneClass.gUiRootGame.HpBar.rectTransform.localScale = new Vector3(Hp / HpMax, 1, 1);
    }
}

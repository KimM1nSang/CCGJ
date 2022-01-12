using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonsterSlime : CONMonster
{
    public override void Start()
    {
        base.Start();
        CharacterSetup(100, 10, 2, 10, Vector3.left, 2, 2);
    }
}

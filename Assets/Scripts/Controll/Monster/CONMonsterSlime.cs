using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonsterSlime : CONMonster
{
    public override void Start()
    {
        base.Start();
        CharacterSetup(100, 1, 1, .5f, Vector3.left, 2, 10);
    }
}

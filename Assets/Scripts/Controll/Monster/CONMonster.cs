using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonster : CONCharacter
{
    public override void Start()
    {
        moveDir = Vector3.left;
        base.Start();
    }
}

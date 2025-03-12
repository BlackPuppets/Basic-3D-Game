using Clothes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheSpeedCollectable : ClotheCollectableBase
{
    [SerializeField] private float playerSpeedVariation = 40f;

    protected override void OnCollect()
    {
        base.OnCollect();
        PlayerMovement.instance.ChangePlayerSpeed(playerSpeedVariation, defaultClotheDuration);
    }
}

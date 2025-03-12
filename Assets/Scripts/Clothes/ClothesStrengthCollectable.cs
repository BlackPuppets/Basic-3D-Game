using Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesStrengthCollectable : ClotheCollectableBase
{
    [SerializeField] private float damageMultipleir = 0.5f;

    protected override void OnCollect()
    {
        base.OnCollect();
        PlayerMovement.instance.ChangePlayerDamageMultiplier(damageMultipleir, defaultClotheDuration);
    }
}

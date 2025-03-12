using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothes;

namespace Clothes
{
    public class ClotheCollectableBase : GenericCollectable
    {
        [SerializeField] private ClothType type;
        public float defaultClotheDuration = 5f;

        protected override void OnCollect()
        {
            base.OnCollect();
            PlayerMovement.instance.ChangePlayerClothes(ClothesManager.instance.GetSetupByType(type), defaultClotheDuration);
        }
    }
}


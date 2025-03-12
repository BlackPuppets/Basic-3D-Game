using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothes
{
    public enum ClothType
    {
        SPEED,
        STRENGTH
    }

    public class ClothesManager : MonoBehaviour
    {
        [SerializeField] private List<ClothSetup> clothSetups;
        public static ClothesManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        public ClothSetup GetSetupByType(ClothType type)
        {
            return clothSetups.Find(i => i.clothType == type);
        }
    }

    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Color color;
    }
}

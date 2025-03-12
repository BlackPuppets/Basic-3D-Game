using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;


namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK,
        CLOTHE
    }

    public class ItemManager : MonoBehaviour
    {
        public static ItemManager instance;

        public List<ItemSetup> itemSetups = new List<ItemSetup>();

        [Header("SO_UI_References")]
        [SerializeField] private TextMeshProUGUI coinText;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            ResetItems();
        }

        private void ResetItems()
        {
            foreach (var item in itemSetups)
            {
                item.soInt.value = 0;
            }
        }

        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }

        public void ChangeAmountByType(ItemType itemType, int amount = 1)
        {

            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soInt.value += amount;
            if(itemType == ItemType.COIN)
                coinText.text = "Coins x " + item.soInt.value.ToString();

            if (item.soInt.value < 0)
                item.soInt.value = 0;
        }


    }

    [System.Serializable]
    public class ItemSetup
    {
        [SerializeField] public ItemType itemType;
        [SerializeField] public SOInt soInt;
        [SerializeField] public Sprite Icon;
    }

}
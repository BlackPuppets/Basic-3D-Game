using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLifepack : MonoBehaviour
{
    [SerializeField] private KeyCode keycode = KeyCode.L;
    [SerializeField] private SOInt soInt;

    private void Start()
    {
        soInt = ItemManager.instance.GetItemByType(ItemType.LIFE_PACK).soInt;
    }

    private void RecoverLife()
    {
        if (soInt.value > 0)
        {
            ItemManager.instance.ChangeAmountByType(ItemType.LIFE_PACK, -1);
            PlayerMovement.instance.ResetLife();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(keycode))
            RecoverLife();
    }
}

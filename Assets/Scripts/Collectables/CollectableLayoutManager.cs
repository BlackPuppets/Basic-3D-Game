using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLayoutManager : MonoBehaviour
{
    [SerializeField] CollectableLayout prefabLayout;
    [SerializeField] Transform container;

    [SerializeField] private List<CollectableLayout> itensLayout;

    private void Start()
    {
        CreateItens();
    }

    private void CreateItens()
    {
        foreach(var setup in ItemManager.instance.itemSetups)
        {
            var item = Instantiate(prefabLayout, container);
            item.Load(setup);
            itensLayout.Add(item);
        }
    }
}

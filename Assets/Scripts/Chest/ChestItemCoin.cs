using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    [SerializeField] private int coinNumber = 5;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Vector2 RandomRange = new Vector2(-.5f, .5f);
    [SerializeField] private float tweenEndTime = .5f;
    private List<GameObject> itens = new List<GameObject>();
    public override void ShowItem()
    {
        base.ShowItem();
        CreateItens();
    }

    private void CreateItens()
    {
        for (int i = 0; i < 5; i++)
        {
            var item = Instantiate(coinPrefab);
            item.transform.position = transform.position + Vector3.forward * Random.Range(RandomRange.x, RandomRange.y) + Vector3.right * Random.Range(RandomRange.x, RandomRange.y);
            item.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            itens.Add(item);
        }
    }

    public override void Collect()
    {
        base.Collect();
        foreach (var item in itens)
        {
            item.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            item.transform.DOScale(0, tweenEndTime / 2).SetDelay(tweenEndTime / 2);
            Itens.ItemManager.instance.ChangeAmountByType(Itens.ItemType.COIN);
        }
    }
}

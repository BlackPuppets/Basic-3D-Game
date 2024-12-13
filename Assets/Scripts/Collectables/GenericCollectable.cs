using Itens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollectable : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private string compareTag = "Player";
    [SerializeField] protected Transform particleEffect;

    [Header("Sounds")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioPlayAndDestroy audioPlayAndDestroy;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        Destroy(gameObject);
    }

    protected virtual void OnCollect() {
        PlayEffect();
        if(audioSource != null) audioPlayAndDestroy.PlayAudio(audioSource);
        ItemManager.instance.ChangeAmountByType(itemType);
    }
    
    protected virtual void PlayEffect() { }
}

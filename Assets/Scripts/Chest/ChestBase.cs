using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChestBase : MonoBehaviour
{
    [SerializeField] private KeyCode keycode = KeyCode.Z;
    [SerializeField] private Animator animator;
    [SerializeField] private string triggerOpen = "IsOpening";
    [SerializeField] private GameObject notification;
    [Space] [SerializeField] private ChestItemBase chestItem;
    private bool chestOpened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OpenChest()
    {
        if (chestOpened) return;

        animator.SetTrigger(triggerOpen);
        chestOpened = true;
        HideNotification();
        Invoke(nameof(ShowItem), .5f);
    }

    private void ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), .5f);
    }

    private void CollectItem()
    {
        chestItem.Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
    }
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keycode) && notification.activeSelf)
        {
            OpenChest();
        }
    }
}

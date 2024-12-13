using Itens;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableLayout : MonoBehaviour
{
    private ItemSetup _currentSetup;
    [SerializeField] private Image uiIcon;
    [SerializeField] private TextMeshProUGUI uiValue;
    public void Load(ItemSetup setup)
    {
        _currentSetup = setup;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiIcon.sprite = _currentSetup.Icon;
    }

    private void Update()
    {
        uiValue.text = _currentSetup.soInt.value.ToString();
    }
}

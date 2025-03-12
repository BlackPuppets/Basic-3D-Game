using Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer m_SkinnedMeshRenderer;
    [SerializeField] private Color color;
    [SerializeField] private string shaderPropertyName = "_BaseColor";
    [SerializeField] private Color defaultColor;

    private void Awake()
    {
        defaultColor = m_SkinnedMeshRenderer.materials[0].GetColor(shaderPropertyName);
    }

    private void ChangeClothe()
    {
        m_SkinnedMeshRenderer.materials[0].SetColor(shaderPropertyName, color);
    }
    public void ChangeClothe(ClothSetup setup)
    {
        m_SkinnedMeshRenderer.materials[0].SetColor(shaderPropertyName, setup.color);
    }

    public void ResetTexture()
    {
        m_SkinnedMeshRenderer.materials[0].SetColor(shaderPropertyName, defaultColor);
    }

}

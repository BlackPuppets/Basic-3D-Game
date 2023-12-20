using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;
    private bool checkpointActive = false;
    public int key = 01;

    private string checkpointKey = "CheckpointKey";

    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!checkpointActive && other.transform.tag == "Player")
            CheckCheckpoint();
    }

    private void CheckCheckpoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    private void TurnItOn()
    {
        m_MeshRenderer.material.SetColor("_BaseColor", Color.green);
    }

    private void SaveCheckPoint()
    {
        /*if (PlayerPrefs.GetInt(checkpointKey, 0) > key)
        {
            PlayerPrefs.SetInt(checkpointKey, key);
        }
        */
        CheckpointManager.GetInstance().SaveCheckpoint(key);
        checkpointActive = true;
    }
}

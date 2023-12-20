using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    private int lastCheckpointKey = 0;

    [SerializeField]private List<CheckpointBase> checkpoints;

    public bool HasCheckpoint()
    {
        return lastCheckpointKey > 0;
    }

    public void SaveCheckpoint(int i)
    {
        if (i > lastCheckpointKey)
        {
            lastCheckpointKey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckpoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckpointKey);
        return checkpoint.transform.position;
    }
}

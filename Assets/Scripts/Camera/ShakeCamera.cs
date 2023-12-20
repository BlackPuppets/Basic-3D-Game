using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;
using Cinemachine;

public class ShakeCamera : Singleton<ShakeCamera>
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private float shakeTime;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cinemachineBMCP;

    private void Awake()
    {
        cinemachineBMCP = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitude, float frequency, float time)
    {
        cinemachineBMCP.m_AmplitudeGain = amplitude;
        cinemachineBMCP.m_FrequencyGain = frequency;

        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
        }
    }
}

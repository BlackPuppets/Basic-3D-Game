using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Utils.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    [SerializeField] private VolumeProfile processVolume;
    [SerializeField] private Vignette _vignette;
    [SerializeField] private Color vignetteStartingColor = Color.black;
    [SerializeField] private float duration = 0.1f;

    private void Start()
    {
        //Only reason this is being made, is because unity can't separate an instance of volume to be run on realtime,
        //so i have to change the actual file that stores the volume data on realtime, and guarantee that it starts the same every time
        //This happens because i'm using URP, i will be mindful to possibly not use URP in the future anymore
        if (processVolume.TryGet<Vignette>(out _vignette))
        {
            _vignette.color.Override(vignetteStartingColor);
        }
    }

    public void ChangeVinette()
    {

        StartCoroutine(FlashColorVignette());
        
    }

    IEnumerator FlashColorVignette()
    {
        if (processVolume.TryGet<Vignette>(out _vignette))
        {
            ColorParameter c = new ColorParameter(Color.red);
        }

        float time = 0;
        while (time < duration)
        {
            _vignette.color.Override(Color.Lerp(Color.black, Color.red, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        
        time = 0;

        while (time < duration)
        {
            _vignette.color.Override(Color.Lerp(Color.red, Color.black, time / duration));
            time += Time.deltaTime;
            yield return null;
        }

    }
}

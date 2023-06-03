using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using System.Linq;
using System;

public class PostProcessingModifier : MonoBehaviour
{
    public PostProcessProfile baseProfile;

    private void Start()
    {
        VignetteEffect(true);
    }

    private void VignetteEffect(bool logic)
    {
        var duration = 1f;

        // Check if the Vignette effect already exists in the base profile
        if (!baseProfile.HasSettings<Vignette>())
        {
            // Create a new Vignette effect and add it to the base profile
            var vignetteSettings = baseProfile.AddSettings<Vignette>();
            vignetteSettings.enabled.Override(true);

            if(logic)
            {
                vignetteSettings.intensity.Override(0f);

                // Modify the intensity, smoothness, and roundness of the vignette
                vignetteSettings.intensity.value = 0;
                vignetteSettings.smoothness.value = 0;
                vignetteSettings.roundness.value = 0;

                DOTween.To(() => vignetteSettings.intensity.value, value => vignetteSettings.intensity.value = value, 0.6f, duration).SetEase(Ease.OutQuad);
                DOTween.To(() => vignetteSettings.smoothness.value, value => vignetteSettings.smoothness.value = value, 0.5f, duration).SetEase(Ease.OutQuad);
                DOTween.To(() => vignetteSettings.roundness.value, value => vignetteSettings.roundness.value = value, 0.9f, duration).SetEase(Ease.OutQuad);
            } 
            else
            {
                vignetteSettings.intensity.Override(0f);

                // Modify the intensity, smoothness, and roundness of the vignette
                vignetteSettings.intensity.value = 0.6f;
                vignetteSettings.smoothness.value = 0.5f;
                vignetteSettings.roundness.value = 0.9f;

                DOTween.To(() => vignetteSettings.intensity.value, value => vignetteSettings.intensity.value = value, 0, duration).SetEase(Ease.OutQuad);
                DOTween.To(() => vignetteSettings.smoothness.value, value => vignetteSettings.smoothness.value = value, 0, duration).SetEase(Ease.OutQuad);
                DOTween.To(() => vignetteSettings.roundness.value, value => vignetteSettings.roundness.value = value, 0, duration).SetEase(Ease.OutQuad);
            }
        }
    }

}

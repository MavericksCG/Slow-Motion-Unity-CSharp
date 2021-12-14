using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SlowMotion : MonoBehaviour
{

    /// <summary> 
    /// Simple, extendable and easy to modify slow motion script. Only works with the URP. ///
    /// </summary> 


    #region Assignables, Desired Values and Lerping Related

    [ Header("Assignables") ] [ Space ]
    public Volume volume; // Post Processing Volume
    private ChromaticAberration ca; // Chromatic Abberation - Glitch Effect
    private LensDistortion ld; // Lens Distortion - Basically makes everything pop or look weird(depending on the value)!
    private Vignette vg; // Vignette - Black Fade-ish type-of things at the borders
    private Bloom b; // Bloom - Sickass Glow Effect Babyyy


    [ Header("Desired Values") ] [ Space ]
    // Pretty Self Explanatory
    [Range(0f, 1f)] public float desiredValueChromaticAbberation;
    [Range(0f, 1f)] public float desiredValueLensDistortion;
    [Range(0f, 1f)] public float desiredValueVignette;
    public float desiredValueBloomIntensity;
    public float desiredValueBloomThreshold;
    public float desiredTimeScale = .1f; // Desired timeScale for slow motion (By default, the timeScale is 1.00).


    [ Header("Interpolating / Transitioning") ] [ Space ]
    // Pretty Self Explanatory too...
    [Range(0f, 1f)] public float slowMotionLerpTime;
    [Range(0f, 1f)] public float chromaticAbberationLerpTime;
    [Range(0f, 1f)] public float lensDistortionLerpTime;
    [Range(0f, 1f)] public float vignetteLerpTime;
    [Range(0f, 1f)] public float bloomLerpTime;
    // Higher is snappier, lower is smoother
    
    
    #endregion


    void Update() {

        SlowMotionEnableDisable();

    }

    protected void SlowMotionEnableDisable() {

        if (Input.GetMouseButton(1) && volume.profile.TryGet<ChromaticAberration>(out ca) && volume.profile.TryGet<LensDistortion>(out ld) && volume.profile.TryGet<Vignette>(out vg) && volume.profile.TryGet<Bloom>(out b)) {

            // Lerp Time Scale
            Time.timeScale = Mathf.Lerp(Time.timeScale, desiredTimeScale, slowMotionLerpTime); 

            // Lerp Chromatic Abberation Intensity
            ca.intensity.value = Mathf.Lerp(ca.intensity.value, desiredValueChromaticAbberation, chromaticAbberationLerpTime); 

            // Lerp Lens Distortion Intensity
            ld.intensity.value = Mathf.Lerp(ld.intensity.value, desiredValueLensDistortion, lensDistortionLerpTime); 

            // Lerp Vignette Intensity
            vg.intensity.value = Mathf.Lerp(vg.intensity.value, desiredValueVignette, vignetteLerpTime); 

            // Lerp Bloom Intensity and Threshold
            b.intensity.value = Mathf.Lerp(b.intensity.value, desiredValueBloomIntensity, bloomLerpTime);
            b.threshold.value = Mathf.Lerp(b.threshold.value, desiredValueBloomThreshold, bloomLerpTime);

        } 

        else if (volume.profile.TryGet<ChromaticAberration>(out ca) && volume.profile.TryGet<LensDistortion>(out ld) && volume.profile.TryGet<Vignette>(out vg) && volume.profile.TryGet<Bloom>(out b)) {

            /* 
                Visa-versa from the last if statement...
                We're basically just reverting everything to its original value so nothing really special going on here
            */
        
            // Time Scale
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, slowMotionLerpTime);

            // Chromatic Abberation
            ca.intensity.value = Mathf.Lerp(ca.intensity.value, .075f, chromaticAbberationLerpTime);

            // Lens Distortion
            ld.intensity.value = Mathf.Lerp(ld.intensity.value, .125f, lensDistortionLerpTime);

            // Vignette
            vg.intensity.value = Mathf.Lerp(vg.intensity.value, .203f, vignetteLerpTime);

            // Bloom
            b.intensity.value = Mathf.Lerp(b.intensity.value, 1f, bloomLerpTime);
            b.threshold.value = Mathf.Lerp(b.threshold.value, 1f, bloomLerpTime);

            
        }

    }

    // P.S - I'm sure that this is not that performant and there may be better ways to go about this but, that's a story for another day. I mean, atleast this works right?

}
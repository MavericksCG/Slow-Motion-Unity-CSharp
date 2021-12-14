# Simple Slow Motion made for the Unity Game Engine

## Please note that this only works with the [Universal Render Pipeline](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@11.0/manual/)

# How can you modify this?
**There are multiple ways to modify this script. You can add some post-processing effects, remove some of them, basically you can do a lot**

## How can I add a post-processing effect?
**Assuming you have the Universal Render Pipeline properly set-up and are using post-processing effects available in the pipeline, here's how you can add an effect!**


  Add a new line in the appropriate area (for post processing effects its "Assignables")
   
   ``` 
   private MyPostProcessingEffect myPostProcessingEffect;
   ```
   
   then add a desired value float
   ``` 
   [Range(0f, 1f)] public float desiredValueMyPostProcessingEffect;
   ```
   
   
   alternatively, you can use this for values which are not clamped: 
   
   ```

   public float desiredValueMyPostProcessingEffect;

   ```
   
   Then, set a lerp time amount (The RANGE attribute MATTERS here)
   

   
   ``` [Range(0f, 1f)] public float myPostProcessingEffectLerpTime; ```

   
   Then, you can add a new line in the ``` { SlowMotionEnableDisable } ``` function and write the following code:
   ```{ myPostProcessingEffect.intensity.value = Mathf.Lerp(myPostProcessingEffect.intensity.value, desiredValueMyPostProcessingEffect, myPostProcessingEffectLerpTime);  }```
   Oh, and also, it's not necessary to only change the intensity, you can also change other properties. For eg. here, I change the threshold of my bloom effect when you enter      slow-motion!
   ```  b.intensity.value = Mathf.Lerp(b.intensity.value, desiredValueBloomIntensity, bloomLerpTime); ```
   
   ### So, yeah I hope this script somewhat helps you in your coding journey, and until then, see you in my next repository!
   - Mavericks
    


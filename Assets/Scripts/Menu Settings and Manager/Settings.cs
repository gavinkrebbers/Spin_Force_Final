using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle particles;
    public Toggle floaties;
    public Toggle VFX;
    public Toggle screenShake;
    public Slider gaversPerGav;
    public Slider volumeSlider;
    public static float staticVolume = 0.3f;
    public static bool fiveGum;
    void Start()
    {
        particles.isOn = Particles.particles;
        floaties.isOn = Floaties.floaties;
        VFX.isOn = PostProcessing.VFX;
        volumeSlider.value = staticVolume;
        if (fiveGum)
        {
            gaversPerGav.value = 69;
        }
    }
    private void Update()
    {
        staticVolume = volumeSlider.value;

        if (gaversPerGav.value == 69)
        {
            fiveGum = true;

        }
        else
        {
            fiveGum = false;
        }
    }
    public void ParticlesToggle()
    {
        Particles.particles = particles.isOn;
    }
    public void FloatiesToggle()
    {
        Floaties.floaties = floaties.isOn;
    }
    public void VFXToggle()
    {
        PostProcessing.VFX = VFX.isOn;
    }
    public void ScreenShakeToggle()
    {
        ScreenShake.screenShake = screenShake.isOn;
    }
}

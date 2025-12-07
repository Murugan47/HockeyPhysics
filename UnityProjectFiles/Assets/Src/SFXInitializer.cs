using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SFXInitializer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip bounceFX, menuFX, scoreFX, puckFX, winFX;
    public float masterVolume;
    public Slider effectVolumeSlider;
    public TMP_Text effectVolumeValue;

    void Awake()
    {
        SoundPlayer.Initialize(src, bounceFX, menuFX, scoreFX, puckFX, winFX);
    }

    public void VolumeAdjust()
    {
        masterVolume = effectVolumeSlider.value;
        effectVolumeValue.text = (effectVolumeSlider.value * 100).ToString("F0");
        SoundPlayer.UpdateVolume(masterVolume);
        SoundPlayer.EffectTest();
    }
}

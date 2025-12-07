using UnityEngine;

public static class SoundPlayer
{
    private static AudioSource src;
    private static float masterVolume = 0.5f;

    private static AudioClip bounceFX, menuFX, scoreFX, puckFX, winFX;

    // Call this once at startup to initialize the AudioSource
    public static void Initialize(AudioSource source, AudioClip bounce, AudioClip menu, AudioClip score, AudioClip puck, AudioClip win)
    {
        src = source;
        bounceFX = bounce;
        menuFX = menu;
        scoreFX = score;
        puckFX = puck;
        winFX = win;
    }

    public static void UpdateVolume(float value)
    {
        masterVolume = Mathf.Clamp01(value);
    }

    public static void BounceSound()
    {
        if (src != null && bounceFX != null)
            src.PlayOneShot(bounceFX, masterVolume * 1.5f);
    }

    public static void MenuSound()
    {
        if (src != null && menuFX != null)
            src.PlayOneShot(menuFX, masterVolume * 0.75f);
    }

    public static void EffectTest()
    {
        if (src != null && menuFX != null)
        {
            if (src.isPlaying)
                return;

            src.clip = menuFX;
            src.volume = masterVolume * 0.75f;
            src.Play();
        }
    }

    public static void ScoreSound()
    {
        if (src != null && scoreFX != null)
            src.PlayOneShot(scoreFX, masterVolume * 2.5f);
    }

    public static void PuckSound()
    {
        if (src != null && puckFX != null)
            src.PlayOneShot(puckFX, masterVolume * 2f);
    }

    public static void WinSound()
    {
        if (src != null && winFX != null)
            src.PlayOneShot(winFX, masterVolume * 1.5f);
    }

}
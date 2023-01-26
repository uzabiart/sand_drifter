using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource announcerSource;

    private void OnEnable()
    {
        GameEvents.OnSfx += PlaySFX;
        GameEvents.OnAnnouncer += PlayAnnouncer;
    }
    private void OnDisable()
    {
        GameEvents.OnSfx -= PlaySFX;
        GameEvents.OnAnnouncer -= PlayAnnouncer;
    }

    public void PlayAnnouncer(AnnouncerInfo info)
    {
        StartCoroutine(PlayAnnouncerDelay(info));
    }
    public IEnumerator PlayAnnouncerDelay(AnnouncerInfo info)
    {
        yield return new WaitForSeconds(info.delay);
        sfxSource.PlayOneShot(info.clip, info.volume);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }
}

[System.Serializable]
public class AnnouncerInfo
{
    public AudioClip clip;
    public float volume;
    public float delay;
}
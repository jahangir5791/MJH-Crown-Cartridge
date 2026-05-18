using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public List<AudioClip> bgmClips = new List<AudioClip>();
    public List<AudioClip> sfxClips = new List<AudioClip>();
    
    private AudioSource bgmSource;
    private AudioSource sfxSource;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            bgmSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();
            
            bgmSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayBGM(string clipName)
    {
        var clip = bgmClips.Find(c => c.name == clipName);
        if (clip != null && !bgmSource.isPlaying)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }
    
    public void PlaySFX(string clipName)
    {
        var clip = sfxClips.Find(c => c.name == clipName);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    
    public void StopBGM()
    {
        bgmSource.Stop();
    }
}

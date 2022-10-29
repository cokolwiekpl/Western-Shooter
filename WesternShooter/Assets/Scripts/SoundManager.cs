using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource, gunSfxSource, enemySfxSource, otherSfxSource;

    
    public static SoundManager Instance;

    /// <summary>
    /// If there is no instance of this object, create one and don't destroy it when loading a new scene. If there is an
    /// instance of this object, destroy the new one
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //methods for sound effects related to weapons, enemies etc.

    /// <summary>
    /// Play the audio clip passed in as a parameter on the gunSfxSource AudioSource
    /// </summary>
    /// <param name="AudioClip">The sound effect you want to play.</param>
    public void PlaySfxGun(AudioClip clip)
    {
        gunSfxSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Play the audio clip passed in as a parameter on the enemySfxSource
    /// </summary>
    /// <param name="AudioClip">The sound effect you want to play.</param>
    public void PlaySfxEnemy(AudioClip clip)
    {
        enemySfxSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Play the audio clip passed in as a parameter on the otherSfxSource AudioSource
    /// </summary>
    /// <param name="AudioClip">The audio clip you want to play.</param>
    public void PlaySfxOther(AudioClip clip)
    {
        otherSfxSource.PlayOneShot(clip);
    }
}
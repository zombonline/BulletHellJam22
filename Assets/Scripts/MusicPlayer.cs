using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] bool doNotDestroy;
    AudioSource audioSource;
    [SerializeField] float loweredVolume = 0.5f;
    [SerializeField] float normalVolume = 1;
    private void Awake()
    {
        if(doNotDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void LowerVolume()
    {
        audioSource.volume = loweredVolume;
    }
    public void ResetVolume()
    {
        audioSource.volume = normalVolume;
    }

}

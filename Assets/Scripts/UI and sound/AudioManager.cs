using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip trainingVO;
    public AudioClip boostReminderVO;
    public AudioClip breakReminderVO;
    public bool hasBreaked = false;
    public bool hasBoosted = false;
    
    public AudioClip lowPowerBreakingDamageVO;
    public AudioClip collisionVO;
    public AudioClip lowPowerAttackVO;
    public AudioClip boosingAttackVO;

    public List<AudioClip> playerAttackSFX = new List<AudioClip>();

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.volume = PlayerPrefsController.GetMasterVolume();
        audioSource.clip = trainingVO;
        audioSource.PlayDelayed(0.25f);
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    void Update () {
		if (Time.timeSinceLevelLoad > 35 && !hasBoosted)
        {
            audioSource.clip = boostReminderVO;
            audioSource.Play();
            hasBoosted = true;
        }
        if (Time.timeSinceLevelLoad > 50 && !hasBreaked)
        {
            audioSource.clip = breakReminderVO;
            audioSource.Play();
            hasBreaked = true;
        }
    }
    public void PlayAttackSFX()
    {

        audioSource.PlayOneShot(playerAttackSFX[0]);
        
    }
    public void PlaylowPowerBreakingDamageVO()
    {
        audioSource.PlayOneShot(lowPowerBreakingDamageVO);
        
    }
    public void PlaycollisionVO()
    {
        audioSource.PlayOneShot(collisionVO);
       
    }
    public void PlaylowPowerAttackVO()
    {
        
        audioSource.PlayOneShot(lowPowerAttackVO);
    }
    public void PlayboosingAttackVO()
    {
        audioSource.PlayOneShot(boosingAttackVO);
        
    }
}

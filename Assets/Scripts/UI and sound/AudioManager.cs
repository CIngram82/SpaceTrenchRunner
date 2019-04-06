using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public SubtitleController subControl;
    public MusicManager volControl;

    [Header("Trainer VO messages")]
    public AudioClip trainingVO;
    public AudioClip boostReminderVO;
    public AudioClip breakReminderVO;
    public bool hasBreaked = false;
    public bool hasBoosted = false;
    
    [Header("Ship VO messages")]
    public AudioClip lowPowerBreakingDamageVO;
    private float breakingDamageVOTime = 0;
    public AudioClip collisionVO;
    private float collisionVOTime = 0;
    public AudioClip lowPowerAttackVO;
    private float lowPowerVOTime = 0;
    public AudioClip boosingAttackVO;
    private float boostingVOTime = 0;

    [Header("Other sounds")]
    public List<AudioClip> playerAttackSFX = new List<AudioClip>();
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.volume = PlayerPrefsController.GetMasterVolume();
        //volControl

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
            
            subControl.SubtitleByName("Boost");
            audioSource.clip = boostReminderVO;
            audioSource.Play();
            hasBoosted = true;
        }
        else
        {
            hasBoosted = true;
        }
        if (Time.timeSinceLevelLoad > 50 && !hasBreaked)
        {
            subControl.SubtitleByName("Brake");
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
        if (Time.time > breakingDamageVOTime && !hasBreaked)
        {
            subControl.SubtitleByName("ShipBrake");
            breakingDamageVOTime = lowPowerBreakingDamageVO.length * 1.5f;
            audioSource.PlayOneShot(lowPowerBreakingDamageVO);
        }
    }
    public void PlaycollisionVO()
    {
        if (Time.time > collisionVOTime)
        {
            subControl.SubtitleByName("ShipCollision");
            collisionVOTime = Time.time + collisionVO.length * 1.5f;
            audioSource.PlayOneShot(collisionVO);
        }
    }
    public void PlaylowPowerAttackVO()
    {
        if (Time.time > lowPowerVOTime)
        {
            subControl.SubtitleByName("ShipPlasma");
            lowPowerVOTime = Time.time + lowPowerAttackVO.length * 1.5f;
            audioSource.PlayOneShot(lowPowerAttackVO);
        }
    }
    public void PlayboosingAttackVO()
    {
        if (Time.time > boostingVOTime && !hasBoosted)
        {
            subControl.SubtitleByName("ShipBoost");
            boostingVOTime = Time.time + boosingAttackVO.length * 1.5f;
            audioSource.PlayOneShot(boosingAttackVO);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX soundFX;

    public enum sounds {door_locked, door_unlocked, keys, potion, torch, crackle, damage, thunder, level_1_hit, level_2_hit};
    public AudioSource keysAndDoors;
    public AudioSource powerUps;
    public AudioSource playerSounds;
    public AudioSource backgroundNoise;
    public AudioSource levelComplete;
    public AudioClip door_locked;
    public AudioClip door_unlocked;
    public AudioClip keys;
    public AudioClip potion;
    public AudioClip torch;
    public AudioClip crackle;
    public AudioClip damage;
    public AudioClip thunder;
    public AudioClip level_1_hit;
    public AudioClip level_2_hit;

    private void Awake()
    {
        if (soundFX == null)
        {
            soundFX = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (soundFX != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayTrack(sounds sound)
    {
        if (sound == sounds.door_locked)
        {
            keysAndDoors.clip = door_locked;
            keysAndDoors.Play();
        }
        else if (sound == sounds.door_unlocked)
        {
            keysAndDoors.clip = door_unlocked;
            keysAndDoors.Play();
        }
        else if (sound == sounds.keys)
        {
            keysAndDoors.clip = keys;
            keysAndDoors.Play();
        }
        else if (sound == sounds.potion)
        {
            powerUps.clip = potion;
            powerUps.Play();
        }
        else if (sound == sounds.torch)
        {
            powerUps.clip = torch;
            powerUps.Play();
        }
        else if (sound == sounds.crackle)
        {
            powerUps.clip = crackle;
            powerUps.Play();
        }
        else if (sound == sounds.damage)
        {
            playerSounds.clip = damage;
            playerSounds.Play();
        }
        else if (sound == sounds.thunder)
        {
            backgroundNoise.clip = thunder;
            backgroundNoise.Play();
        }
        else if (sound == sounds.level_1_hit)
        {
            levelComplete.clip = level_1_hit;
            levelComplete.Play();
        }
        else if (sound == sounds.level_2_hit)
        {
            levelComplete.clip = level_2_hit;
            levelComplete.Play();
        }
    }
}

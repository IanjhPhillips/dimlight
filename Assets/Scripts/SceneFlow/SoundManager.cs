using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager soundManager;
    public AudioSource master;
    public AudioSource[] slaves;
    public int oldIndex = 0;
    [Range(0, 2)] 
    public int currentIndex = 1;
    public bool isGameOver = false;
    public bool isGamePaused = false;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (soundManager != this)
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
        SyncSources();
        ChangeTrackIndex(currentIndex);
    }

    private void SyncSources()
    {
        foreach (var slave in slaves)
        {
            slave.timeSamples = master.timeSamples;
            slave.volume = isGamePaused ? 1 : 0;
        }
    }

    public void ChangeTrackIndex(int index)
    {
        if (oldIndex != index)
        {
            master.GetComponent<TrackSelector>().SwitchTrack(index);
            master.Play();
            if (index != 2)
            {
                foreach (var slave in slaves)
                {
                    slave.GetComponent<TrackSelector>().SwitchTrack(index);
                    slave.Play();
                    slave.volume = isGamePaused ? 1 : 0;
                }
            }
            else
            {
                foreach (var slave in slaves)
                {
                    slave.Stop();
                    slave.volume = 0;
                }
            }
            currentIndex = index;
            oldIndex = index;
        }
    }

    public void setSceneMusic()
    {
        isGameOver = SceneInfo.info.type == SceneInfo.SceneType.Recap;
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            ChangeTrackIndex(0);
        }
        else if (SceneManager.GetActiveScene().name == "RecapMenu")
        {
            ChangeTrackIndex(2);
        }
        else
        {
            ChangeTrackIndex(1);
        }
    }
}

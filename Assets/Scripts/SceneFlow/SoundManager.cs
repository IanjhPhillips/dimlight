using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager soundManager;
    public AudioSource master;
    public AudioSource[] slaves;
    public int oldIndex = 0;
    [Range(0, 1)] 
    public int currentIndex = 0;
    public bool isGameOver = false;

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
            slave.volume = isGameOver ? 1 : 0;
        }
    }

    public void ChangeTrackIndex(int index)
    {
        if (oldIndex != index)
        {
            master.GetComponent<TrackSelector>().SwitchTrack(index);
            master.Play();
            foreach (var slave in slaves)
            {
                slave.GetComponent<TrackSelector>().SwitchTrack(index);
                slave.Play();
                slave.volume = isGameOver ? 1 : 0;
            }
            oldIndex = index;
        }
    }

    public void setGameOver()
    {
        isGameOver = SceneInfo.info.type == SceneInfo.SceneType.Recap;
    }
}

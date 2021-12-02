using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSelector : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> tracks;
    public int currentIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTrack(int index)
    {
        currentIndex = index;
        source.clip = tracks[index];
    }
}

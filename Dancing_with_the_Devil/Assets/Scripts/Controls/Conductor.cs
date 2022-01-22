using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
    [SerializeField] private float songBpm { get; }
    
    private AudioSource musicSource;
    
    private float secPerBeat;
    private float songPosition;
    private float songPositionInBeats;
    private float dspSongTime;

    private bool playing;
    
    //Lifecycle
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;
    }

    void Update()
    {
        if (playing)
        {
            //determine how many seconds since the song started
            songPosition = (float) (AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;
        }
    }
    
    //Methods
    public void Play()
    {
        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        playing = true;
    }

    public void Stop()
    {
        musicSource.Stop();

        playing = false;
    }

    //Getters and Setters

    float getSongPositionInBeats()
    {
        return songPositionInBeats;
    }
}

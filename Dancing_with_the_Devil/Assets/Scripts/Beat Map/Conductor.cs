using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{

    [SerializeField] private float songBpm = 60f;
    
    private AudioSource musicSource;
    
    private float secPerBeat;
    private float songPosition;
    private float songPositionInBeats;
    private float dspSongTime;

    private float beatsSinceLastBPMChange;

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
            songPositionInBeats = beatsSinceLastBPMChange + songPosition / secPerBeat;
            
            
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

    public float getSongPositionInBeats()
    {
        return songPositionInBeats;
    }

    public void setBPM(float bpm)
    {
        beatsSinceLastBPMChange = getSongPositionInBeats();
        
        songBpm = bpm;

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;
        
        dspSongTime = (float)AudioSettings.dspTime;
    }
}

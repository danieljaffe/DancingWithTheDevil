using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{

    [SerializeField] private float songBpm = 60f;
    [SerializeField] private Fader f;
    [SerializeField] private LoveManager lm;
    
    private AudioSource musicSource;
    
    private float secPerBeat;
    private float songPosition;
    private float songPositionInBeats;
    private float dspSongTime;

    private float beatsSinceLastBPMChange;

    private bool playing;
    private float pauseBPM;
    
    //Lifecycle

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        musicSource.volume = PlayerPrefs.GetFloat("gameVolume");

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;
        
        Play();
    }

    void FixedUpdate()
    {
        if (playing)
        {
            //determine how many seconds since the song started
            songPosition = (float) (AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPositionInBeats = beatsSinceLastBPMChange + songPosition / secPerBeat;

            if (!musicSource.isPlaying)
            {
                if (lm.GetCurLove() > 66)
                {
                    f.switchScene("GoodEnding");
                }else if (lm.GetCurLove() > 33)
                {
                    f.switchScene("NeutralEnding");
                }else
                {
                    f.switchScene("BadEnding");
                }
            }
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

    public void Pause()
    {
        pauseBPM = songBpm;
        
        musicSource.Pause();

        playing = false;
        
        setBPM(0.000000001f);
    }

    public void Resume()
    {
        musicSource.Play();

        playing = true;
        
        setBPM(pauseBPM);
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

    public void setVolume(float volume)
    {
        musicSource.volume = volume;
    }
}

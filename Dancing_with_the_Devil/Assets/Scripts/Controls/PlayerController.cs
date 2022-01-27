using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Conductor conductor;
    [SerializeField] private BeatManager BeatManager;
    [SerializeField] private GameObject settings;

    private bool paused = false;
    
    // Lifecycle
    void Start()
    {
        StepmaniaParser s = new StepmaniaParser();
    }
    
    void Update()
    {
        
    }
    
    //Events

    void On_1()
    {
        BeatManager.CheckNote(0);
    }
    
    void On_2()
    {
        BeatManager.CheckNote(1);
    }
    
    void On_3()
    {
        BeatManager.CheckNote(2);
    }
    
    void On_4()
    {
        BeatManager.CheckNote(3);
    }

    void OnPause()
    {
        if (paused)
        {
            unpause();
        }
        else
        {
            pause();
        }
    }
    
    //Methods

    public void pause()
    {
        paused = true;
        settings.SetActive(true);
        conductor.Pause();
        Time.timeScale = 0;
    }
    
    public void unpause()
    {
        paused = false;
        settings.SetActive(false);
        conductor.Resume();
        Time.timeScale = 1;
    }
}

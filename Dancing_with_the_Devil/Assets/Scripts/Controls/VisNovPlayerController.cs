using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisNovPlayerController : MonoBehaviour
{
    
    [SerializeField] private GameObject settings;

    private bool paused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Time.timeScale = 0;
    }
    
    public void unpause()
    {
        paused = false;
        settings.SetActive(false);
        Time.timeScale = 1;
    }
}

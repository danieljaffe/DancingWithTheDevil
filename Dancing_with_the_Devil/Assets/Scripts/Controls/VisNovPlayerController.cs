using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VisNovPlayerController : MonoBehaviour
{
    public UnityEvent skip;
    
    [SerializeField] private GameObject settings;

    private bool paused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(skip.IsUnityNull()) skip = new UnityEvent();
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

    void OnSkip()
    {
        skip.Invoke();
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

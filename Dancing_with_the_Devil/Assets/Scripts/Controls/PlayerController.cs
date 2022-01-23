using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Conductor conductor;
    [SerializeField] private BeatManager beatManager;
    
    // Lifecycle
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    //Events

    void On_1()
    {
        beatManager.CheckNote();
    }

    void OnTest()
    {
        conductor.Play();
    }
}

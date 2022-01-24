using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzzyHeadBob : MonoBehaviour
{
    private Animator animator;

    private Conductor conductor;
    
    
    float beatsPerBob = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        conductor = GameObject.FindWithTag("Music Player").GetComponent<Conductor>();
        
        //Load the animator attached to this object
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Start playing the current animation from wherever the current conductor loop is
        animator.Play("Bob", -1, (conductor.getSongPositionInBeats() % beatsPerBob)/beatsPerBob);
        //Set the speed to 0 so it will only change frames when you next update it
        animator.speed = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private string nextScene = "";
    private Animator animator;
    
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Fader");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchScene(string s)
    {
        nextScene = s;
        animator.Play("FadeOut");
    }

    public void switchScene2()
    {
        SceneManager.LoadScene(nextScene);
        
        animator.Play("FadeIn");
    }
}

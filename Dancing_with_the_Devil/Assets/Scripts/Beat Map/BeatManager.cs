using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    public UnityEvent<float> noteHit;
    
    [SerializeField] private Conductor conductor;
    [SerializeField] private KeyBeatManager[] keyBeatManagers;

    private int[][] beatMap =
    {
        new []{4, 8, 12, 16},
        new []{1, 5, 10, 12},
        new []{4, 8, 12, 16},
        new []{4, 8, 12, 16}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        if (noteHit.IsUnityNull()) noteHit = new UnityEvent<float>();
        for (int i = 0; i < keyBeatManagers.Length; i++)
        {
            keyBeatManagers[i].Init(conductor, beatMap[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckNote(int buttonNum)
    {
        float result = -1f;

        if (keyBeatManagers[buttonNum].CheckNote(ref result))
        {
            noteHit.Invoke(result);
        };
    }
}

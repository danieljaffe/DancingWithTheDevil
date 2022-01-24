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
    
    private float inputRange = 0.5f;
    private float anticipationBeats = 2f;

    private float[][] beatMap;
    
    // Start is called before the first frame update
    void Start()
    {
        if (noteHit.IsUnityNull()) noteHit = new UnityEvent<float>();

        StepmaniaParser s = new StepmaniaParser();
        beatMap = s.ExtractBeatmap();
        
        for (int i = 0; i < keyBeatManagers.Length; i++)
        {
            keyBeatManagers[i].Init(conductor, beatMap[i], inputRange, anticipationBeats);
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

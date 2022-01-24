using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class KeyBeatManager : MonoBehaviour
{
    private float spawnBeats = 1;
    
    private float inputRange = 0.5f;
    private float anticipationBeats = 2f;

    [SerializeField] private GameObject note;
    
    private Conductor conductor;
    
    private float[] beatMap;

    private SortedList<int, GameObject> activeNotes = new();
    private int currentNote = 0;
    private int lastNote = -1;
    
    public void Init(Conductor c, float[] beatMap, float inputRange, float anticipationBeats)
    {
        this.conductor = c;
        this.beatMap = beatMap;
        this.inputRange = inputRange;
        this.anticipationBeats = anticipationBeats;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (currentNote < beatMap.Length && conductor.getSongPositionInBeats() > beatMap[currentNote] - anticipationBeats - spawnBeats)
        {
            GameObject n = Instantiate(note, Vector3.zero, Quaternion.identity, transform);
            n.GetComponent<Beat>().Init(beatMap[currentNote], anticipationBeats, spawnBeats);
            activeNotes.Add(currentNote, n);

            currentNote++;
        }
    }

    public bool CheckNote(ref float result)
    {
        int checkedNote = lastNote + 1;

        for (int i = lastNote + 1; i < beatMap.Length; i++)
        {
            if (getDistanceFromCurrentBeat(beatMap[i]) < getDistanceFromCurrentBeat(beatMap[checkedNote]))
            {
                checkedNote = i;
            }
        }

        if (checkedNote >= beatMap.Length) return false;

        if (getDistanceFromCurrentBeat(beatMap[checkedNote]) < inputRange)
        {
            result = conductor.getSongPositionInBeats() - beatMap[checkedNote];
            
            lastNote = checkedNote;
            
            Destroy(activeNotes[checkedNote]);
            activeNotes.Remove(checkedNote);

            return true;
        }

        return false;
    }

    public float getDistanceFromCurrentBeat(float beat)
    {
        return Mathf.Abs(conductor.getSongPositionInBeats() - beat);
    }


}

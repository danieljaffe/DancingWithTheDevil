using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    private float inputRange = 0.2f;
    private float anticipationBeats = 2f;

    [SerializeField] private GameObject note;
    [SerializeField] private Conductor conductor;
    
    private int[] beatMap = {4,8,12,16};
    private int currentNote = 0;
    private int lastNote = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNote + 1 < beatMap.Length && conductor.getSongPositionInBeats() > beatMap[currentNote] - anticipationBeats)
        {
            GameObject n = Instantiate(note, Vector3.zero, Quaternion.identity);
            n.GetComponent<Beat>().Init(beatMap[currentNote], 2);

            currentNote++;
        }
    }

    public void CheckNote()
    {
        int checkedNote = lastNote + 1;

        for (int i = lastNote + 1; i < beatMap.Length; i++)
        {
            if (getDistanceFromCurrentBeat(beatMap[i]) < getDistanceFromCurrentBeat(beatMap[checkedNote]))
            {
                checkedNote = i;
            }
        }

        if (checkedNote > beatMap.Length) return;

        if (getDistanceFromCurrentBeat(beatMap[checkedNote]) < inputRange)
        {
            Debug.Log("Hit!");
            Debug.Log(getDistanceFromCurrentBeat(beatMap[checkedNote]));
        }
    }

    public float getDistanceFromCurrentBeat(int beat)
    {
        return Mathf.Abs(conductor.getSongPositionInBeats() - beat);
    }


}

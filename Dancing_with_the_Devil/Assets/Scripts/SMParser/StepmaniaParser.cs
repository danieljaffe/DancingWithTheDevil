using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class StepmaniaParser
{
    public float[][] ExtractBeatmap(ref float[][] setBpms)
    {
            
        // Get the data from the file
        var stepmania = File.ReadAllText(Application.dataPath + "/excitement.sm");
        var metadata = new Regex("#.*?;", RegexOptions.Singleline).Match(stepmania);

        List<string> diffnotes = new List<string>();
        string bpms = "";
        
        while (metadata.Success)
        {
            // get the key value pairs
            var datum = metadata.Value;
            var key = datum.Substring(0, datum.IndexOf(":")).Trim('#').Trim(':');
            var value = datum.Substring(datum.IndexOf(":")).Trim(':').Trim(';');
            
            switch (key.ToUpper())
            {
                case "BPMS":
                    bpms = value;
                    break;
                case "NOTES":
                    diffnotes.Add(value);
                    break;
                default:
                    break;
            }
            metadata = metadata.NextMatch();
        }
        
        //BPM
        string[] bpmchanges = bpms
            .Split(",")
            .ToArray();

        float[][] bpmMap = new float[bpmchanges.Length][];
        for (int i = 0; i < bpmchanges.Length; i++)
        {
            string[] temp = bpmchanges[i].Split("=")
                .ToArray();
            bpmMap[i] = new []{
                float.Parse(temp[0]),
                float.Parse(temp[1])
            };
        }

        setBpms = bpmMap;
        
        //Notes
        string notes = diffnotes[0];

        string[] lines = notes
            .Split("\n").Skip(6).SkipLast(2).ToArray();

        notes = string.Join("\n", lines);
        
        string[] measures = notes
            .Split("\n,")
            .ToArray();

        string[][] smMap = new string[measures.Length][];
        for (int i = 0; i < measures.Length; i++)
        {
            smMap[i] = measures[i].Split("\n")
                .ToArray();
        }

        float[] beat = {0, 0, 0, 0};

        List<float>[] meep =
        {
            new(),
            new(),
            new(),
            new()
        };
        
        for (int i = 0; i < smMap.Length; i++)
        {
            float progression = 4f / (smMap[i].Length - smMap[i].Length % 4);

            for (int j = 0; j < smMap[i].Length; j++)
            {
                if(smMap[i][j].Length < 4) continue;
                for (int k = 0; k < 4; k++)
                {
                    if (smMap[i][j][k] == '1')
                    {
                        meep[k].Add(beat[k]);
                    }
                    beat[k] += progression;
                }
            }
        }

        float[][] beatMap = new float[4][];

        for (int i = 0; i < 4; i++)
        {
            beatMap[i] = meep[i].ToArray();
        }

        return beatMap;
    }
}

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}
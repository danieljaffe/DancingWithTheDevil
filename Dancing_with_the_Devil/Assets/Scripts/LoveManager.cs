using UnityEngine;
[System.Serializable]

public class LoveManager : MonoBehaviour
{
    [SerializeField] private double curLove = 2;
    [SerializeField] private double maxLove = 5;
    [SerializeField] private bool isGameOver;

    // Pass a float to increment the love meter. Use negative numbers to decrement.
    public void UpdateLove(double love)
    {
        // Updates health
        curLove += love;
        
        // Prevents health over maximum
        if (curLove > maxLove)
        {
            curLove = maxLove;
        } 

        // Sets dead if character dies
        else if (curLove <= 0)
        {
            isGameOver = true;
        }

        // Action
        if (isGameOver)
        {
            // TODO: Cut to ending dialog? Cause some action? TBD
        }
    }

    // Returns the total love
    public double GetCurLove()
    {
        return curLove;
    }
}
using UnityEngine;
[System.Serializable]

public class Health : MonoBehaviour
{
    [SerializeField] private int curLove = 2;
    [SerializeField] private int maxLove = 5;
    [SerializeField] private bool isGameOver;

    // Damages your love
    public void DamageLove(int damage)
    {
        // Updates health
        curLove -= damage;
        
        // Prevents health over maximum
        if (curLove > maxLove)
        {
            curLove = maxLove;
        } 

        // Sets dead if character dies
        else if (curLove < 1)
        {
            isGameOver = true;
        }

        // Action
        if (isGameOver)
        {
            // TODO: Cut to ending dialog? Cause some action? TBD
        }
    }

    // Adds love
    public void HealLove(int love)
    {
        DamageLove(-love);
    }

    // Returns the total love
    public int GetCurLove()
    {
        return curLove;
    }
}
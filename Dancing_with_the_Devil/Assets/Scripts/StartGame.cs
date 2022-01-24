using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string LevelName;
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelName);
    }
}

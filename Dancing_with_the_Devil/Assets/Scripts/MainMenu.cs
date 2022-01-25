using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    [SerializeField] private string startingScene;
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(startingScene);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

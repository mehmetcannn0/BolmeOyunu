using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameLevel");

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

}

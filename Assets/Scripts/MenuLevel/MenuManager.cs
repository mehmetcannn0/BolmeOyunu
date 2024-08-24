using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton, ExitButton;
    void Start()
    {
        FadeOut();
    }
    private void FadeOut()
    {
        startButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        ExitButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGameLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }
}

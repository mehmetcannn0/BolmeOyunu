using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject SquarePrefab;
    [SerializeField]
    private Transform SquaresPanel;
    [SerializeField]
    private Transform QuestionPanel;
    [SerializeField]
    private Text QuestionText;
    [SerializeField]
    private Sprite[] squareSprites;
    [SerializeField]
    private GameObject EndingPanel;
    [SerializeField]
    AudioSource AudioSource;

    public AudioClip wrongAudioClip;
    public AudioClip correctAudioClip;

    private GameObject[] SquareArray = new GameObject[25];

    GameObject selectedSquare;
    


    List<int> Numbers = new List<int>();
    int divider, divided;
    int questionIndex;
    int correctAnswer;
    int buttonValue;
    bool isClickable;
    int remainingHeart;
    string difficultyLevel;

    RemainingHeartManager remainingHeartManager;
    MarkManager markManager;
    private void Awake()
    {
        remainingHeart = 3;
        AudioSource = GetComponent<AudioSource>();

        remainingHeartManager = Object.FindObjectOfType<RemainingHeartManager>();
        markManager = Object.FindObjectOfType<MarkManager>();

        remainingHeartManager.CheckRemainingHearts(remainingHeart);

        EndingPanel.GetComponent<RectTransform>().localScale =   Vector3.zero;
    }

    void Start()
    {
        isClickable = false;
        QuestionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        CreateSquare();
    }

    public void CreateSquare()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(SquarePrefab, SquaresPanel);
            square.transform.GetChild(1).GetComponent<Image>().sprite = squareSprites[Random.Range(0, squareSprites.Length)];
            square.transform.GetComponent<Button>().onClick.AddListener(() => ClickSquareButton());
            SquareArray[i] = square;

        }
        WriteNumberToSquare();
        StartCoroutine(DoFadeRoutine());
        Invoke("OpenQuestionPanel", 2f);
    }
    void ClickSquareButton()
    {

        if (isClickable)
        {
            selectedSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            buttonValue = int.Parse(selectedSquare.transform.GetChild(0).GetComponent<Text>().text);
            CheckResult();

        }

    }
    void CheckResult()
    {
        if (buttonValue == correctAnswer)
        {
            AudioSource.PlayOneShot(correctAudioClip);

            markManager.addMark(difficultyLevel);
            selectedSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            selectedSquare.transform.GetChild(0).GetComponent<Text>().text = "";
            selectedSquare.transform.GetComponent<Button>().interactable = false;

            Numbers.RemoveAt(questionIndex);
            QuestionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

            if (Numbers.Count > 0)
            {
                OpenQuestionPanel();

            }
            else
            {
                EndGame();

            }
        }
        else
        {
            AudioSource.PlayOneShot(wrongAudioClip);

            remainingHeart--;
            remainingHeartManager.CheckRemainingHearts(remainingHeart);


        }

        if (remainingHeart <= 0)
        {
            
            EndGame();
        }
    }
    void EndGame()
    {
        isClickable = false;
        EndingPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);
    }
    IEnumerator DoFadeRoutine()
    {
        foreach (var square in SquareArray)
        {
            square.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.07f);
        }
    }
    void WriteNumberToSquare()
    {
        foreach (var square in SquareArray)
        {
            int randomValue = Random.Range(1, 13);
            Numbers.Add(randomValue);

            square.transform.GetChild(0).GetComponent<Text>().text = randomValue.ToString();

        }

    }
    void OpenQuestionPanel()
    {
        CreateQuestion();
        isClickable = true;
        QuestionPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(0.3f);


    }
    void CreateQuestion()
    {
        divider = Random.Range(2, 11);
        questionIndex = Random.Range(0, Numbers.Count);
        correctAnswer = Numbers[questionIndex];
        divided = divider * correctAnswer;
        if (divided <= 40)
        {
            difficultyLevel = "easy";
        }
        else if (divided <= 80)
        {
            difficultyLevel = "medium";
        }
        else
        {
            difficultyLevel = "hard";
        }
        QuestionText.text = divided.ToString() + " : " + divider.ToString();

    }

}

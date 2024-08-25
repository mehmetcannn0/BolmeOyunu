using UnityEngine;
using UnityEngine.UI;

public class MarkManager : MonoBehaviour
{

    private int sumMark;
    private int amountMark;
    [SerializeField]
    private Text markText;


    void Start()
    {
        markText.text = sumMark.ToString();
    }

    public void addMark(string difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case "easy":
                amountMark = 5;
                break;
            case "medium":
                amountMark = 10;
                break;
            case "hard":
                amountMark = 15;
                break;

        }
        sumMark += amountMark;
        markText.text = sumMark.ToString();


    }
}

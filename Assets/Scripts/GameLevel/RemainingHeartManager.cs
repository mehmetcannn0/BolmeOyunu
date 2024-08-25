using UnityEngine;

public class RemainingHeartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RemainingHeart1, RemainingHeart2, RemainingHeart3;

 
    public void CheckRemainingHearts(int remainingHeart)
    {
        switch (remainingHeart)
        {
            case 3:
                RemainingHeart1.SetActive(true);
                RemainingHeart2.SetActive(true);
                RemainingHeart3.SetActive(true);
                break;
            case 2:
                RemainingHeart1.SetActive(true);
                RemainingHeart2.SetActive(true);
                RemainingHeart3.SetActive(false);
                break;
            case 1:
                RemainingHeart1.SetActive(true);
                RemainingHeart2.SetActive(false);
                RemainingHeart3.SetActive(false);
                break;
            case 0:
                RemainingHeart1.SetActive(false);
                RemainingHeart2.SetActive(false);
                RemainingHeart3.SetActive(false);

                break;

        }
    }

}

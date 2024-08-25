using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaPanel : MonoBehaviour
{
    //public GameObject alphaPanel;

    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().DOFade(0,2f);
    }
 
}

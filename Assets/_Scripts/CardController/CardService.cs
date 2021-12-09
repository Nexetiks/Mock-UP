using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CardService : MonoBehaviour
{
    private void Awake()
    {
            GameManager.Instance.cardToPutIn.DOMove(GameManager.Instance.putInPosition, 2f);
        GameManager.Instance.cardToPutIn.DOMove(GameManager.Instance.rotationToPutIn, 2f); 
    }
}
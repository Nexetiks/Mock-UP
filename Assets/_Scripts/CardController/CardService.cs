using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CardService : MonoBehaviour
{
    private void Awake()
    {
            GameManager.Instance.cardToPutIn.transform.DOMove(GameManager.Instance.positionToPutIn, 2f);
        GameManager.Instance.cardToPutIn.transform.DORotateQuaternion(GameManager.Instance.rotationToPutIn, 2f); 
    }
}
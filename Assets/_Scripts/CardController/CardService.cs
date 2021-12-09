using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CardService : MonoBehaviour
{
    private void Awake()
    {
            transform.DOMove(GameManager.Instance.positionToPutIn, 2f);
        transform.DORotateQuaternion(GameManager.Instance.rotationToPutIn, 2f);
    }
}
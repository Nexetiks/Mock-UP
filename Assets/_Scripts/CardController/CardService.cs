using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CardService : MonoBehaviour
{
    private void Awake()
    {
            transform.DOMove(GameManager.Instance.position[GameManager.Instance.positionNumber], 2f);
       transform.DORotateQuaternion(GameManager.Instance.rotation[GameManager.Instance.positionNumber], 2f);
    }
}
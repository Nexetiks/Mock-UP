using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dotweed : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0,5,0);
    [SerializeField] Ease ease;
    Vector3 startpos;

    Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        //startpos = transform.position;
        //transform.DOMove(startpos + offset, .37f).SetUpdate(true).SetEase(ease).onComplete +=OnComplete;
        
    }

    void OnComplete()
    {
        Debug.Log("Completed");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayUpAnimation();
        }
    }

    void PlayUpAnimation()
    {
        startpos = transform.position;
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(startpos + offset, .37f).SetEase(ease));
        sequence.SetUpdate(true);
        //inputblocked = true;
        sequence.onComplete += OnComplete;
    }
}

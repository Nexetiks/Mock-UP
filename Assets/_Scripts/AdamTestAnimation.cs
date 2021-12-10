using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AdamTestAnimation : MonoBehaviour
{
    public Transform trans;
    Quaternion startRotation;
    Vector3 startpos;
    public Vector3 offset = new Vector3(1, 2, 3);
    Sequence sequence;
    private void Awake()
    {
        
        trans = this.GetComponent<Transform>();
       
    }

    private void Start()
    {
        startpos = transform.position;
        // startRotation = Quaternion.ToEulerAngles(transform.rotation);
        startRotation = trans.rotation;
    }


    void OnComplete()
    {
        Debug.Log("Completed");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayYUpAnimation();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayZUpAnimation();
        }
    }
    void PlayYUpAnimation()
    {

        //startRotation = transform.rotation;
        trans.DOMove(offset, 0.5f);
        trans.DORotate(new Vector3(0,0,0),0.5f);

        //sequence = DOTween.Sequence();
        //sequence.Append(transform.DOMove(startpos + offset, .37f).SetEase(ease));
       // sequence.SetUpdate(true);
        //inputblocked = true;
        sequence.onComplete += OnComplete;
    }
    void PlayZUpAnimation()
    {
        //startRotation = transform.rotation;
        trans.DOMove(startpos, 0.5f);
        trans.DORotateQuaternion(startRotation, 0.5f);


        sequence.onComplete += OnComplete;
    }
}

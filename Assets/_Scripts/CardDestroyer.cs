using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDestroyer : MonoBehaviour
{
    [SerializeField] private float cardChangeSpeed;

    private Material mat;
    private RawImage image;
    private bool destroyCard = false;
    private float timeToDestroy;
    

    private void Start()
    {
        image = GetComponent<RawImage>();
        mat = new Material(image.material);
        mat.SetFloat("Random1", Random.value);
        mat.SetFloat("Random2", Random.value);
        image.material = mat;
        timeToDestroy = cardChangeSpeed;
    }

    public void DestroyCard()
    {
        destroyCard = true;
    }

    private void Update()
    {
        if (destroyCard)
        {
            timeToDestroy -= Time.deltaTime;
            image.material.SetFloat("DissolveValue", (cardChangeSpeed - timeToDestroy) / cardChangeSpeed);
           // Debug.Log(image.material.GetFloat("DissolveValue"));
        }
        if(timeToDestroy < 0)
        {
            Destroy(gameObject);
            GameManager.Instance.willBeDestroyed = false;
        }
            
    }
}

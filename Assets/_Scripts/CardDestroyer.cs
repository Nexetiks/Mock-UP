using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

public class CardDestroyer : MonoBehaviour
{
    [SerializeField] private float cardChangeSpeed;

    [SerializeField] private UIDissolve dissolve;

    private bool destroyCard = false;
    private float timeToDestroy;
    

    private void Start()
    {
        
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
            GameManager.Instance.willBeDestroyed = true;
            GameManager.Instance.gameplayActive = false;
            timeToDestroy -= Time.deltaTime;
            dissolve.location = (cardChangeSpeed - timeToDestroy) / cardChangeSpeed;
        }
        if(timeToDestroy < 0)
        {
            Destroy(gameObject);

            GameManager.Instance.willBeDestroyed = false;
            GameManager.Instance.gameplayActive = true;

        }

            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandList : MonoBehaviour

{
    [SerializeField]
    public CardParent card1;
    [SerializeField]
    public CardParent card2;
    [SerializeField]
    public CardParent card3;
    [SerializeField]
    public CardParent card4;
    [SerializeField]
    public CardParent card5;

    public List<CardParent> cardsInHand;
  
   

    public void MakeList()
    {
        cardsInHand.Clear();
        cardsInHand.Add(card1);
        cardsInHand.Add(card2);
        cardsInHand.Add(card3);
        cardsInHand.Add(card4);
        cardsInHand.Add(card5);
    }
    public void ShowCards()
    {
       
        for (int i=0; i < cardsInHand.Count; i++)
        {
            Instantiate(cardsInHand[i], new Vector2(i * 3 - 8, 0), Quaternion.identity).transform.parent = GameManager.Instance.handParent.transform;
            
        }

    }

    public void SendCardToHand(List<CardParent> cards)
    {
        cardsInHand.Add(cards[0]);
        cards.RemoveAt(0);
    }


    public void UsedCard( int idCard)
    {
        Debug.Log("used card" + cardsInHand.Count);
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if (cardsInHand[i].idCard == idCard)
            { cardsInHand.RemoveAt(idCard); return; }
        }
    }

    public bool OutOfHandCards()
    {
        if (cardsInHand.Count == 0) return true;
        return false;

    }
    public void RemoveAllCards()
    {
          
        for (int i = 0; i < cardsInHand.Count + i; i++)
        {

            cardsInHand.RemoveAt(0);

        }
        foreach (Transform child in GameManager.Instance.handParent.transform)
            GameObject.Destroy(child.gameObject);

       

    }
    
}

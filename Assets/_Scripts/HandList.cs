using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandList : MonoBehaviour
{   [SerializeField]
    public List<CardParent> cardsInHand;
    
  
    public void SendCardToHand(List<CardParent> cards)
    {
        cardsInHand.Add(cards[0]);
        cards.RemoveAt(0);
    }

    public void UsedCard(int index)
    {
        cardsInHand.RemoveAt(index);
    }

    public bool OutOfHandCards()
    {
        if (cardsInHand.Count == 0) return true;
        return false;

    }
}

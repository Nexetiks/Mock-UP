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


    public void UsedCard( int idCard)
    {
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if (cardsInHand[i].idCard == idCard)
                cardsInHand.RemoveAt(idCard);
        }
    }

    public bool OutOfHandCards()
    {
        if (cardsInHand.Count == 0) return true;
        return false;

    }
}

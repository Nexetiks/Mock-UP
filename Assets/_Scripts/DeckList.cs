using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckList : MonoBehaviour
{
	public List<CardParent> cards;

	[SerializeField]
	public void MixList() // to musi sie wywolac zaraz po tym jak dodamy wszystkie karty
	{

		for (int i = 0; i < cards.Count; i += 1)
		{
			int swapIndex = Random.Range(0, cards.Count);
			if (swapIndex != i)
			{
				CardParent tmp = cards[i];
				cards[i] = cards[swapIndex];
				cards[swapIndex] = tmp;
			}
		}
	}


	public bool OutOfCards(List<CardParent> cards)
    {
		if (cards.Count == 0) return true;
		return false;

    }

	

	

	

	

	
}


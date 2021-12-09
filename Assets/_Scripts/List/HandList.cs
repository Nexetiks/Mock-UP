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
    private CardParent go;
    public List<CardParent> cardsInHand;

    private Vector3 position;
    private Vector3 scale;
    private Quaternion rotation;



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
        int temp= 0;
        for (int i=0; i < cardsInHand.Count; i++)
        {
            go = Instantiate(cardsInHand[i], new Vector3(0,0,0), Quaternion.identity);
            go.transform.parent = GameManager.Instance.handParent.transform;
            go.transform.localScale = new Vector3(1, 1, 1);
             if(temp==0) go.transform.localPosition = new Vector3(-270 + i*135 , -385 , 0);
            else if (temp == 1) go.transform.localPosition = new Vector3(-270 + i * 135, -375, 0);
            else if (temp == 2) go.transform.localPosition = new Vector3(-270 + i * 135, -370, 0);
            else if (temp == 3) go.transform.localPosition = new Vector3(-270 + i * 135, -375, 0);
            else if (temp == 4) go.transform.localPosition = new Vector3(-270 + i * 135, -385, 0);
            temp++;
            go.transform.localRotation = Quaternion.Euler(0, 0, -(-4.2f + 2.1f * i));

        }
    

    }

    public void SendCardToHand(List<CardParent> cards)
    {
        Debug.Log(cards.Count);
        if (cards.Count > 0)
        {
            cardsInHand.Add(cards[0]);
            cardsInHand[cardsInHand.Count - 1].transform.localScale = scale;
            cardsInHand[cardsInHand.Count - 1].transform.localPosition = position;
            cardsInHand[cardsInHand.Count - 1].transform.localRotation = rotation;

            cards.RemoveAt(0);
        }
    }


    public void UsedCard( int idCard)
    {
      
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if (cardsInHand[i].idCard == idCard)
            {
                position =cardsInHand[i].transform.localPosition;
                scale= cardsInHand[i].transform.localScale;
                rotation = cardsInHand[i].transform.localRotation;
                Debug.Log(position);
                Debug.Log(scale);
                Debug.Log(rotation);
                cardsInHand.RemoveAt(idCard); 
                return; 
            }
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

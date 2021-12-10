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
    private int help;

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
        ///////////////pozycje
        GameManager.Instance.position.Add(new Vector3(-28.9f,-41.2f,65f));
        GameManager.Instance.position.Add(new Vector3(-14.4f, -40.1f, 65f));
        GameManager.Instance.position.Add(new Vector3(0f, -39.6f, 65f));
        GameManager.Instance.position.Add(new Vector3(14.4f, -40.1f, 65f));
        GameManager.Instance.position.Add(new Vector3(28.9f, -41.2f, 65f));



        ////////////////rotacje
        GameManager.Instance.rotation.Add(Quaternion.Euler(new Vector3(0, 0, 4.2f )));
        GameManager.Instance.rotation.Add(Quaternion.Euler(new Vector3(0, 0, 2.1f)));
        GameManager.Instance.rotation.Add(Quaternion.Euler(new Vector3(0, 0, 0)));
        GameManager.Instance.rotation.Add(Quaternion.Euler(new Vector3(0, 0, -2.1f)));
        GameManager.Instance.rotation.Add(Quaternion.Euler(new Vector3(0, 0, -4.2f)));

    }

   

    public int GetIndex(int idCard)
    {
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if (cardsInHand[i].idCard == idCard)
            {
               
                return i;
            }
          
        }
        return -1;

    }
    public void SendCardToHand(List<CardParent> cards)
    {

        if (cards.Count > 0)
        {
            cardsInHand.Insert(GameManager.Instance.indexHelper, cards[0]);
            //  cardsInHand.Insert(2, cards[0]);
            Debug.Log("send card to hend po czyms tam " + GameManager.Instance.indexHelper);
            go = Instantiate(cardsInHand[cardsInHand.Count - 1], new Vector3(0, 0, 0), Quaternion.identity);
            go.transform.parent = GameManager.Instance.handParent.transform;
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.localPosition = new Vector3(0, -1000, 1);

            go.gameObject.AddComponent<CardService>();

           
            cards.RemoveAt(0);
        }
    }
    public void UsedCard( int idCard)
    {
       // Debug.Log("na samym wejsciu do funkcji " + GameManager.Instance.indexHelper);
        
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            
            if (cardsInHand[i].idCard == idCard)
            {
               // Debug.Log("i " + i);
                cardsInHand.RemoveAt(i);
                GameManager.Instance.indexHelper = i;
                Debug.Log(GameManager.Instance.indexHelper);

                return; 
            }
        }
       // Debug.Log(GameManager.Instance.indexHelper);
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

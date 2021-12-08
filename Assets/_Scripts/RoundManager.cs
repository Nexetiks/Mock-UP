using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    void Start()
    {
        GameManager.Instance.Dl.MixList();
        //show card in hands



        GameManager.Instance.gameplayActive = true;
    }





    public void endOfTheRound() // kiedy to sie wywolywuje XD
    {

        GameManager.Instance.gameplayActive = false;
        GameManager.Instance.round++;

       // GameManager.Instance.Hl.UsedCard();//poprawic to

      //  GameManager.Instance.Hl.UsedCard();


        Wealth();

        SetMoney();

        SetPopulation();

        if (IsEndGame() == true)
        {
            GameManager.Instance.gameplayActive = false;
            //funckja na koniec gry

        }


    }


    public void Wealth()
    {
        GameManager.Instance.wealth = GameManager.Instance.wealth * (1 - GameManager.Instance.crime);
    }

    public void SetMoney()
    {
        GameManager.Instance.money = GameManager.Instance.money + GameManager.Instance.wealth * GameManager.Instance.tax;
    }


    public void SetPopulation()
    {
        if (GameManager.Instance.loyalty < 0.80f && GameManager.Instance.happiness * 2 > 1.0f) GameManager.Instance.population = GameManager.Instance.population * GameManager.Instance.happiness * 2;

    }

    public bool IsEndGame()
    {
        if (GameManager.Instance.loyalty == 0 && GameManager.Instance.fear < 0.8f)
            return true;

        if (GameManager.Instance.population == 0) return true;


        int helper = 0;

        for (int i = 0; i < GameManager.Instance.Hl.cardsInHand.Count; i++)
        {
            if (GameManager.Instance.Hl.cardsInHand[i].costAmount <= GameManager.Instance.money) return true;
            else helper++;
        }

        if (GameManager.Instance.Hl.cardsInHand.Count == helper)
        {
            return true;
        }
        return false;
    }

}

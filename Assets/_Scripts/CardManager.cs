using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    

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

        // tutaj warunek kart i kasy => jesli za malo kasy na zakup karty to koniec
        //if()

        return false;

    }
}

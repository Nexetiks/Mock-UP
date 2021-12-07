using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    public float population = 10;
    [SerializeField]
    public float money = 125;
    [SerializeField]
    public float happiness = 0;
    [SerializeField]
    public float loyalty = 0;
    [SerializeField]
    public float fear = 0;
    [SerializeField]
    public float education = 0;
    [SerializeField]
    public float crime = 0;
    [SerializeField]
    public float wealth = 0;
    [SerializeField]
    private float tax = 0.20f;
    [SerializeField]
    private GameObject cardParent;




    public void Wealth()
    {
        wealth =  wealth * (1 - crime);
    }

    public void SetMoney()
    {
        money = money + wealth *tax ;
    }
  

    public void SetPopulation()
    {
        if (loyalty < 0.80f && happiness * 2 > 1.0f) population = population * happiness * 2;
       
    }

    public bool IsEndGame()
    {
        if (loyalty == 0 && fear < 0.8f)
            return true;

        else if (population == 0) return true;

        else return false;
        

    }






}

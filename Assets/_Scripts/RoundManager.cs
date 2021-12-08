using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundMenager : MonoBehaviour
{
    
    void Start()
    {
        GameManager.Instance.dl.MixList();
        //show card in hands



        GameManager.Instance.gameplayActive = true;
    }
    
   public void endOfTheRound()
    {


    }


}

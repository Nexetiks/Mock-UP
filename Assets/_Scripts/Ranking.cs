using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
   public void CheckRanking()
    {
        for(int i = 0; i < 8; i++)
        {
            if(GameManager.Instance.scoreList[i] <GameManager.Instance.Score )
            {
                GameManager.Instance.scoreList.Insert(i, GameManager.Instance.Score);
                GameManager.Instance.scoreList.RemoveAt(8);
                return;
            }

        }

        GameManager.Instance.SaveGame();

    }
}

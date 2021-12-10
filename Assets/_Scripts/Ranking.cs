using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText1;
    [SerializeField]
    private TMP_Text scoreText2;
    [SerializeField]
    private TextMeshProUGUI scoreText3;
    [SerializeField]
    private TextMeshProUGUI scoreText4;
    [SerializeField]
    private TextMeshProUGUI scoreText5;
    [SerializeField]
    private TextMeshProUGUI scoreText6;
    [SerializeField]
    private TextMeshProUGUI scoreText7;
    [SerializeField]
    private TextMeshProUGUI scoreText8;

    [SerializeField]
    private TMP_Text nameText1;
    [SerializeField]
    private TMP_Text nameText2;
    [SerializeField]
    private TextMeshProUGUI nameText3;
    [SerializeField]
    private TextMeshProUGUI nameText4;
    [SerializeField]
    private TextMeshProUGUI nameText5;
    [SerializeField]
    private TextMeshProUGUI nameText6;
    [SerializeField]
    private TextMeshProUGUI nameText7;
    [SerializeField]
    private TextMeshProUGUI nameText8;

    public void CheckRanking()
    {
        try
        {
            for (int i = 0; i < 8; i++)
            {

                if (GameManager.Instance.scoreList[i] < GameManager.Instance.Score)
                {

                    GameManager.Instance.scoreList.Insert(i, GameManager.Instance.Score);
                    GameManager.Instance.scoreList.RemoveAt(8);
                    GameManager.Instance.nameList.Insert(i, GameManager.Instance.Name.text);
                    GameManager.Instance.nameList.RemoveAt(8);
                    FillScoreTextbox();
                    FillNameTextbox();
                    GameManager.Instance.SaveGame();
                    return;

                }
            }
            FillScoreTextbox();
            FillNameTextbox();
            GameManager.Instance.SaveGame();
        }
        catch
        {
            GameManager.Instance.nameList.Clear();
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.nameList.Add("Cyberiada...");
            GameManager.Instance.scoreList.Clear();
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.scoreList.Add(1);
            GameManager.Instance.SaveGame();

        }
    }

    public void FillScoreTextbox()
    {
        scoreText1.text = GameManager.Instance.scoreList[0].ToString();
        scoreText2.text = GameManager.Instance.scoreList[1].ToString();
        scoreText3.text = GameManager.Instance.scoreList[2].ToString();
        scoreText4.text = GameManager.Instance.scoreList[3].ToString();
        scoreText5.text = GameManager.Instance.scoreList[4].ToString();
        scoreText6.text = GameManager.Instance.scoreList[5].ToString();
        scoreText7.text = GameManager.Instance.scoreList[6].ToString();
        scoreText8.text = GameManager.Instance.scoreList[7].ToString();

    }
    public void FillNameTextbox()
    {
        nameText1.text = GameManager.Instance.nameList[0];
        nameText2.text = GameManager.Instance.nameList[1];
        nameText3.text = GameManager.Instance.nameList[2];
        nameText4.text = GameManager.Instance.nameList[3];
        nameText5.text = GameManager.Instance.nameList[4];
        nameText6.text = GameManager.Instance.nameList[5];
        nameText7.text = GameManager.Instance.nameList[6];
        nameText8.text = GameManager.Instance.nameList[7];

    }

}

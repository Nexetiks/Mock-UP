using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public MusicManager musicManager;
    [SerializeField]
    public float Score;
    public List <float> scoreList;
    [SerializeField]
    public GameObject handParent;
    [SerializeField]
    public float population = 10;
    [SerializeField]
    public float money = 125;
    [SerializeField]
    public float happiness = 0.5f;
    [SerializeField]
    public float loyalty = 0.5f;
    [SerializeField]
    public float fear = 0.5f;
    [SerializeField]
    public float education = 0.5f;
    [SerializeField]
    public float crime = 0.5f;
    [SerializeField]
    public float wealth = 0.5f;
    [SerializeField]
    public float tax = 0.20f;
    [SerializeField]
    public int round = 1;
    [SerializeField]
    public bool gameplayActive = false;
    [SerializeField]
    public bool isDragged = false;
    [SerializeField]
    public bool isBacking=false;

    [SerializeField]
    public GameObject buttonEnd;
    [SerializeField]
    public GameObject mainPanel;
    [SerializeField]

    public int positionNumber;

    [SerializeField]
    public HandList HandList;
    public DeckList DeskList;
    
    public static GameManager Instance;

    [SerializeField]
    private Camera mainCamera;


    [SerializeField]
    private Image fearStat;
    [SerializeField]
    private Image happinessStat;
    [SerializeField]
    private Image loyaltyStat;
    [SerializeField]
    private Image educationStat;
    [SerializeField]
    private Image crimeStat;
    [SerializeField]
    private GameObject populationStat;
    [SerializeField]
    private GameObject moneyStat;
    [SerializeField]
    private GameObject wealthStat;
    [SerializeField]
    public List<Vector3> position = new List<Vector3>();
    [SerializeField]
    public List<Quaternion> rotation = new List<Quaternion>();
    
    public CardService cardService;
    [SerializeField]
    public int indexHelper=2;
    [SerializeField]
    public Ranking ranking;
    public TextMeshProUGUI Name;
    public List<string> nameList;
    [SerializeField]
    public bool willBeDestroyed = false;

    [SerializeField]
    public int discardAmount=0;
    [SerializeField]
    public int chosenToDiscard=3;

    [SerializeField]
    public bool waitForDiscard = false;

    public void ChangeFillAmount()
    {
        fearStat.GetComponent<Image>().fillAmount = fear;
        happinessStat.GetComponent<Image>().fillAmount = happiness;
        loyaltyStat.GetComponent<Image>().fillAmount = loyalty;
        educationStat.GetComponent<Image>().fillAmount = education;
        crimeStat.GetComponent<Image>().fillAmount = crime;
       
        populationStat.gameObject.GetComponent<TextMeshProUGUI>().text = population.ToString();
        moneyStat.gameObject.GetComponent<TextMeshProUGUI>().text = money.ToString();
        wealthStat.gameObject.GetComponent<TextMeshProUGUI>().text = wealth.ToString();


    }
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadGame()
    {
        GMData data = SaveSystem.LoadGame();
        this.scoreList = data.points;
        this.nameList = data.names;
   
        
    }
    public void ChangeCameraPosition()
    {
        mainCamera.transform.position = new Vector3(0, 130, -814);


    }

    public void GoToMainPosition()
    {
        mainCamera.transform.position = new Vector3(0, 0, -814);
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Debug.Log("An instance error");
        ChangeFillAmount();
       
        LoadGame();
      
    }
    public void AppQuit()
    {
        Application.Quit(1);
    }


}

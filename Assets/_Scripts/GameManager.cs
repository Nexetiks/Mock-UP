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
    [SerializeField]
    public GameObject handParent;
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

    public Vector3 positionToPutIn;
    [SerializeField]
    public Quaternion rotationToPutIn;
    [SerializeField]
    public RawImage cardToPutIn;
    

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
    public List<Vector3> position = new List<Vector3>();
    public List<Quaternion> rotation = new List<Quaternion>();
    
    public CardService cardService;


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
    public void ChangeCameraPosition()
    {
        mainCamera.transform.position = new Vector3(0, 130,-35);


    }

    public void GoToMainPosition()
    {
        mainCamera.transform.position = new Vector3(0, 0,-35);
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Debug.Log("An instance error");
        ChangeFillAmount();
      
    }


}

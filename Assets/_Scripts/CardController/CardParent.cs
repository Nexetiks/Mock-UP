using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

abstract public class CardParent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler, IDragHandler
{
    private RoundManager Rm;

    [SerializeField]
    public float costAmount = 0;

    [SerializeField]
    public int idCard;

    [SerializeField]
    public float populationAmount = 0;
    [SerializeField]
    public float populationMultiplier = 1;

    [SerializeField]
    public float moneyAmount = 0;
    [SerializeField]
    public float moneyMultiplier = 1;

    [SerializeField]
    public float happinessAmount = 0;
    [SerializeField]
    public float happinessMultiplier = 1;

    [SerializeField]
    public float loyaltyAmount = 0;
    [SerializeField]
    public float loyaltyMultiplier = 1;

    [SerializeField]
    public float fearAmount = 0;
    [SerializeField]
    public float fearMultiplier = 1;

    [SerializeField]
    public float educationAmount = 0;
    [SerializeField]
    public float educationMultiplier = 1;

    [SerializeField]
    public float crimeAmount = 0;
    [SerializeField]
    public float crimeMultiplier = 1;

    [SerializeField]
    public float wealthAmount = 0;
    [SerializeField]
    public float wealthMultiplier = 1;

    [SerializeField]
    public float taxAmount = 20;

    [SerializeField]
    public float taxMultiplier = 1;



    [SerializeField]
    public bool isDragged = false, isHovered = false;

    [SerializeField]
    public TextMesh textCard;

    [SerializeField]
    public Camera cam;

    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    public Texture textureCard;

    [SerializeField]
    public RawImage rawImage;

    [SerializeField]
    public RectTransform rectTra;

    [SerializeField]
    public int helpe=0;


    [SerializeField]
    public Vector3 viewPortCardPosition;

    [SerializeField]
    public Vector3 worldPosition, startPostion, temporaryPosition;

    [SerializeField]
    public Quaternion startRotation,temporaryRotation;

    [SerializeField]
    public int x;
    [SerializeField]
    public int xCount;


    virtual public void Awake()
    {
        canvas = FindObjectOfType<Canvas>();

        rectTra = this.GetComponent<RectTransform>();
        rawImage = this.GetComponent<RawImage>();

        cam = Camera.main;
        Rm = new RoundManager();
       

    }

    private void Start()
    {
      //  startPostion = GameManager.Instance.indexHelper;
        startPostion = GameManager.Instance.position[GameManager.Instance.indexHelper];
        startRotation = GameManager.Instance.rotation[GameManager.Instance.indexHelper];
        
    }

    virtual public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDRAG();
    }

    virtual public void OnDrag(PointerEventData eventData)
    {
       
        rawImage.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, 0f), 0.2f);
        rawImage.transform.DOMove(new Vector3((cam.ScreenToWorldPoint(MousePlace())).x, (cam.ScreenToWorldPoint(MousePlace())).y, (cam.ScreenToWorldPoint(MousePlace())).z - 20f), 0.2f);
    }

    virtual public void OnPointerEnter(PointerEventData eventData)
    {

        if (helpe == 0)
        {
            temporaryPosition = transform.position;
            temporaryRotation = transform.rotation;
            helpe = 1;
        }


        if (GameManager.Instance.isDragged == false && rawImage.transform.position == temporaryPosition)
        {
            

 
            GameManager.Instance.isBacking = false;
            GameManager.Instance.musicManager.PlaySound("cardHover");

            rawImage.transform.DOMove(new Vector3(rawImage.transform.position.x, rawImage.transform.position.y + 10f, rawImage.transform.position.z - 15f), 0.7f);
            rawImage.transform.DORotateQuaternion(Quaternion.Euler(0f, 0f, 0f), 0.7f);

            MouseENTER();
            
        }
    }

    virtual public void OnPointerExit(PointerEventData eventData)
    {
       
        if (GameManager.Instance.isDragged == false)
        {
            rawImage.transform.DOMove(temporaryPosition, 0.71f);
            rawImage.transform.DORotateQuaternion(temporaryRotation, 0.71f);
        }
        MouseEXIT();
    }

    virtual public void OnEndDrag(PointerEventData eventData)
    {
       
        if (IsCardPlaced() != true)
        {
            GameManager.Instance.isDragged = false;
            GameManager.Instance.isBacking = true;

            rawImage.transform.DOMove(temporaryPosition, 0.71f);
            rawImage.transform.DORotateQuaternion(temporaryRotation, 0.71f);
            MouseUP();
        }
    }



    virtual public void CardInvocate()
    {

        GameManager.Instance.money = GameManager.Instance.money - costAmount;


        GameManager.Instance.population = GameManager.Instance.population + populationAmount;
        GameManager.Instance.population = GameManager.Instance.population * populationMultiplier;

        GameManager.Instance.money = GameManager.Instance.money + moneyAmount;
        GameManager.Instance.money = GameManager.Instance.money * moneyMultiplier;

        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness + happinessAmount / 100);
        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness * happinessMultiplier);

        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty + loyaltyAmount / 100);
        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty * loyaltyMultiplier);

        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear + fearAmount / 100);
        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear * fearMultiplier);

        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education + educationAmount / 100);
        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education * educationMultiplier);

        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime + crimeAmount / 100);
        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime * crimeMultiplier);

        GameManager.Instance.wealth = GameManager.Instance.wealth + wealthAmount;
        GameManager.Instance.wealth = GameManager.Instance.wealth * wealthMultiplier;

        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax + taxAmount / 100);
        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax * taxMultiplier);
    }


    //Returning mouse position to be able to move cards
    virtual public Vector3 MousePlace()
    {
        Vector3 placeOfMouse = Input.mousePosition;
        placeOfMouse.z = canvas.planeDistance;
        worldPosition = cam.ScreenToWorldPoint(placeOfMouse);

        return placeOfMouse;
    }


    //Cheking if the card is places in the center
    virtual public bool IsCardPlaced()
    {
        if (GameManager.Instance.gameplayActive == true)
        {
            viewPortCardPosition = cam.WorldToViewportPoint(rawImage.rectTransform.position);
            if (viewPortCardPosition.y > 0.5f)
            {

                
                GameManager.Instance.positionNumber = GameManager.Instance.HandList.GetIndex(idCard);

                CardInvocate();
                GameManager.Instance.ChangeFillAmount();


                GameManager.Instance.musicManager.PlaySound("throw");

                GameManager.Instance.isDragged = false;


                GameManager.Instance.HandList.UsedCard(idCard);

                Destroy(gameObject);
                
                

                GameManager.Instance.HandList.SendCardToHand(GameManager.Instance.DeskList.cards);

                ///prosze pamietac byc to zmienic
                Rm.EndOfTheRound();

                return true;
            }
            else return false;
        }
        return false;
    }


    virtual public void BeginDRAG()
    {
        GameManager.Instance.isDragged = true;
        isHovered = true;
    }

    virtual public void MouseENTER()
    {
        isHovered = true;
    }

    virtual public void MouseEXIT()
    {
        isHovered = false;
    }

    virtual public void MouseUP()
    {
        GameManager.Instance.isDragged = false;
    }
    virtual public void cardReplacement()
    {

        if (GameManager.Instance.DeskList.cards.Count == 0)
        {
            xCount = GameManager.Instance.HandList.cardsInHand.Count;


            for (int i = 0; i < xCount; i++)
            {
                if (startPostion == GameManager.Instance.position[i])
                {

                    x = i;
                }
            }


            if (xCount == 1)
            {
                this.startPostion = GameManager.Instance.position[2];
                this.temporaryPosition = GameManager.Instance.position[2];
                this.rawImage.rectTransform.position = GameManager.Instance.position[2];
                this.rawImage.transform.position = GameManager.Instance.position[2];

                this.gameObject.transform.localPosition = GameManager.Instance.position[2];
                this.gameObject.transform.position = GameManager.Instance.position[2];

                Debug.Log(GameManager.Instance.position[2]);
                Debug.Log(this.gameObject);
                Debug.Log(this.gameObject.transform.position);
                Debug.Log("1");
            }
            /*
            if (xCount == 3)
            {
                startPostion = GameManager.Instance.position[x + 1];
                temporaryPosition = GameManager.Instance.position[x + 1];
                Debug.Log("3");
            }


            if (xCount == 5)
            {
                startPostion = GameManager.Instance.position[x];
                temporaryPosition = GameManager.Instance.position[x];
                Debug.Log("5");
            }
            */
        }


    }
}

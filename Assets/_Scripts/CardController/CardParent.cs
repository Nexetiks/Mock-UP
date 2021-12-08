using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class CardParent : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IPointerExitHandler,IPointerEnterHandler,IDragHandler
{
    public float costAmount=0;

    public int idCard;

    public float populationAmount=0;
    public float populationMultiplier=1;

    public float moneyAmount=0;
    public float moneyMultiplier=1;

    public float happinessAmount = 0;
    public float happinessMultiplier=1;

    public float loyaltyAmount = 0;
    public float loyaltyMultiplier=1;

    public float fearAmount = 0;
    public float fearMultiplier=1;

    public float educationAmount = 0;
    public float educationMultiplier=1;

    public float crimeAmount = 0;
    public float crimeMultiplier=1;

    public float wealthAmount = 0;
    public float wealthMultiplier=1;

    public float taxAmount = 0;
    public float taxMultiplier=1;

    public Camera cam;

    public bool isDragged = false, isHovered = false;

    public TextMesh textCard;

    Canvas canvas;

    public Texture textureCard;


    public RawImage rawImage;

    Vector3 viewPortCardPosition;

    /// <summary>
    /// mozliwe ze zostanie zmienione na przypisywanie i inspektorze
    /// </summary>
    public Vector3 initialPosition;

    public Vector3 worldPosition;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        initialPosition = rawImage.rectTransform.position;
        cam = Camera.main;

    }


    



    virtual public void CardInvocate() {


        GameManager.Instance.money = GameManager.Instance.money - costAmount;


        GameManager.Instance.population = GameManager.Instance.population + populationAmount;
        GameManager.Instance.population = GameManager.Instance.population * populationMultiplier;

        GameManager.Instance.money = GameManager.Instance.money + moneyAmount;
        GameManager.Instance.money = GameManager.Instance.money * moneyMultiplier;

        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness + happinessAmount);
        GameManager.Instance.happiness = Mathf.Clamp01(GameManager.Instance.happiness * happinessMultiplier);

        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty + loyaltyAmount);
        GameManager.Instance.loyalty = Mathf.Clamp01(GameManager.Instance.loyalty * loyaltyMultiplier);

        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear + fearAmount);
        GameManager.Instance.fear = Mathf.Clamp01(GameManager.Instance.fear * fearMultiplier);

        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education + educationAmount);
        GameManager.Instance.education = Mathf.Clamp01(GameManager.Instance.education * educationMultiplier);

        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime + crimeAmount);
        GameManager.Instance.crime = Mathf.Clamp01(GameManager.Instance.crime * crimeMultiplier);

        GameManager.Instance.wealth = GameManager.Instance.wealth + wealthAmount;
        GameManager.Instance.wealth = GameManager.Instance.wealth * wealthMultiplier;

        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax + taxAmount);
        GameManager.Instance.tax = Mathf.Clamp01(GameManager.Instance.tax * taxMultiplier);


    }
    


   
   
    virtual public void BeginDRAG()
    {
        isDragged = true;
        isHovered = true;
    }


    virtual public void mouseENTER()
    {
        isHovered = true;
    }


    virtual public void MouseEXIT()
    {
        isHovered = false;
    }


    virtual public void mouseUP()
    {
        isDragged = false;
        
    }


    //Cheking if the card is places in the center
    public bool isCardPlaced()
    {
        //if (GameManager.Instance.gameplayActive == true)
        
            viewPortCardPosition = cam.WorldToViewportPoint(rawImage.rectTransform.position);


            if (viewPortCardPosition.y > 0.5f)
            {
                Debug.Log(viewPortCardPosition);
                Destroy(gameObject);//w dalszym etapie zamiana/dodanie na animacje

                GameManager.Instance.Hl.UsedCard(idCard);
                return true;
            }
            else return false;
        
    }




    //Returning mouse position to be able to move cards
    virtual public Vector3 mousePlace()
    {
        Vector3 placeOfMouse = Input.mousePosition;
        placeOfMouse.z = canvas.planeDistance;
        worldPosition = cam.ScreenToWorldPoint(placeOfMouse);


        return placeOfMouse;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCardPlaced() == true) ;//end of the round
        else
        {
            rawImage.rectTransform.position = initialPosition;
            rawImage.rectTransform.sizeDelta = new Vector2(100, 100);
            mouseUP();

        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
        BeginDRAG();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isDragged == false)
        {
            rawImage.rectTransform.sizeDelta = new Vector2(100, 100);
        }
        MouseEXIT();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
        mouseENTER();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rawImage.rectTransform.position = cam.ScreenToWorldPoint(mousePlace());
    }
}

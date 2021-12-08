using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class CardParent : MonoBehaviour
{
    public float costAmount;
   

    public float populationAmount;
    public float populationMultiplier;

    public float moneyAmount;
    public float moneyMultiplier;

    public float happinessAmount;
    public float happinessMultiplier;

    public float loyaltyAmount;
    public float loyaltyMultiplier;

    public float fearAmount;
    public float fearMultiplier;

    public float educationAmount;
    public float educationMultiplier;

    public float crimeAmount;
    public float crimeMultiplier;

    public float wealthAmount;
    public float wealthMultiplier;

    public float taxAmount;
    public float taxMultiplier;




    public TextMesh textCard;


    public Texture textureCard;


     public  RawImage rawImage;



    public bool isClicked = false, isInvaded = false;


    public Vector3 clickedd = new Vector3(0f, -300f, 0f);
    public Vector3 startPosition = new Vector3(0f, -440f, 0f);
    public  Vector3 centerConst = new Vector3(960f, 540f, 0f);


    public Vector3 placeOfMouse, worldPosition;



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




    virtual public void OnMouseDrag()
    {
        mouseDRAG();

    }
    virtual public void mouseDRAG()
    {
        isClicked = true;
        isInvaded = true;
    }


    virtual public void OnMouseEnter()
    {
        mouseENTER();
    }
    virtual public void mouseENTER()
    {
        isInvaded = true;
    }


    private void OnMouseExit()
    {
        MouseEXIT();
    }
    virtual public void MouseEXIT()
    {
        isClicked = false;
        isInvaded = false;
    }


    virtual public void OnMouseUp()
    {
        mouseUP();
    }
    virtual public void mouseUP()
    {
        isClicked = false;
    }



    virtual public void Update()
    {
        updateR();
    }

    virtual public void updateR()
    {
        //Object is invaded but it is not clicked
        //MOUSE ENTER
        if (isInvaded == true && isClicked == false)
        {
            if (isItPlaced() != true)
            {
                rawImage.rectTransform.position = centerConst + clickedd;
                rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
            }
        }


        //Object is invaded but also is also clicked
        //MOUSE DRAG
        if (isInvaded == true && isClicked == true)
        {
            rawImage.rectTransform.sizeDelta = new Vector2(300, 300);
            rawImage.rectTransform.position = new Vector3(mousePlace().x, mousePlace().y - (rawImage.rectTransform.sizeDelta.y/3), mousePlace().z);   
        }

        //Object is NOT invaded and it is NOT clicked
        //MouseEXIT
        if (isInvaded == false && isClicked == false)
        {
            rawImage.rectTransform.sizeDelta = new Vector2(100, 100);

            rawImage.rectTransform.position = centerConst+startPosition; 

        }


    }


    //Cheking if the card is places in the center
    public bool isItPlaced()
    {
        if (rawImage.rectTransform.position.y > 350)
        {
            Destroy(gameObject);//w dalszym etapie zamiana/dodanie na animacje
            return true;
        }
        else return false;
    }




    //Returning mouse position to be able to move cards
    virtual public Vector3 mousePlace()
    {
        Vector3 placeOfMouse = Input.mousePosition;
        placeOfMouse.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(placeOfMouse);


        return placeOfMouse;
    }

}

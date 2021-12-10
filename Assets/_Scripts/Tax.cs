using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax : AllCardClass
{
    override public void CardInvocate()
    {
        GameManager.Instance.tax = Mathf.Clamp01(.5f - GameManager.Instance.happiness);
        GameManager.Instance.happiness = .5f;
    }

}

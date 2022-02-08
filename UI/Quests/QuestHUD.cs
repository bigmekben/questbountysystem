using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHUD : MonoBehaviour
{
    private AccomplishmentTracker accomplishmentTracker;
    public Text textToUpdate;

    private void Awake()
    {
        accomplishmentTracker = FindObjectOfType<AccomplishmentTracker>();
        if (accomplishmentTracker == null)
            Debug.Log("SquarePickup: Something wrong with getting the accomplishment trigger");
    }

    // step one: hard-code the quest into this object.

    // step two: generalize it so that each quest knows what to do to update on the UI.

}

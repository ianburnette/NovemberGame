using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    #region PrivateVariables
    [SerializeField] Text itemText;
    [SerializeField] string[] namesOfItems;
    [SerializeField] int currentItem;

    //Seeds
    [SerializeField] Vector2 seedCountRange;
    [SerializeField] ParticleSystem seedBagParticleSystem;
    #endregion
    #region PublicProperties

    #endregion
    #region UnityFunctions
    void Start () {
	
    }
    void Update () {
        GetInteractInput();
        GetItemChangeInput();
        ShowUI();
    }
    #endregion
    #region CustomFunctions
    #region ChangingItems
    void GetItemChangeInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeItem(3);
    }
    void ChangeItem (int itemToChangeTo)
    {
        currentItem = itemToChangeTo;
    }
    void ShowUI()
    {
        itemText.text = "Current Item: " + namesOfItems[currentItem];
    }
    #endregion
    #region UsingItems
    void GetInteractInput()
    {
        if (Input.GetButtonDown("Interact"))
        {
            UseItem(currentItem);
        }
    }
    void UseItem(int itemToUse)
    {
        switch (itemToUse)
        {
            case 0:
                print("use rake");
                break;
            case 1:
                ThrowSeeds();
                break;
            case 2:
                print("use axe");
                break;
            case 3:
                print("use shears");
                break;
        }
        
    }
    void ThrowSeeds()
    {
        seedBagParticleSystem.Emit(Mathf.RoundToInt(Random.Range(seedCountRange.x, seedCountRange.y)));
    }
    #endregion
    #endregion
}

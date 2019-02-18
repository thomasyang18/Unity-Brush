using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeDisplay : MonoBehaviour
{

    public Text buttonText;
    public Text displayText;
    public string itemType;
    public int itemUpgrade;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();   
    }

    void UpdateText() {

        buttonText.text = "Cost: " + playerShop.getCostString(itemType, itemUpgrade);
        if (itemType == "AutoClick")
        {
            
        }
        else {
            displayText.text = itemName + " LVL " + playerShop.getLevelString(itemType, itemUpgrade);
        }
    }
}

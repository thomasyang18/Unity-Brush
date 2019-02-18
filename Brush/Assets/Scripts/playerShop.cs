using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShop : MonoBehaviour
{
    // The following 3 integers are the amount of upgrades for each category.
    public int numOfClickPowerUpgrades = 0;
    public int numOfCapUpgrades = 0;
    public int numOfMoneyUpgrades = 0;
    public int numOfAutoClickUpgrades = 0;
    // idk how to solve this but 3 static integers to call on that equal money, clickPower, and cap respectively
    public static int clickPowerUpgrades;
    public static int capUpgrades;
    public static int moneyUpgrades;
    public static int autoClickUpgrades;
    public static int clickPowerExponent = 15;
    public static int capExponent = 7;
    public static int moneyExponent = 10;
    public static int autoClickExponent = 50;
    public float GrowthPerLevel = 1.05f; // cost scale
    private static ItemData[] clickPowerLevels;
    private static ItemData[] capLevels;
    private static ItemData[] moneyLevels;
    private static ItemData[] autoClickLevels;
    void Start()
    {
        clickPowerUpgrades = numOfClickPowerUpgrades;
        capUpgrades = numOfCapUpgrades;
        moneyUpgrades = numOfMoneyUpgrades;
        autoClickUpgrades = numOfAutoClickUpgrades;
        clickPowerLevels = new ItemData[clickPowerUpgrades];
        capLevels = new ItemData[capUpgrades];
        moneyLevels = new ItemData[moneyUpgrades];
        autoClickLevels = new ItemData[numOfAutoClickUpgrades];
        // Initialize all of the spots
        for (int i = 0; i < moneyUpgrades; i++) {
            moneyLevels[i] = new ItemData("Money", i, 0, Mathf.Pow(moneyExponent, i+1), GrowthPerLevel);
        }
        for (int i = 0; i < clickPowerUpgrades; i++)
        {
            clickPowerLevels[i] = new ItemData("ClickPower", i, 0, Mathf.Pow(clickPowerExponent, i + 1), GrowthPerLevel);
        }
        for (int i = 0; i < capUpgrades; i++)
        {
            capLevels[i] = new ItemData("Cap", i, 0, Mathf.Pow(capExponent, i + 1), GrowthPerLevel);
        }
        for (int i = 0; i < autoClickUpgrades; i++)
        {
            autoClickLevels[i] = new ItemData("AutoClick", i, 0, Mathf.Pow(autoClickExponent, i + 1), GrowthPerLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static double collectiveSum(string type) {
        double sum = 0;
        if (type == "Money")
        {
            for (int i = 0; i < moneyUpgrades; i++)
            {
                sum += moneyLevels[i].Behaviour();
            }
        }
        else if (type == "ClickPower")
        {
            for (int i = 0; i < clickPowerUpgrades; i++)
            {
                sum += clickPowerLevels[i].Behaviour();
            }
        }
        else if (type == "Cap")
        {
            for (int i = 0; i < capUpgrades; i++)
            {
                sum += capLevels[i].Behaviour();
            }
        }
        else if (type == "AutoClick") {
            for (int i = 0; i < autoClickUpgrades; i++)
            {
                sum += autoClickLevels[i].Behaviour();
            }
        }
        return sum;
    }


    public void UpgradeClicked(string type) {
        // Type will be a SPLIT string with first half type, space, second half upgrade number.
        string[] data = type.Split();
        int upgrade = Int32.Parse(data[1]);
        type = data[0];
        int times = 1;
        if (Input.GetButton("Scale10")) // shift
        {
            times = 10;
        }
        else if (Input.GetButton("Scale100"))
        { // ctrl
            times = 100;
        }
        else if (Input.GetButton("ScaleMAX")) {
            // left alt
            times = 1000000; // just a large number that probably can't be taken upgraded in 1 go, but maybe.
        }

        if (type == "Money")
        {
                moneyLevels[upgrade].Upgrade(times);
        }
        else if (type == "ClickPower")
        {
            clickPowerLevels[upgrade].Upgrade(times); 
        }
        else if (type == "Cap") {
            capLevels[upgrade].Upgrade(times);
        }

        else if (type == "AutoClick")
        {
            times = 1;
            autoClickLevels[upgrade].Upgrade(times);
        }
    }

    public static string getCostString(string type, int upgrade) {
        if (type == "Money") {
            return "" + (int)moneyLevels[upgrade].getCost();
        }
        else if (type == "ClickPower")
        {
            return "" + (int)clickPowerLevels[upgrade].getCost();
        }
        else if (type == "Cap")
        {
            return "" + (int)capLevels[upgrade].getCost();
        }
        else if (type == "AutoClick")
        {
            if (autoClickLevels[upgrade].getLevel() != 0) {
                return "MAXED";
            }
            return "" + (int)autoClickLevels[upgrade].getCost();
        }
        return "none";
    }

    public static string getLevelString(string type, int upgrade)
    {
        if (type == "Money")
        {
            return "" + (int)moneyLevels[upgrade].getLevel();
        }
        else if (type == "ClickPower")
        {
            return "" + (int)clickPowerLevels[upgrade].getLevel();
        }
        else if (type == "Cap")
        {
            return "" + (int)capLevels[upgrade].getLevel();
        }
        else if (type == "AutoClick")
        {
            return "" + (int)autoClickLevels[upgrade].getLevel();
        }
        return "none";
    }
}

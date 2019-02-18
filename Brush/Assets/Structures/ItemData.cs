using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData {
    private string type;
    private int upgrade, level;
    private float growth;
    private double cost;


    public ItemData(string input_type, int input_upgrade, int input_level, float input_cost, float input_growth) {
        type = input_type; // 0 is click, 1 is cap, 2 is money upgrade
        upgrade = input_upgrade;
        level = input_level;
        cost = input_cost;
        growth = input_growth;
    }
    
    public double Behaviour() {
        double money_scale = 2 + upgrade;
        double click_power_scale = 2 + upgrade;
        double cap_scale = 2 + upgrade;
        // everything is slightly more effective depending on its tier.
        // this function is purely for returning, based on the specific type and upgrade, the effectiveness of said thing
        if (type == "Money")
        {
            // MPS, returns the level * scale * the effectiveness based on upgrade tier.
            // basically the output of it.
            return level * money_scale * Mathf.Pow(playerShop.moneyExponent, upgrade);
        }
        else if (type == "Cap")
        {
            // Cap returns the level * scale * the effectiveness based on upgrade tier.
            // basically the output of it.
            return level * cap_scale * Mathf.Pow(playerShop.capExponent, upgrade);
        }
        else if (type == "ClickPower")
        {
            // Click returns the level * scale * the effectiveness based on upgrade tier.
            // basically the output of it.
            return level * click_power_scale * Mathf.Pow(playerShop.clickPowerExponent, upgrade);
        }
        else if (type == "AutoClick") {
            // This is actually special, returns 1 if the level > 1, otherwise returns 0. This is because it's only upgradable ONCE.
            if (level > 0) return 1;
            return 0;
        }
        return -1;
    }
    private bool canUpgrade(double money)
    {
        if (money < cost) return false;
        return true;
    }
    public void Upgrade(int times) { // times is the number of times u upgrade it. 

        for (int i = 0; i < times; i++) {
            if (canUpgrade(PlayerStats.money))
            {
                PlayerStats.money -= cost;
                cost *= growth;
                level++;
            }
            else break;
            
        }
        // Debug.Log("I just upgraded this: " + type);
    }

    public string getType(){
        return type;
    }
    public int getUpgrade() {
        return upgrade;
    }
    public double getCost()
    {
        return cost;
    }
    public float getGrowth()
    {
        return growth;
    }
    public int getLevel()
    {
        return level;
    }

    public void setType(string t)
    {
        type = t;
    }
    public void setUpgrade(int t)
    {
        upgrade = t;
    }
    public void setCost(double t)
    {
        cost = t;
    }
    public void setGrowth(float t)
    {
        growth = t;
    }
    public void setLevel(int t)
    {
        level = t;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text gameText;
    public Text capText;
    public Text moneyText;
    public Text MPS;
    public Text percentText;
    public Text clickStrengthText;
    public Text DangerText;
    public Text autoClickText;
    
    public double bac_rate; 
    public static double curBac;
    public static double maxBac; // the cap
    public static double money; 
    public static double money_rate; // rate of money
    public static double clickPower; // click power
    public static double autoClick; // auto click frequency
    
    public static double percent;
    public double bac_rate_increase_time;
    private double delay_between_increase;

    private double auto_click_delay = 1f;
    private double auto_click_time;

    public Slider percentLost;

    void Start()
    {
        auto_click_time = 0f;
        autoClick = 0f;
        money = 0f; 
        curBac = 0f;
        maxBac = 100;
        money_rate = 1;
        clickPower = 1;
        percent = 0;
        updateStats();
        delay_between_increase = 0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        // every second remove some bacteria, also accoutn for autoclick
        auto_click_time += Time.deltaTime * autoClick;
        if (auto_click_time >= auto_click_delay) {
            auto_click_time = 0;
            curBac -= clickPower;
        }

        if (curBac < 0) curBac = 0;
        percent = curBac / maxBac;
        curBac += bac_rate * Time.deltaTime; // times delta t

        if (percent > 1) percent = 1; // Even though we can go over the cap, we calculate that as 100% of total.
        
        money += money_rate * (1 - percent) * Time.deltaTime; // rate *= (cur / max), basically as bac goes up money rate goes down
        // times delta t

        delay_between_increase += Time.deltaTime;

        if (delay_between_increase >= bac_rate_increase_time) {
            delay_between_increase = 0f;
            bac_rate *= 2f;
        }

        money_rate = 1 + playerShop.collectiveSum("Money");
        clickPower = 1 + playerShop.collectiveSum("ClickPower");
        maxBac = 100 + playerShop.collectiveSum("Cap");
        autoClick = playerShop.collectiveSum("AutoClick");
        updateStats();
    }

    void updateMoney(int rate) {
        
    }

    void updateStats() {
        gameText.text = "Bacteria  " + (int)curBac;
        capText.text = "Loss Cap  " + maxBac;
        moneyText.text = "Money  " + (int)money;
        MPS.text = "Money per second  " + (int)money_rate;
        percentText.text = "Loss Percent  " + (int)(percent * 100) + "%";
        clickStrengthText.text = "Click Power  " + (int)clickPower;
        autoClickText.text = "Clicks per second  " + (int)autoClick;
        percentLost.value = (float)percent;
        if (percent != 1)
        {
            DangerText.gameObject.SetActive(false);
        }
        else {
            DangerText.gameObject.SetActive(true);
        }
    }
}

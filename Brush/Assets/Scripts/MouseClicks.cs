using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicks : MonoBehaviour
{
    public void PlayerCleansTeeth() {
        // remove some bacteria
        if (PlayerStats.curBac >= 1)
        {
            PlayerStats.curBac -= PlayerStats.clickPower;
            PlayerStats.money++;
        }
    }
}

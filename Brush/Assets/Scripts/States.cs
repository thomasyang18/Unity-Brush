using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class States : MonoBehaviour
{
    public Image good;
    public Image bad;
    public Image ok;
    void Start()
    {
        bad.gameObject.SetActive(false);
        ok.gameObject.SetActive(false);
        good.gameObject.SetActive(true);
    }

    void Update()
    {
        double percent = PlayerStats.percent * 100;

        if (percent < 33)
        {
            // good state
            bad.gameObject.SetActive(false);
            ok.gameObject.SetActive(false);
            good.gameObject.SetActive(true);
        }
        else if (percent >= 33 && percent < 66)
        {
            // meh state
            bad.gameObject.SetActive(false);
            ok.gameObject.SetActive(true);
            good.gameObject.SetActive(false);

        }
        else {
            // bad state
            bad.gameObject.SetActive(true);
            ok.gameObject.SetActive(false);
            good.gameObject.SetActive(false);
        }
    }
}

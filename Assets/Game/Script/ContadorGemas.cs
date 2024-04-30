using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorGemas : MonoBehaviour
{
    public TextMeshProUGUI gemasCount;
    public string gemasTag = "Gemas";
    private void Start()
    {
        GetTotalGems();
    }
    void Update()
    {
        UpdateGemsCountText();
    }

    public void UpdateGemsCountText()
    {
        GameObject[] gema = GameObject.FindGameObjectsWithTag(gemasTag);
        int TotalGems = gema.Length;
        if (TotalGems > 0)
        {
            gemasCount.text = "Gems Remains: " + TotalGems;
        }
        else { gemasCount.text = "All Gems Collected!"; }
    }
    public int GetTotalGems()
    {
        GameObject[] gemas = GameObject.FindGameObjectsWithTag(gemasTag);
        return gemas.Length;
    }

}

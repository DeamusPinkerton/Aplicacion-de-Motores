using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int FrootCoin;
    public TMP_Text FrootUI;
    public ShopItemsSO[] ShopItemsSO;
    public GameObject[] ShopPanelsGO;
    public ShopTemplate[] ShopPanels;
    public Button[] PurshadeBtns;

    private void Start()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanelsGO[i].SetActive(true);
        }
        FrootUI.text = PlayerPrefs.GetString("FrootLoops");
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddFroot()
    {
        FrootCoin++;
        FrootUI.text = FrootCoin.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            if (FrootCoin >= ShopItemsSO[i].BaseCost)
            {
                PurshadeBtns[i].interactable = true;
            }
            else
            {
                PurshadeBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNO)
    {
        if (FrootCoin >= ShopItemsSO[btnNO].BaseCost)
        {
            FrootCoin = FrootCoin - ShopItemsSO[btnNO].BaseCost;
            FrootUI.text = FrootCoin.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < ShopItemsSO.Length; i++)
        {
            ShopPanels[i].TitleText.text = ShopItemsSO[i].Title;
            ShopPanels[i].DesciptionTxt.text = ShopItemsSO[i].Description;
            ShopPanels[i].CostTxt.text = ShopItemsSO[i].BaseCost.ToString();
        }
    }
}

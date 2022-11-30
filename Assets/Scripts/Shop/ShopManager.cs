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
        FrootCoin = PlayerPrefs.GetInt("FrootLoops");
        FrootUI.text = FrootCoin.ToString();
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
            PlayerPrefs.SetInt("FrootLoops", FrootCoin);
            CheckPurchaseable();
            if (btnNO == 0)
            {
                if (PlayerPrefs.GetInt("currentStamina") < PlayerPrefs.GetInt("MaxStamina"))
                {
                    PlayerPrefs.SetInt("currentStamina", PlayerPrefs.GetInt("MaxStamina"));
                }
                else
                {
                    Debug.Log("Stamina is already full!");
                    FrootCoin = FrootCoin + ShopItemsSO[btnNO].BaseCost;
                }
            }
            else if (btnNO == 1)
            {
                PlayerPrefs.SetInt("MaxStamina", (PlayerPrefs.GetInt("MaxStamina") + 1));
            }
            else if (btnNO == 2)
            {
                if (PlayerPrefs.GetInt("CosmicKnife") == 0)
                {
                    PlayerPrefs.SetInt("CosmicKnife", 2);
                }
                else
                {
                    Debug.Log("You already own this item!");
                    FrootCoin = FrootCoin + ShopItemsSO[btnNO].BaseCost;
                }

            }
            PlayerPrefs.SetInt("FrootLoops", FrootCoin);
            FrootUI.text = FrootCoin.ToString();
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

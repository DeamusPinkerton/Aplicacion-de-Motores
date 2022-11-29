using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopMenu", menuName ="Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemsSO : ScriptableObject
{
    public string Title;
    public string Description;
    public int BaseCost;
    //public Texture2D Item;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] popUps;
    public int popUpIndex;
    public bool fruitdestroy = true;
    public bool rottendestroy = true;
    public bool bombdestroy = true;

    public GameObject fruit;
    public GameObject rotten;
    public GameObject bomb;

    public float waitTime = 2f;
    public float waitTimeindex = 2f;

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (waitTime <= 0)
            {
                fruit.SetActive(true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            if (fruitdestroy == false)
            {
                waitTime = waitTimeindex;
                fruitdestroy = true;
                popUpIndex++;

            }
        }
        else if (popUpIndex == 2)
        {
            if (waitTime <= 0)
            {
                rotten.SetActive(true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            if (rottendestroy == false)
            {
                waitTime = waitTimeindex;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (waitTime <= 0)
            {
                bomb.SetActive(true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            if (bombdestroy == false)
            {
                waitTime = waitTimeindex;
                popUpIndex ++;

            }
        }
    }

    public void fruitcheck()
    {
        fruitdestroy = false;
    }
    public void rottencheck()
    {
        rottendestroy = false;
    }
    public void bombtcheck()
    {
        bombdestroy = false;
    }
}

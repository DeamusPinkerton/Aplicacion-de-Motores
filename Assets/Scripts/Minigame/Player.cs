using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Controller Joycontroller;
    [SerializeField] float speed = 5;

    public int lifes;

    public float jumpSpeed = 3f;
    public float jumpDelay = 2f;

    private bool canjump;
    private bool isjumping;
    private Rigidbody rb;
    private float countDown;

    public TextMeshProUGUI Life;

    private void Start()
    {
        canjump = true;
        rb = GetComponent<Rigidbody>();
        countDown = jumpDelay;
        Life.text = "x" + lifes.ToString();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Hago click");
    }

    private void Update()
    {
        transform.position += Joycontroller.GetMovementInput() * Time.deltaTime * speed;
        if (isjumping && countDown > 0)
            countDown -= Time.deltaTime;
        else
        {
            canjump = true;
            isjumping = false;
            countDown = jumpDelay;
        }
    }
    public void OnJumpButtonClick()
    {
        if (canjump)
        {
            canjump = false;
            isjumping = true;
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Void") || other.CompareTag("trap"))
        {
            if (lifes > 1)
            {
                lifes -= 1;
                Life.text = "x" + lifes.ToString();
            }
            else
            {
                    rb = GetComponent<Rigidbody>();
                    rb.freezeRotation = true;
                    FindObjectOfType<MinigameManager>().Lose();
            }
        }
    }

}

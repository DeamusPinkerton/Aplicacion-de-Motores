using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerJS : Controller, IDragHandler, IEndDragHandler
{
    Vector3 moveDirection;
    Vector3 inposition;
    [SerializeField] float maxMagnitude = 100;

    private void Start()
    {
        inposition = transform.position;
    }

    public override Vector3 GetMovementInput()
    {
        Vector3 moveDirModified = new Vector3(moveDirection.x, 0, moveDirection.y) / maxMagnitude;
        return moveDirModified;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveDirection = Vector3.ClampMagnitude((Vector3)eventData.position - inposition, maxMagnitude);
        transform.position = inposition + moveDirection;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = inposition;
        moveDirection = Vector3.zero;
    }
}

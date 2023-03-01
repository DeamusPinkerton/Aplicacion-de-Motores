using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : Controller, IDragHandler, IEndDragHandler
{
    Vector3 moveDir;
    Vector3 initPosition;
    [SerializeField] float maxMagnitude = 100;

    private void Start()
    {
        initPosition = transform.position;
    }

    public override Vector3 GetMovementInput()
    {
        Vector3 moveDirModified = new Vector3(moveDir.x, 0, moveDir.y);
        moveDirModified = moveDirModified / maxMagnitude;
        return moveDirModified;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - initPosition, maxMagnitude);

        transform.position = initPosition + moveDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initPosition;
        moveDir = Vector3.zero;
    }
}

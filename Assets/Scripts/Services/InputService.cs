using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public bool canClick;

    public Action<GameObject> onLeftMouseButtonClick;
    private Vector3 mouseWorldPos =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    public void Init()
    {
        canClick = true;
        clickedObject = null;
        Debug.Log("InputService初始化完成！");
    }

    public void CanClick()
    {
        canClick = true;
    }

    public void CantClick()
    {
        canClick = false;
    }

    private Collider2D clickedObject;
    public void Trick()
    {
        clickedObject = ObjectAtMouseDown();
        if (canClick && Input.GetMouseButtonDown(0) && clickedObject != null)
        {
            onLeftMouseButtonClick?.Invoke(clickedObject.gameObject);
        }
    }

    public Collider2D ObjectAtMouseDown()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}

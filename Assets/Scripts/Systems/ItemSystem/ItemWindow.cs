using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ItemWindow : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Text toolName;
    public Image itemSprite;

    private ItemSystem itemSystem;
    private CanvasGroup _canvasGroup;

    public void Init(ItemSystem item)
    {
        // 变量赋值——本项目中拖拽赋值
        itemSystem = item;
        _canvasGroup = GetComponent<CanvasGroup>();
        // 设置初始化状态
        leftButton.onClick.AddListener(OnLeftButtonDown);
        leftButton.onClick.AddListener(OnRightButtonDown);
    }

    public void Open()
    {
        // 打开窗体函数
    }

    public void Hide()
    {
        //关闭窗体函数
    }

    public void Destroy()
    {
        // 变量取消赋值
        
        leftButton.onClick.RemoveAllListeners();
    }

    public void SetWindowState(Item item, bool left, bool right)
    {
        if (item == null)
        {
            _canvasGroup.alpha = 0;
        }
        else
        {
            _canvasGroup.alpha = 1;
            leftButton.interactable = left;
            rightButton.interactable = right;
            toolName.text = item.itemName;
            itemSprite.sprite = item.itemUISprite;
        }
    }

    private void OnLeftButtonDown()
    {
        
    }

    private void OnRightButtonDown()
    {
        
    }
}

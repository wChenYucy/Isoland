using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : BaseSystem
{
    private Item clickedItem;

    public ItemWindow itemWindow;

    private List<Item> items;
    private int currentIndex;
    private int itemCounts;

    public override void Init(ResService resService = null, AudioService audioService = null, InputService inputService = null)
    {
        base.Init(resService, audioService, inputService);
        clickedItem = null;
        //itemWindow 拖拽赋值
        items = new List<Item>();
        currentIndex = -1;
        itemCounts = 0;
        itemWindow.Init(this);
        itemWindow.Open();
        itemWindow.SetWindowState(null, false, false);
        Debug.Log("Item System 初始化完成！");
    }

    public void Enable()
    {
        inputService.onLeftMouseButtonClick += IsItemClick;
    }

    public void Disable()
    {
        inputService.onLeftMouseButtonClick -= IsItemClick;
    }

    public void Destroy()
    {
        
    }

    private void IsItemClick(GameObject gameObject)
    {
        if (gameObject.CompareTag("Item"))
        {
            clickedItem = gameObject.GetComponent<Item>();
            if (!items.Contains(clickedItem))
            {
                items.Add(clickedItem);
                currentIndex++;
                itemWindow.SetWindowState(items[currentIndex], currentIndex > 0, currentIndex < itemCounts - 1);
                Destroy(gameObject);
            }
        }
    }
    
}

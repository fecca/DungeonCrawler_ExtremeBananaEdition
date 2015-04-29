using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TooltipManager : Singleton<TooltipManager>
{
    [SerializeField]
    private GameObject tooltip = null;
    [SerializeField]
    private Text text = null;

    public void ShowTooltip(InventoryItem inventoryItem)
    {
        /// ToDo: mess + keep tooltip within screen borders
        text.text = inventoryItem.Item.Description;
        tooltip.transform.position = inventoryItem.transform.position + new Vector3(0, 37, 0);
        //tooltip.SetActive(true);
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }
}
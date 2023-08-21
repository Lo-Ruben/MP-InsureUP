using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSingleton : GenericSingleton<TooltipSingleton>
{
    public Tooltip tooltip;
    public static void ShowTooltip(string content, string header= "")
    {
        Debug.Log("Show ToolTip");
        instance.tooltip.SetText(content, header);
        instance.tooltip.gameObject.SetActive(true);
    }
    public static void HideTooltip()
    {
        Debug.Log("Hide ToolTip");
        instance.tooltip.gameObject.SetActive(false);
    }
}

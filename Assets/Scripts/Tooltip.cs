using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltipText;
    private Tooltip tooltip;



    // Start is called before the first frame update
    void Start()
    {
        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        tooltipText = GetComponentInChildren<Text>();
        tooltipText.gameObject.SetActive(false);
        tooltip.gameObject.SetActive(false);

    }

    public void GenerateTooltip(Item item)
    {
        string statText = "";
        if (item.stats.Count > 0)
        {
            foreach (var stat in item.stats)
            {
                statText += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string tooltipT = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>",
                                item.title, item.description, statText);
        tooltipText.text = tooltipT;
        tooltip.gameObject.SetActive(true);
        tooltipText.gameObject.SetActive(true);
    }

}


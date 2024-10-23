using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTreeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] SkillTreePath skillTreePath;
    //[SerializeField] Ability ability;
    Color hoverColor;
    Color idleColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        skillTreePath.SetPathColor(hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skillTreePath.SetPathColor(idleColor);
    }

    public void SetColorsForPaths(Color hoverColor, Color idleColor)
    {
        this.hoverColor = hoverColor;
        this.idleColor = idleColor;
    }

    
}

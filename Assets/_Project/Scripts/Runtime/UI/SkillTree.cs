using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTree : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] List<SkillTreeSlot> skillTreeSlots;
    [SerializeField] float sensitivity;
    [SerializeField] Color pathHoverColor;
    [SerializeField]Color pathIdleColor;
    Vector3 originMousePos;
    Vector3 originImagePos;

    public void OnPointerDown(PointerEventData eventData)
    {
        originMousePos = Input.mousePosition;
        originImagePos = transform.localPosition;
    }

    void Start() 
    {
        foreach(SkillTreeSlot skillTreeSlot in skillTreeSlots)
        {
            skillTreeSlot.SetColorsForPaths(pathHoverColor,pathIdleColor);
        }
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            transform.localPosition = originImagePos + (Input.mousePosition - originMousePos) * sensitivity;
        }
    }
}

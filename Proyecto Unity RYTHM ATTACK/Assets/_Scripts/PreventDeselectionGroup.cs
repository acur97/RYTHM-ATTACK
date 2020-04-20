using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreventDeselectionGroup : MonoBehaviour
{
    private EventSystem evt;
    private GameObject sel;

    private void Awake()
    {
        evt = GetComponent<EventSystem>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (evt.currentSelectedGameObject != null && evt.currentSelectedGameObject != sel)
        {
            sel = evt.currentSelectedGameObject;
        }
        else if (sel != null && evt.currentSelectedGameObject == null)
        {
            evt.SetSelectedGameObject(sel);
        }
    }

    public void SelectItem(GameObject item)
    {
        evt.SetSelectedGameObject(item);
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public bool isClick = false;
    Vector2 origin, buttonDis;
    RectTransform myTransform, paTransform;

    public float Degree;

    public GameObject TargetObject = null;
    public string Message;

    void Start()
    {
        myTransform = GetComponent<RectTransform>();
        paTransform = transform.parent.GetComponent<RectTransform>();
        origin = myTransform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isClick)
        {
            buttonDis = eventData.position - origin;
            isClick = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = origin;
        isClick = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        myTransform.position = eventData.position - buttonDis;

        Vector2 dir = (Vector2)myTransform.position - origin;
        Degree = (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 360f) % 360f;

        float dist = Vector3.Distance(myTransform.position, paTransform.position);
        if (dist > 100f) myTransform.position = paTransform.position + (myTransform.position - paTransform.position).normalized * 100f;

        if (TargetObject != null) TargetObject.SendMessage(Message, Degree);
    }
}

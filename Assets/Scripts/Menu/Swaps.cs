using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaps : MonoBehaviour
{
    public RectTransform rectTransform;

    public float totalPages = 2, currentPage = 1, deltaPos = 750, targetPos, deltaMousePos = 150;

    public Vector3 mouseStartPos;

    public bool canSwap = false;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //rectTransform.localPosition = new Vector3(-230, rectTransform.localPosition.y, rectTransform.localPosition.z);
        //targetPos = rectTransform.localPosition.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            canSwap = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            canSwap = true;
            mouseStartPos = Input.mousePosition;
        }

        if (mouseStartPos.x - Input.mousePosition.x >= deltaMousePos && canSwap && currentPage < totalPages)
        {
            currentPage++;
            targetPos -= deltaPos;
            canSwap = false;
        }

        if (mouseStartPos.x - Input.mousePosition.x <= -deltaMousePos && canSwap && currentPage > 1)
        {
            currentPage--;
            targetPos += deltaPos;
            canSwap = false;
        }

        Vector3 newPos = rectTransform.localPosition;

        newPos.x = Mathf.Lerp(newPos.x, targetPos, Time.deltaTime * 3);

        rectTransform.localPosition = newPos;
    }
}

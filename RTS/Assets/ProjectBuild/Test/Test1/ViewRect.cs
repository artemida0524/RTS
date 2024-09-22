using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewRect : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private GameObject game;

    private Vector2 startPosition = Vector2.zero;
    private Vector2 endPosition = Vector2.zero;

    [SerializeField] private List<Unit> units;

    private void Update()
    {
        if (image != null)
        {
            foreach (var unit in units)
            {
                unit.sphere.SetActive(false);
            }
            if (Input.GetMouseButtonDown(1))
            {
                image.enabled = true;
                startPosition = Input.mousePosition;
                rectTransform.anchoredPosition = startPosition;

            }
            if (Input.GetMouseButton(1))
            {
                endPosition = Input.mousePosition;

                Vector2 vector2 = endPosition - startPosition;

                rectTransform.sizeDelta = vector2;

                
                Rect rect = new Rect(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);

                foreach (var unit in units)
                {
                    Debug.Log("fwefwef");
                    unit.vector2 = Camera.main.WorldToScreenPoint(unit.transform.position);

                    if (rect.Contains(unit.vector2))
                    {
                        Debug.Log("fewfwef");
                        unit.sphere.SetActive(true);
                    }
                }


                
                
            }
            if (Input.GetMouseButtonUp(1))
            {
                image.enabled = false;
            }




        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rectTransform;


    private Vector2 startPosition = Vector2.zero;
    private Vector2 endPosition = Vector2.zero;


    private List<UnitBase> selectedUnits;

    private void Update()
    {
        if (image != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                image.enabled = true;
                startPosition = Input.mousePosition;
                rectTransform.anchoredPosition = startPosition;

            }
            if (Input.GetMouseButton(0))
            {

                foreach (var unit in UnitsData.Instance.AllUnits)
                {
                    unit.UnSelect();
                }

                selectedUnits = new List<UnitBase>();
                endPosition = Input.mousePosition;

                Vector2 vector2 = endPosition - startPosition;

                rectTransform.sizeDelta = vector2;

                
                Rect rect = new Rect(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);

                foreach (var unit in UnitsData.Instance.AllUnits)
                {
                    if (rect.Contains(unit.GetScreenPosition()))
                    {
                        selectedUnits.Add(unit);
                        unit.Select();
                    }
                }


                
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                image.enabled = false;

                UnitsData.Instance.AddRangeSelectedUnits(selectedUnits);

            }




        }
    }

}

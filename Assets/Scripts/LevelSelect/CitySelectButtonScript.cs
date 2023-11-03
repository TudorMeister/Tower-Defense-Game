using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitySelectButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panelHolder;
    public GameObject detailsPanePrefab;

    public TextMeshProUGUI CityName;
    public TextMeshProUGUI LevelDetails;

    private GameObject _detailsPane;
    private RectTransform _detailsPaneRectTransform;

    public GameObject GetDetailsPane(){
        if (_detailsPane == null) {
            _detailsPane = Instantiate(detailsPanePrefab, panelHolder.transform);
            _detailsPane.name = "CityDetailsPane (" + CityName.text + ")";
            _detailsPane.transform.SetAsLastSibling();
            _detailsPaneRectTransform = _detailsPane.GetComponent<RectTransform>();

        }

        return _detailsPane;
    }

    public void OnClick(){
        panelHolder.GetComponent<LevelSelectMapGenerator>().LevelPopUpSection.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject detailsPane = GetDetailsPane();
        detailsPane.SetActive(true);
        Debug.Log("A intrat "+CityName.text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject detailsPane = GetDetailsPane();
        detailsPane.SetActive(false);
        Debug.Log("A iesit "+CityName.text);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_detailsPane != null && _detailsPane.activeSelf)
        {
            float multiplicationConstant = 2.1f;

            float finalX = Input.mousePosition.x + 10f;
            float finalY = Input.mousePosition.y + 10f;

            RectTransform panelRect = panelHolder.GetComponent<RectTransform>();
            if (finalX + _detailsPaneRectTransform.rect.width >= panelRect.rect.width)
                finalX -= _detailsPaneRectTransform.rect.width * multiplicationConstant;

            if (finalY + _detailsPaneRectTransform.rect.height >= panelRect.rect.height)
                finalY -= _detailsPaneRectTransform.rect.height * multiplicationConstant;

            _detailsPane.transform.position = new Vector3(finalX, finalY, 0f);
        }
    }
}

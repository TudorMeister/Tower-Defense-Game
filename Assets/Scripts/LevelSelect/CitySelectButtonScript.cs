
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitySelectButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LevelSelectMapGenerator MapLevelSelectPanel;
    public GameObject DetailsPanelPrefab;


    public TextMeshProUGUI CityName;
    public TextMeshProUGUI LevelDetails;

    public CityDetailsPanelScript GetDetailsPanel(){
        if (_detailsPanelInstance == null) {
            _detailsPanelInstance = Instantiate(DetailsPanelPrefab, MapLevelSelectPanel.transform).GetComponent<CityDetailsPanelScript>();
            _detailsPanelInstance.name = "CityDetailsPane (" + CityName.text + ")";
            _detailsPanelInstance.transform.SetAsLastSibling();

            _detailsPanelRectTransform = _detailsPanelInstance.GetComponent<RectTransform>();

        }

        return _detailsPanelInstance;
    }

    public void OnClick(){
        MapLevelSelectPanel.LevelPopUpSection.InitializeAndOpen();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CityDetailsPanelScript detailsPanel = GetDetailsPanel();
        detailsPanel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CityDetailsPanelScript detailsPanel = GetDetailsPanel();
        detailsPanel.gameObject.SetActive(false);
    }

    private CityDetailsPanelScript _detailsPanelInstance;
    private RectTransform _detailsPanelRectTransform;
    private RectTransform _mapLevelSelectPanelRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _mapLevelSelectPanelRectTransform = MapLevelSelectPanel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_detailsPanelInstance != null && _detailsPanelInstance.gameObject.activeSelf)
        {
            // +10f for a bit of offset from the actual cursor position
            float finalX = Input.mousePosition.x + 40f;
            float finalY = Input.mousePosition.y + 40f;

            Vector3[] cornersDetailsPanel = new Vector3[4];
            _detailsPanelRectTransform.GetWorldCorners(cornersDetailsPanel);

            Vector3[] cornersMapPanel = new Vector3[4];
            _mapLevelSelectPanelRectTransform.GetWorldCorners(cornersMapPanel);

            float detailsWidth = Mathf.Abs(cornersDetailsPanel[2].x - cornersDetailsPanel[0].x);
            float detailsHeight = Mathf.Abs(cornersDetailsPanel[2].y - cornersDetailsPanel[0].y);
            float mapWidth = Mathf.Abs(cornersMapPanel[2].x - cornersMapPanel[0].x);
            float mapHeight = Mathf.Abs(cornersMapPanel[2].y - cornersMapPanel[0].y);

            if (finalX + detailsWidth >= mapWidth)
                finalX -= detailsWidth + 80f;

            if (finalY + detailsHeight >= mapHeight)
                finalY -= detailsHeight + 80f;

            _detailsPanelRectTransform.position = new Vector3(finalX, finalY, 0f);
        }
    }
}

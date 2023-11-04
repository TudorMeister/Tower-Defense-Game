
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
            //only god knows why this constant is required
            //but it just won't display corectly otherwise
            float multiplicationConstant = 2.1f;

            // +10f for a bit of offset from the actual cursor position
            float finalX = Input.mousePosition.x + 10f;
            float finalY = Input.mousePosition.y + 10f;

            if (finalX + _detailsPanelRectTransform.rect.width >= _mapLevelSelectPanelRectTransform.rect.width)
                finalX -= _detailsPanelRectTransform.rect.width * multiplicationConstant;

            if (finalY + _detailsPanelRectTransform.rect.height >= _mapLevelSelectPanelRectTransform.rect.height)
                finalY -= _detailsPanelRectTransform.rect.height * multiplicationConstant;

            _detailsPanelInstance.transform.position = new Vector3(finalX, finalY, 0f);
        }
    }
}

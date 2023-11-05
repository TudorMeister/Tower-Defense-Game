
using System.Collections.Generic;
using UnityEngine;

public class LevelFromCitySelect : MonoBehaviour
{

    public GameObject LevelButtonItemPrefab;
    public GameObject ContentContainer;

    private List<GameObject> levelButtons = new();

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void InitializeAndOpen(){
        levelButtons.Add(GenerateButton());
        gameObject.SetActive(true);
    }

    private GameObject GenerateButton(){
        GameObject toReturn = Instantiate(LevelButtonItemPrefab, ContentContainer.transform);
        return toReturn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

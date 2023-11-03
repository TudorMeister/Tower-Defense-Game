using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectMapGenerator : MonoBehaviour
{

    public GameObject LevelPopUpSection;

    //public GameObject detailsPanePrefab;

    // public GameObject buttonPrefab; // Reference to your button prefab
    // public int numberOfButtons = 5; // Number of buttons to generate
    // public float buttonSpacing = 50f; // Spacing between buttons

    // Start is called before the first frame update
    void Start()
    {
        // GenerateButtons2();
    }

    // void GenerateButtons()
    // {
    //     for (int i = 0; i < numberOfButtons; i++)
    //     {
    //         GameObject button = Instantiate(buttonPrefab, transform);
    //         button.transform.SetParent(transform, false);
            
    //         button.GetComponentInChildren<TextMeshProUGUI>().text = "Button " + (i + 1);
            
    //         // You can add more customization to the button here if needed.
    //     }

        
    // }

    // void GenerateButtons2()
    // {
    //     for (int i = 0; i < numberOfButtons; i++)
    //     {
    //         GameObject button = Instantiate(buttonPrefab, transform);
    //         button.transform.SetParent(transform, false);
    //         TMP_Text buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
    //         if (buttonText != null)
    //         {
    //             buttonText.text = "Button " + (i + 1);
    //         }
    //         // Adjust the y-position of each button
    //         button.transform.localPosition = new Vector3(0, -i * buttonSpacing, 0);
    //         // You can add more customization to the button here if needed.
    //     }
    // }
}

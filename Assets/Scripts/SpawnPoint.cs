using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject hologramPrefab;
    private TextMeshPro _textMeshProComponent;
    private GameObject _spawnedHologram;

    void Start()
    {

        _spawnedHologram = Instantiate(hologramPrefab, new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z), Quaternion.identity);
        _textMeshProComponent = _spawnedHologram.GetComponentInChildren<TextMeshPro>();
        SetHologramVisibility(false);
    }

    // Function to change the content of the hologram
    public void SetHologramContent(string content)
    {
        if (_textMeshProComponent == null)
            return;

        _textMeshProComponent.text = content;
    }

    // Function to set the visibility of the hologram
    public void SetHologramVisibility(bool isVisible)
    {
        if (_spawnedHologram != null)
        {
            _spawnedHologram.SetActive(isVisible);
        }
    }
}

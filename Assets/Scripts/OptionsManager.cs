using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Dropdown keysDropdown;
    public Button confirmButton;
    public InputField[] keyInputs;
    public GameObject inputFieldsContainer;

    void Start()
    {
        confirmButton.onClick.AddListener(ShowKeyInputs);
        HideAllKeyInputs();
    }

    private void ShowKeyInputs()
    {
        HideAllKeyInputs();
        int keys = keysDropdown.value + 2;
        for (int i = 0; i < keys; i++)
        {
            keyInputs[i].gameObject.SetActive(true);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(inputFieldsContainer.GetComponent<RectTransform>());
    }

    private void HideAllKeyInputs()
    {
        foreach (InputField inputField in keyInputs)
        {
            inputField.gameObject.SetActive(false);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(inputFieldsContainer.GetComponent<RectTransform>());
    }

    public void SaveOptions()
    {
        int keys = keysDropdown.value + 2;
        PlayerPrefs.SetInt("KeyCount", keys);
        for (int i = 0; i < keys; i++)
        {
            PlayerPrefs.SetString("Key" + i, keyInputs[i].text);
        }
        PlayerPrefs.Save();
    }
}

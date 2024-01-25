using UnityEngine;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour
{
    public Button HelpButton;
    public Button CloseButton;
    public GameObject HelpPanel;

    void Start()
    {
        HelpButton.onClick.AddListener(OnClickHelpButton);
        CloseButton.onClick.AddListener(OnClickCloseButton);

        HelpPanel.SetActive(true);
    }

    public void OnClickCloseButton()
    {
        HelpPanel.SetActive(false);
    }

    public void OnClickHelpButton()
    {
        HelpPanel.SetActive(!HelpPanel.activeInHierarchy);
    }
}

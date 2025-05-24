using UnityEngine;

public class OpenLinkScript : MonoBehaviour
{
    public GameObject popUpPanel;
    public GameObject popUpPanelSensori2;
    public GameObject popUpPanelSensori3;
    public GameObject popUpPanelSensori4;
    public GameObject popUpPanelSensori5;
    public GameObject popUpPanelSensori6;
    public GameObject orariPanel;
    public void OpenWebsite()
    {
        string url = "http://iot-eco.ubt-uni.net/temperature"; 
        Application.OpenURL(url);
    }

    public void OpenWebsiteSensori2()
    {
        string url = "http://iot-eco.ubt-uni.net/humidity";
        Application.OpenURL(url);
    }
    public void OpenWebsiteSensori3()
    {
        string url = "http://iot-eco.ubt-uni.net/luminosity";
        Application.OpenURL(url);
    }
    public void OpenWebsiteSensori4()
    {
        string url = "http://iot-eco.ubt-uni.net/range";
        Application.OpenURL(url);
    }
    public void OpenWebsiteSensori5()
    {
        string url = "http://iot-eco.ubt-uni.net/pressure";
        Application.OpenURL(url);
    }
    public void OpenWebsiteSensori6()
    {
        string url = "http://iot-eco.ubt-uni.net/concentration";
        Application.OpenURL(url);
    }

    public void OpenOrariWebsite()
    {
        string url = "https://branch.ubt-uni.net/TV/ScheduleIndex.aspx";
        Application.OpenURL(url);
    }
    public void HidePanel()
    {
        popUpPanel.SetActive(false);
    }
    public void HidePanelSensori2()
    {
        popUpPanelSensori2.SetActive(false);
    }
    public void HidePanelSensori3()
    {
        popUpPanelSensori3.SetActive(false);
    }
    public void HidePanelSensori4()
    {
        popUpPanelSensori4.SetActive(false);
    }
    public void HidePanelSensori5()
    {
        popUpPanelSensori5.SetActive(false);
    }
    public void HidePanelSensori6()
    {
        popUpPanelSensori6.SetActive(false);
    }

    public void HideOrariPanel()
    {
        orariPanel.SetActive(false);
    }
}

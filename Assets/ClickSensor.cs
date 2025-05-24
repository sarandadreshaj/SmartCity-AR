using UnityEngine;
using UnityEngine.UI;

public class SensorClickHandler : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject orariCanvas;
    public GameObject sensori2Canvas;
    public GameObject sensori3Canvas;
    public GameObject sensori4Canvas;
    public GameObject sensori5Canvas;
    public GameObject sensori6Canvas;

    void Update()
    {
        // Check if there's a touch or click
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began ||
            Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "orari")
                {
                    ShowOrariCanvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori1")
                {
                    ShowPopupCanvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori2")
                {
                    ShowSensori2Canvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori3")
                {
                    ShowSensori3Canvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori4")
                {
                    ShowSensori4Canvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori5")
                {
                    ShowSensori5Canvas();
                }
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "sensori6")
                {
                    ShowSensori6Canvas();
                }
            }
        }
    }

    void ShowOrariCanvas()
    {
        orariCanvas.SetActive(true);
    }
    void ShowPopupCanvas()
    {
        popupCanvas.SetActive(true);
    }
    void ShowSensori2Canvas()
    {
        sensori2Canvas.SetActive(true);
    }
    void ShowSensori3Canvas()
    {
        sensori3Canvas.SetActive(true);
    }
    void ShowSensori4Canvas()
    {
        sensori4Canvas.SetActive(true);
    }
    void ShowSensori5Canvas()
    {
        sensori5Canvas.SetActive(true);
    }
    void ShowSensori6Canvas()
    {
        sensori6Canvas.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;
    private GameObject navTargetObject;
    private NavMeshPath path;
    private LineRenderer line;
    public bool lineToggle = false;
    public Button toggleLine;
    private bool gotTheQrCode = false; 
    public Text distanceText;
    private string qrCode;
    private static SetNavigationTarget instance;

    // Ensure there is only one instance of this script.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SetNavigationTarget Instance
    {
        get { return instance; }
    }

    void Start()
    {
        Debug.Log("SetNavigation");
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;

        Button toggleBtn = toggleLine.GetComponent<Button>();
        toggleBtn.onClick.AddListener(ToggleVisibility);
    }

    void Update()
    {
        if (lineToggle) {
            qrCode = QRCodeSingleton.Instance.GetQRCodeElementName();
            //has a qr code scanned somewhere
            if (!string.IsNullOrEmpty(qrCode) && !gotTheQrCode)
            {
                //find target
                navTargetObject = GameObject.Find(qrCode);

                NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
                // Calculate the full distance, including obstacle avoidance

                distanceText.text = "Distance: " + Vector3.Distance(transform.position, navTargetObject.transform.position).ToString("0.00") + "m";
                line.positionCount = path.corners.Length;
                line.SetPositions(path.corners);
            }
        }
    }

    public void setLineToggle(bool state)
    {
        lineToggle = state;
        line.enabled = state;
        distanceText.gameObject.SetActive(state);
    }

    void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
        gotTheQrCode = false;
        distanceText.gameObject.SetActive(lineToggle);
    }
}

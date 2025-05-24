//using UnityEngine;
//using System;
//using System.Collections;
//using ZXing;
//using UnityEngine.UI;
//using UnityEngine.XR.ARFoundation;
//using Unity.XR.CoreUtils;

//public class StandaloneEasyReaderSample : MonoBehaviour
//{
//    private WebCamTexture webcamTexture;
//    private Rect screenRect;
//    private bool qrCodeDetected = false; // Variable to track if QR code has been detected
//    public Button scanButton;
//    public Button stopScanButton;
//    public Button tapButton;
//    public Button toggleNavigation;
//    private bool useGui = false;
//    public float timeRemaining;
//    public bool timerIsRunning = false;
//    public GameObject qrCodeText;
//    public GameObject qrCodeAlertError;
//    private ObjectDetection objScript;
//    private bool isQrSuccessful = false;

//    void Start()
//    {
//        Debug.Log("Standalone");
//        objScript = GetComponent<ObjectDetection>();
//        Debug.Log("Script is running!");
//        qrCodeText.SetActive(false);
//        qrCodeAlertError.SetActive(false);
//        tapButton.gameObject.SetActive(false);

//        Button btn = scanButton.GetComponent<Button>();
//        btn.onClick.AddListener(TaskOnClick);


//        Button stopBtn = stopScanButton.GetComponent<Button>();
//        stopScanButton.gameObject.SetActive(false);
//        stopBtn.onClick.AddListener(() => StopScan(""));

//        Button tapBtn = tapButton.GetComponent<Button>();
//        tapBtn.onClick.AddListener(() => HighlightTap());

//        //Button btnToggleNavigation = toggleNavigation.GetComponent<Button>();
//    }
//    void Update()
//    {
//        //decrease time remaining (if scan was successful)
//        if (timerIsRunning)
//        {
//            if (timeRemaining > 0)
//            {
//                timeRemaining -= Time.deltaTime;
//            }
//            else
//            {
//                //hide the text after timer has passed
//                timeRemaining = 0;
//                timerIsRunning = false;

//                //scan didnt fail
//                if (isQrSuccessful)
//                {
//                    qrCodeText.SetActive(false);
//                }
//                else
//                {
//                    tapButton.gameObject.SetActive(false);
//                    qrCodeAlertError.SetActive(false);
//                }
//            }
//        }

//        if (!qrCodeDetected && webcamTexture != null && useGui)
//        {
//            try
//            {
//                qrCodeAlertError.SetActive(false);
//                qrCodeText.SetActive(false);

//                IBarcodeReader barcodeReader = new BarcodeReader();
//                var result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);
//                if (result != null)
//                {
//                    // QRCode detected.
//                    qrCodeDetected = true;
//                    StopScan(result.Text);
//                    return;
//                }
//            }
//            catch (Exception e)
//            {
//                Debug.LogError(e.Message);
//            }
//        }
//    }

//    void OnGUI()
//    {
//        if (useGui)
//        {
//            Vector2 pivot = new Vector2(screenRect.x + screenRect.width / 2, screenRect.y + screenRect.height / 2);
//            GUIUtility.RotateAroundPivot(-270, pivot);
//            GUI.DrawTexture(screenRect, webcamTexture, ScaleMode.ScaleToFit);
//            GUIUtility.RotateAroundPivot(270, pivot);
//        }
//    }

//    void TaskOnClick()
//    {
//        scanButton.gameObject.SetActive(false);
//        //btnToggleNavigation.gameObject.SetActive(false);
//        stopScanButton.gameObject.SetActive(true);
//        objScript.slider.enabled = false;
//        GameObject.Find("AR Session").GetComponent<ARSession>().enabled = false;
//        GameObject.Find("AR Session Origin").GetComponent<XROrigin>().enabled = false;
//        GameObject.Find("AR Camera").GetComponent<Camera>().enabled = false;
//        screenRect = new Rect(0, 0, Screen.width, Screen.height);
//        //screenRect = new Rect(Screen.width / 2, Screen.height / 2, 150 , 150);
//        webcamTexture = new WebCamTexture();
//        webcamTexture.Play();
//        qrCodeDetected = false;
//        useGui = true;
//    }

//    async void StopScan(string text)
//    {
//        if (text != null && text != "")
//        {
//            bool res = await objScript.QrCodeScanned(text);

//            if (res)
//            {
//                //qr code was successful
//                isQrSuccessful = true;
//                qrCodeText.SetActive(true);
//                timeRemaining = 5;
//                timerIsRunning = true;
//                tapButton.gameObject.SetActive(true);
//            }
//            else
//            {
//                isQrSuccessful = false;
//                qrCodeAlertError.SetActive(true);
//                timeRemaining = 5;
//                timerIsRunning = true;
//            }
//        }

//        objScript.slider.enabled = true;
//        stopScanButton.gameObject.SetActive(false);
//        //scanButton.gameObject.SetActive(true);
//        useGui = false;
//        webcamTexture.Stop();
//        GameObject.Find("AR Session").GetComponent<ARSession>().enabled = true;
//        GameObject.Find("AR Session Origin").GetComponent<XROrigin>().enabled = true;
//        GameObject.Find("AR Camera").GetComponent<Camera>().enabled = true;
//    }

//    void HighlightTap()
//    {
//        tapButton.gameObject.SetActive(false);
//        //not 0 since 0 in slider will make elements disappear
//        objScript.slider.value = 0.5f;
//        //navigationTarget.setLineToggle(true);
//        objScript.RemoveHighlighted();
//        scanButton.gameObject.SetActive(true);
//    }
//}

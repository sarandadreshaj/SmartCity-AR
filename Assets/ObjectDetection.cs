//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using UnityEngine;
//using UnityEngine.UI;

//public class ObjectDetection : MonoBehaviour
//{
//    private GameObject parentObject;
//    //private string[] elements;
//    //private Color borderColor; // Set the border color here
//    //private Material originalMaterial;
//    //private Material borderMaterial;
//    public string qrCodeElementName;
//    public Slider slider;
//    private Transform[] ts;
//    public GameObject lineButton;
//    public GameObject miniMap;
//    public Text distanceText;
//    //private AndroidJavaObject activity;

//    // Start is called before the first frame update
//    void Start()
//    {
//        Debug.Log("Object det");
//        //QrCodeScanned();
//        //qrCodeElementName = "4825663:4";
//        //find parent
//        parentObject = GameObject.FindWithTag("Parent");
//        //find children 
//        ts = parentObject.GetComponentsInChildren<Transform>();
//        //find slider
//        slider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
//        //assign listener
//        slider.onValueChanged.AddListener(delegate
//        {
//            foreach (var item in ts)
//            { 
//                //if (slider.value == 0)
//                //{
//                //    if(qrCodeElementName != null)
//                //    {
//                //        if (item.name != parentObject.name && !item.name.Contains(qrCodeElementName))
//                //        {
//                //            item.gameObject.SetActive(false);
//                //        }
//                //    }
//                //    //else
//                //    //{
//                //    //    item.gameObject.SetActive(false);
//                //    //}
//                //}
//                //else
//                //{
//                    foreach (Transform child in item)
//                    {
//                        Renderer renderer = child.GetComponent<Renderer>();

//                        if (renderer != null) 
//                        {
//                            if (slider.value == 0)
//                            {
//                                Material[] materials = renderer.materials;
//                                if (!materials.Any(x => x.name.Contains("FoundMaterial")) /*!item.name.Contains(qrCodeElementName)*/)
//                                {
//                                    child.gameObject.SetActive(false);
//                                }
//                            }
//                            else
//                            {
//                                if (!child.name.Contains("EBW"))
//                                {
//                                    child.gameObject.SetActive(true);
//                                }
//                                //not scanned
//                                if (qrCodeElementName == null)
//                                {
//                                    var color = renderer.material.color;
//                                    color.a = slider.value;
//                                    renderer.material.color = color;
//                                }
//                                //scanned
//                                else
//                                {
//                                    Material[] materials = renderer.materials;
//                                    //if it contains found material
//                                    if (!materials.Any(x => x.name.Contains("FoundMaterial")) /*!item.name.Contains(qrCodeElementName)*/)
//                                    {
//                                        var color = renderer.material.color;
//                                        color.a = slider.value;
//                                        renderer.material.color = color;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    //item.gameObject.SetActive(true);
//                    qrCodeElementName = QRCodeSingleton.Instance.GetQRCodeElementName();
//                //}
//            }
//        });
//        // ONLY WORKS IN ANDROID RUNTIME

//        // ------------------------------------------------------------------

//        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//        //activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
//        //AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");

//        //string action = intent.Call<string>("getAction");
//        //AndroidJavaObject data = intent.Call<AndroidJavaObject>("getData");

//        //if (action == "android.intent.action.VIEW" && data != null)
//        //{
//        //    // Handle the deep link here
//        //    string deepLink = data.Call<string>("toString");
//        //    Debug.Log("Received deep link: " + deepLink);

//        //    // Parse and process the deep link as needed
//        //    qrCodeElementName = deepLink.Split("?")[1];
//        //}
//        //------------------------------------------------------------------
//        // will only lower opacity if qr code is scanned
//        ////if (qrCodeElementName != null && qrCodeElementName != "")
//        ////{
//        foreach (var item in ts)
//        {
//            var renderer = item.gameObject.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                if (item.name.Contains("EBW"))
//                {
//                    item.gameObject.SetActive(false);
//                }
//                //if(item.GetComponents<Renderer>() != null)
//                //{
//                //    foreach(var rendererItem in item.GetComponents<Renderer>())
//                //    {
//                //        rendererItem.enabled = false;
//                //    }
//                //}
//                item.GetComponent<Renderer>().material = Resources.Load<Material>("GreyMaterial");
//            }
//        }
//    }

//    private void ToggleNavigationObjects(bool state)
//    {
//        lineButton.gameObject.SetActive(state);
//        miniMap.gameObject.SetActive(state);
//    }

//    public void RemoveHighlighted()
//    {
//        distanceText.gameObject.SetActive(false);
//        SetNavigationTarget.Instance.setLineToggle(false);
//        ToggleNavigationObjects(false);

//        foreach (var item in ts)
//        {
//            foreach (Transform item2 in item.transform)
//            {
//                item2.GetComponent<Renderer>().material = Resources.Load<Material>("GreyMaterial");
//            }
//        }
//    }

//    public async Task<bool> QrCodeScanned(string scannedCode)
//    {
//        //find children
//        parentObject = GameObject.FindGameObjectWithTag("Parent");
//        ts = parentObject.GetComponentsInChildren<Transform>().Where(child => child != parentObject.transform && child.childCount > 0).ToArray();

//        try
//        {
//            Uri uri = new Uri(scannedCode);
//            var query = HttpUtility.ParseQueryString(uri.Query);
//            qrCodeElementName = query["panel_name"];

//            if (!string.IsNullOrEmpty(qrCodeElementName))
//            {
//                slider.value = 0.5f;
//                RemoveHighlighted();
//                foreach (var item in ts)
//                {
//                    if (item.name == qrCodeElementName)
//                    {
//                        ToggleNavigationObjects(true);

//                        foreach (Transform item2 in item.transform)
//                        {
//                            item2.GetComponent<Renderer>().material = Resources.Load<Material>("FoundMaterial");
//                        }
//                        QRCodeSingleton.Instance.SetQRCodeElementName(qrCodeElementName);
//                        return true;
//                    }
//                }
//            }
//            return false;
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("\nException Caught!");
//            Console.WriteLine("Message :{0} ", e.Message);
//            return false;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }
//}

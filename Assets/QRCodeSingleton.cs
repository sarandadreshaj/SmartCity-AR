using UnityEngine;

public class QRCodeSingleton : MonoBehaviour
{ 
    private static QRCodeSingleton instance;
    private string qrCodeElementName;

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

    public static QRCodeSingleton Instance
    {
        get { return instance; }
    }

    public string GetQRCodeElementName()
    {
        return qrCodeElementName;
    }

    public void SetQRCodeElementName(string elementName)
    {
        qrCodeElementName = elementName;
    }
}

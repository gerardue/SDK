using UnityEngine;

public class ConsumerSDK : MonoBehaviour
{
    [Header("Type SDK")]
    [SerializeField]
    private TypeSDK typeSDK;

    [Header("Request")]
    [SerializeField]
    private string request; 

    private ISdk sdk;

    void Start()
    {
        Init(typeSDK);

        request = JobSDK();
        Debug.Log(request); 
    }

    public void Init(TypeSDK typeSDK)
    {
        ServiceLocator.Instance.GetService<SOLibrarySDK>().Init();
        sdk = ServiceLocator.Instance.GetService<SOLibrarySDK>().GetSDK(typeSDK);
    }

    public string JobSDK()
    {
        if (sdk == null)
            return "Not SDK";
        return sdk.Job();
    }
}

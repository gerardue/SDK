using UnityEngine;

/// <summary>
/// This class is for testing
/// </summary>
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

    #region For Testing

    private void RunSdk(TypeSDK typeSdk)
    {
        sdk = ServiceLocator.Instance.GetService<SOLibrarySDK>().GetSDK(typeSdk);
        request = JobSDK();
        Debug.Log(request);
    }

    [ContextMenu("Sdk_A")]
    public void SdkA() => RunSdk(TypeSDK.Sdk_A);

    [ContextMenu("Sdk_B")]
    public void SdkB() => RunSdk(TypeSDK.Sdk_B);

    [ContextMenu("Sdk_C")]
    public void SdkC() => RunSdk(TypeSDK.Sdk_C);
    

    #endregion
}

using System;
using System.Collections.Generic;
using UnityEngine;

#region Complements

public enum TypeSDK
{
    Sdk_A = 0,
    Sdk_B = 1,
    Sdk_C = 2,
    Sdk_D = 3
}

/// <summary>
/// Sdk model
/// </summary>
[System.Serializable]
public class SdkModel
{
    public string name;
    public TypeSDK type;
    public UnityEngine.Object sdk;

    private ISdk sdkInstance = null;

    public ISdk Sdk { get { return sdkInstance; } }

    public void CreateSdk()
    {
        var typeSdk = Type.GetType(sdk.name);
        
        if(sdkInstance == null)
        {
            if(typeof(ISdk).IsAssignableFrom(typeSdk))
            {
                var _sdk_ = Activator.CreateInstance(typeSdk);
                sdkInstance = _sdk_ as ISdk; 
            }
            else
            {
                Debug.Log("This is not a SDK"); 
            }
        }
        else
        {
            Debug.Log("it was already created"); 
        }
    }
}

#endregion

/// <summary>
/// This scriptable object is used to save the sdks it's available
/// </summary>
[CreateAssetMenu(fileName = "LibrarySDK", menuName = "Setup/LibrarySDK")]
public class SOLibrarySDK : ScriptableObject
{
    [SerializeField]
    private List<SdkModel> sdk = new List<SdkModel>();

    private Dictionary<TypeSDK, SdkModel> sdksAvaliable;

    /// <summary>
    /// Init sdk availables
    /// </summary>
    public void Init()
    {
        sdksAvaliable = new Dictionary<TypeSDK, SdkModel>();
        sdksAvaliable.Clear();

        sdk.ForEach(sdk =>
        {
            if (sdk.sdk != null)
            {
                if (sdksAvaliable.TryGetValue(sdk.type, out SdkModel tempSdk))
                    return;

                sdksAvaliable.Add(sdk.type, sdk);
            }
        });
    }

    /// <summary>
    /// Get specific sdk
    /// </summary>
    public ISdk GetSDK(TypeSDK typeSdk)
    {
        ISdk sdk = null;

        if (sdksAvaliable.TryGetValue(typeSdk, out SdkModel sdkModel))
        {
            sdkModel.CreateSdk();
            sdk = sdkModel.Sdk; 
        }
        else
            Debug.Log("Not exits this sdk " + typeSdk);

        return sdk;
    }
}



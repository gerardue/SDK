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

    public ISdk Sdk()
    {
        var typeSdk = Type.GetType(sdk.name);
        var _sdk = Activator.CreateInstance(typeSdk);

        if (_sdk is ISdk)
            return (ISdk)_sdk;

        return null;
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
    private List<SdkModel> models = new List<SdkModel>();

    private Dictionary<TypeSDK, ISdk> sdksAvaliable;

    /// <summary>
    /// Init sdk availables
    /// </summary>
    public void Init()
    {
        sdksAvaliable = new Dictionary<TypeSDK, ISdk>();
        sdksAvaliable.Clear();

        ISdk sdkTemp;

        models.ForEach(sdk =>
        {
            if (sdk.sdk != null)
            {
                if (sdksAvaliable.TryGetValue(sdk.type, out ISdk sdk2))
                    return;

                sdkTemp = sdk.Sdk();
                if (sdkTemp != null)
                    sdksAvaliable.Add(sdk.type, sdk.Sdk());
            }
        });
    }

    /// <summary>
    /// Get specific sdk
    /// </summary>
    public ISdk GetSDK(TypeSDK typeSdk)
    {
        ISdk sdk;

        if (!sdksAvaliable.TryGetValue(typeSdk, out sdk))
            Debug.Log("Not exits");

        return sdk;
    }
}



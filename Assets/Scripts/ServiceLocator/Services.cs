using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to install services
/// </summary>
public class Services : MonoBehaviour
{
    [Header("Library SDK")]
    [SerializeField]
    private SOLibrarySDK librarySDK;

    private void Awake()
    {
        InitServices();
    }

    private void InitServices()
    {
        ServiceLocator.Instance.RegisterService(librarySDK);
    }
}

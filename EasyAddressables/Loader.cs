using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class Loader
{
    public static IEnumerator Load<T>(string assetLabel, List<T> assets)
    {
        yield return Addressables.LoadAssetsAsync<T>(assetLabel, op =>
        {
            assets.Add(op);
        });
    }
    
    public static IEnumerator LoadCreateDeactivate<T>(string assetLabel, List<T> assets) where T : Object
    {
        yield return  Addressables.LoadAssetsAsync<T>(assetLabel, op =>
        {
            assets.Add(GameObject.Instantiate(op));
        });

        foreach (var asset in assets)
        {
            GameObject.Find(asset.name).gameObject.SetActive(false);
        }
    }
}

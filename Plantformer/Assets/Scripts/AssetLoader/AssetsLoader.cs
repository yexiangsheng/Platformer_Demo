using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
//加载Scenes
//加载GameObject
//泛型加载
public class AddressableLoader : Singleton<AddressableLoader>
{

    Dictionary<string, AsyncOperationHandle<GameObject>> prefabHandleDict = new Dictionary<string, AsyncOperationHandle<GameObject>>();
    Dictionary<string, AsyncOperationHandle> assetHandleDict = new Dictionary<string, AsyncOperationHandle>();

    AsyncOperationHandle<SceneInstance> _sceneHandle;

    #region 加载与卸载Scenes
    public async UniTask LoadScene(string sceneName, System.Action<float> progressCallback, System.Action<SceneInstance> loadSucceedCallback)
    {
        if (_sceneHandle.IsValid())
        {
            await UnloadScene();
        }
        //Parameter:地址(名字)或者label，Single或Additive，是否激活
        var handle = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single, false);
        //TODO: Progress是什么意思?
        var progress = progressCallback != null ? Progress.Create<float>(progressCallback) : null;

        await handle.ToUniTask();
        if (handle.IsValid())
        {
            //保留Scene的引用
            _sceneHandle = handle;

            //在回调函数中激活
            loadSucceedCallback?.Invoke(handle.Result);
        }
    }
    public async UniTask UnloadScene()
    {
        if (_sceneHandle.IsValid())
        {
            // 第一步：卸载场景
            var unloadHandle = Addressables.UnloadSceneAsync(_sceneHandle);
            await unloadHandle.ToUniTask();

            // 第二步：释放句柄（核心：销毁句柄，释放内存）
            Addressables.Release(_sceneHandle);
            // 清空句柄引用
            _sceneHandle = default;
        }
    }
    #endregion

    #region 加载与卸载GameObject
    public async UniTask<GameObject> LoadPrefab(string prefabName, System.Action<GameObject> loadSucceedCallback)
    {
        if (prefabHandleDict.ContainsKey(prefabName))
        {
            return prefabHandleDict[prefabName].Result;
        }

        var handle = Addressables.LoadAssetAsync<GameObject>(prefabName);
        await handle.ToUniTask();

        if (handle.IsValid())
        {
            prefabHandleDict.Add(prefabName, handle);
            loadSucceedCallback?.Invoke(handle.Result);
        }
        return handle.Result;
    }
    public void UnloadPrefab(string prefabName)
    {
        if (prefabHandleDict.TryGetValue(prefabName, out var handle) && handle.IsValid())
        {
            // 释放句柄
            Addressables.Release(handle);
            // 移除字典引用
            prefabHandleDict.Remove(prefabName);
            Debug.Log($"Prefab{prefabName}句柄已释放");
        }
    }
    public void UnloadAllPrefab()
    {
        foreach (var prefabName in prefabHandleDict)
        {
            if (prefabName.Value.IsValid())
            {
                // 释放句柄
                Addressables.Release(prefabName.Value);
            }
        }
        // 移除字典引用
        prefabHandleDict.Clear();
    }
    #endregion

    #region 加载与卸载Assets
    public async UniTask<T> LoadAssets<T>(string resName, System.Action<T> loadSucceedCallback = null) where T : Object
    {
        if (assetHandleDict.ContainsKey(resName))
        {
            return assetHandleDict[resName].Result as T;
        }

        AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(resName);
        await handle.ToUniTask();

        if (handle.IsValid())
        {
            assetHandleDict.Add(resName, handle);
            loadSucceedCallback?.Invoke(handle.Result);
        }
        return handle.Result;
    }
    public void UnloadAsset(string prefabName)
    {
        if (assetHandleDict.TryGetValue(prefabName, out var handle) && handle.IsValid())
        {
            // 释放句柄
            Addressables.Release(handle);
            // 移除字典引用
            assetHandleDict.Remove(prefabName);
            Debug.Log($"Prefab{prefabName}句柄已释放");
        }
    }
    public void UnloadAllAsset()
    {
        foreach (var assetName in assetHandleDict)
        {
            if (assetName.Value.IsValid())
            {
                // 释放句柄
                Addressables.Release(assetName.Value);
            }
        }
        // 移除字典引用
        assetHandleDict.Clear();
    }
    #endregion
}

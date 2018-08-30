// AUTO-GENERATED CLASS. DO NOT EDIT.
// This is an automatically generated script, any changes made will be overwritten.
using UnityEngine;
using UnityEditor;

public static class GeneratedMenuItems_BaseLevelItems
{
    [MenuItem("GameObject/Add Prefab/AIWaypoint", false, priority = -1)]
    private static void MenuItem0()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Waypoint.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/Add Prefab/BaseDirectionalLight", false, priority = -1)]
    private static void MenuItem1()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BaseDirectionalLight.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/Add Prefab/CinematicCamera", false, priority = -1)]
    private static void MenuItem2()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/CinematicCamera.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/Add Prefab/Player", false, priority = -1)]
    private static void MenuItem3()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/Add Prefab/Player_Cam", false, priority = -1)]
    private static void MenuItem4()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player_Cam.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/Add Prefab/PlayerStart", false, priority = -1)]
    private static void MenuItem5()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/PlayerStart.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

}

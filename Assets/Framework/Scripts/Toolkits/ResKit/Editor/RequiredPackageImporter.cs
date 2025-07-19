using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Framework.Toolkits.ResKit
{
    public static class RequiredPackageImporter
    {
        public static void ImportRequiredPackages()
        {
            // .unitypackage 开始导入
            AssetDatabase.importPackageStarted += packageName =>
            {
                Debug.Log(packageName);
            };
            // .unitypackage 导入成功
            AssetDatabase.importPackageCompleted += packageName =>
            {
                Debug.Log(packageName);
            };
            // .unitypackage 取消导入
            AssetDatabase.importPackageCancelled += packageName =>
            {
                Debug.Log(packageName);
            };
            // .unitypackage 导入失败
            AssetDatabase.importPackageFailed += (packageName, errorMessage) =>
            {
                Debug.Log(errorMessage);
            };
        }
    }
}
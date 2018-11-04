using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBuilder :Editor {

    [MenuItem("Assets/ Build AssetBundles")]
    static void BuildAllAssetBundles() {

        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        string path = "_Cards/Players";
        string[] Tdata = getAtPath<PlayerCard>(path);

        foreach (string data in Tdata) {
            Debug.Log(data);
        }
        buildMap[0].assetBundleName = "cards";
        buildMap[0].assetNames = Tdata;

        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(@"C:\Unity\remoted_clone\cardboad-game\CardBoardGame\Assets\StreamingAssets\AssetBundles",
                                buildMap,
                                BuildAssetBundleOptions.ChunkBasedCompression,
                                BuildTarget.StandaloneWindows64);
        if (manifest == null)
        {
            Debug.Log("Asset Bundle Could not be created");
        }


    }


    static public string[] getAtPath<T>(string path){

        ArrayList al = new ArrayList();
       
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
        foreach (string fileName in fileEntries)
        {
            char[] delimiterChars = { '\\' };

            string[] arr = fileName.Split(delimiterChars);
            string finalFileName = arr[arr.Length - 1];
            string localFileName = "Assets/" + path + "/" + finalFileName;
            Object t = AssetDatabase.LoadAssetAtPath(localFileName, typeof(T));

            al.Add(localFileName);
        }

        foreach (string x in al) {
            Debug.Log(x);
        }
         
        return al.ToArray(typeof(string)) as string[];
    }

}

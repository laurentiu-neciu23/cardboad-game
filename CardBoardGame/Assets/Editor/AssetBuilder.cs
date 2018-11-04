using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBuilder :Editor {

    [MenuItem("Assets/ Build AssetBundles")]
    static void BuildAllAssetBundles() {

        AssetBundleBuild[] buildMap = new AssetBundleBuild[3];

        buildMap[0].assetBundleName = "cards";
        buildMap[1].assetBundleName = "leaders";
        buildMap[2].assetBundleName = "specials";
        buildMap[0].assetNames = getAtPath<PlayerCard>("_Cards/Players");
        buildMap[1].assetNames = getAtPath<LeaderCard>("_Cards/Leaders");
        buildMap[2].assetNames = getAtPath<SpecialCard>("_Cards/Specials");

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
            Debug.Log(localFileName);
            Object t = AssetDatabase.LoadAssetAtPath(localFileName, typeof(T));

            al.Add(localFileName);
        }

        foreach (string x in al) {
            Debug.Log(x);
        }
         
        return al.ToArray(typeof(string)) as string[];
    }

}

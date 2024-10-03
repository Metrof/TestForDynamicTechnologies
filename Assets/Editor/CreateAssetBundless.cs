using UnityEditor;

public class CreateAssetBundless 
{
    [MenuItem("Assets/ Build Bundles")]
    static void BildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}

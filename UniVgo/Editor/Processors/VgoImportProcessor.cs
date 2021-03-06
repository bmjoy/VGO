﻿// ----------------------------------------------------------------------
// @Namespace : UniVgo.Editor
// @Class     : VgoImportProcessor
// ----------------------------------------------------------------------
namespace UniVgo.Editor
{
    using System.IO;
    using System.Threading.Tasks;
    using UniGLTFforUniVgo;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// VGO Import Processor
    /// </summary>
    public static class VgoImportProcessor
    {
        /// <summary>
        /// Import VGO.
        /// </summary>
        /// <returns></returns>
        public static async Task ImportVgo()
        {
            string path = EditorUtility.OpenFilePanel(title: "Open File Dialog", directory: "", extension: "vgo");

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (Application.isPlaying)
            {
                //
                // load into scene
                //
                var context = new VgoImporter();

                await context.LoadAsync(path, showMeshes: true, enableUpdateWhenOffscreen: true);

                Selection.activeGameObject = context.Root;
            }
            else
            {
                //
                // save as asset
                //
                if (path.StartsWithUnityAssetPath())
                {
                    Debug.LogWarningFormat("disallow import from folder under the Assets");
                    return;
                }

                string assetPath = EditorUtility.SaveFilePanel(title: "Save prefab", directory: "Assets", defaultName: Path.GetFileNameWithoutExtension(path), extension: "prefab");

                if (string.IsNullOrEmpty(path))
                {
                    return;
                }

                // import as asset
                VgoAssetPostprocessor.ImportAsset(path, UnityPath.FromFullpath(assetPath));
            }
        }
    }
}
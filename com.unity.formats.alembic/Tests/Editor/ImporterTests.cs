using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

namespace UnityEditor.Formats.Alembic.Importer
{
    class FileManipulations
    {
        List<string> m_FilesToDelete = new List<string>();

        [TearDown]
        public void TearDown()
        {
            foreach (var path in m_FilesToDelete)
                AssetDatabase.DeleteAsset(path);
        }

        [Test]
        public void MoveFileFromFileSystem_PathToABC_IsUpdated()
        {
            string guid = "dd3554fc098614b9e99b49873fe18cd6";
            string fileToCopy = "Assets/myAsset.abc";
            string fullPath = Application.dataPath + "/myAsset.abc";

            string newLocation = "Assets/Tests/myAsset.abc";
            string newLocationfullPath = Application.dataPath + "/Tests/myAsset.abc";

            var path = AssetDatabase.GUIDToAssetPath(guid);

            bool success = AssetDatabase.CopyAsset(path, fileToCopy);
            Assume.That(success, Is.True, $"AssetDatabase could not copy the original file at {path}");

            var desc = AssetDatabase.LoadAssetAtPath<AlembicStreamDescriptor>(fileToCopy);
            Assume.That(desc.PathToAbc, Is.EqualTo(fileToCopy));

            Directory.CreateDirectory(Path.GetDirectoryName(newLocationfullPath));

            File.Move(fullPath, newLocationfullPath);
            File.Move(fullPath + ".meta", newLocationfullPath + ".meta");
            AssetDatabase.Refresh();

            m_FilesToDelete.Add(Path.GetDirectoryName(newLocation));

            desc = AssetDatabase.LoadAssetAtPath<AlembicStreamDescriptor>(newLocation);
            Assert.That(desc.PathToAbc, Is.EqualTo(newLocation),
                "PathToAbc should have been updated to the new path.");
        }

        private Dictionary<string, List<Color>> ScopeExpectedColors = new Dictionary<string, List<Color>>
        {
            { "cube_face", new List<Color>
            {
                new Color(0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color (0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color(0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color(0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f)
            }},
            { "cube_point", new List<Color>
            {
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.262381f, 0.579069f, 0.83773f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color( 0.901355f, 0.815292f, 0.613544f, 1.0f)
            }},
            { "cube_vertex", new List<Color>
            {
                new Color(0.136873f, 0.570807f, 0.034585f, 1.0f),
                new Color(0.807873f, 0.292345f, 0.0282118f, 1.0f),
                new Color(0.638699f, 0.320457f, 0.676918f, 1.0f),
                new Color(0.849678f, 0.0295019f, 0.185701f, 1.0f),
                new Color(0.410384f, 0.133891f, 0.293169f, 1.0f),
                new Color(0.0560673f, 0.955198f, 0.474951f, 1.0f),
                new Color(0.262381f, 0.579069f, 0.83773f, 1.0f),
                new Color(0.901355f, 0.815292f, 0.613544f, 1.0f),
                new Color(0.745016f, 0.696294f, 0.140825f, 1.0f),
                new Color(0.689646f, 0.156375f, 0.77343f, 1.0f),
                new Color(0.931242f, 0.517226f, 0.498477f, 1.0f),
                new Color(0.055582f, 0.523521f, 0.286915f, 1.0f),
                new Color(0.449092f, 0.111865f, 0.48572f, 1.0f),
                new Color(0.901333f, 0.178653f, 0.730107f, 1.0f),
                new Color(0.054878f, 0.691018f, 0.0120219f, 1.0f),
                new Color(0.396657f, 0.233593f, 0.736785f, 1.0f),
                new Color(0.591222f, 0.90485f, 0.211925f, 1.0f),
                new Color(0.839599f, 0.116205f, 0.662651f, 1.0f),
                new Color(0.861743f, 0.252549f, 0.578756f, 1.0f),
                new Color(0.786967f, 0.518664f, 0.646041f, 1.0f),
                new Color(0.417679f, 0.909779f, 0.213722f, 1.0f),
                new Color(0.206854f, 0.819972f, 0.330694f, 1.0f),
                new Color(0.733233f, 0.0665461f, 0.0174288f, 1.0f),
                new Color(0.242886f, 0.790562f, 0.235412f, 1.0f)
            }}
        };

        [Test]
        [TestCase( "cube_face")]
        [TestCase( "cube_point")]
        [TestCase( "cube_vertex")]
        public void RgbAttributes_AreProcessedCorrectly(string scope)
        {
            string guid = "dd3554fc098614b9e99b49873fe18cd6";
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var meshPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            GameObject.Instantiate(meshPrefab); // needed to add the mesh filter component

            var meshFilter = GameObject.Find(scope).GetComponentInChildren<MeshFilter>();

            var expectedColors = ScopeExpectedColors[scope];

            for (int i = 0; i < expectedColors.Count; i++)
            {
               var meshColor = meshFilter.sharedMesh.colors[i];
                Assert.IsTrue(meshFilter.sharedMesh.colors[i] == expectedColors[i],
                    $"Scope: {scope}, Expected: {expectedColors[i]}, But was: {meshColor}");
            }
        }
    }
}

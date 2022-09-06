using JetBrains.Annotations;
using Needle.Deeplink;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal static class DeeplinkExtension
    {
        [DeepLink( RegexFilter = @"com.unity3d.kharma:execute-menu-item\/(.*)" )]
        [UsedImplicitly]
        private static bool ExecuteMenuItem( string menuItemPath )
        {
            Debug.Log( menuItemPath );
            return EditorApplication.ExecuteMenuItem( menuItemPath );
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:ping-asset\/(.*)" )]
        [UsedImplicitly]
        private static bool PingAsset( string assetPath )
        {
            Debug.Log( assetPath );
            var asset = AssetDatabase.LoadAssetAtPath<Object>( assetPath );
            if ( asset == null ) return false;
            EditorGUIUtility.PingObject( asset );
            return true;
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:ping-game-object\/(.*)" )]
        [UsedImplicitly]
        private static bool PingGameObject( string gameObjectName )
        {
            Debug.Log( gameObjectName );
            var gameObject = GameObject.Find( gameObjectName );
            if ( gameObject == null ) return false;
            EditorGUIUtility.PingObject( gameObject );
            return true;
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:open-asset\/(.*)" )]
        [UsedImplicitly]
        private static bool OpenAsset( string assetName )
        {
            Debug.Log( assetName );
            var asset = AssetDatabase.LoadAssetAtPath<Object>( assetName );
            if ( asset == null ) return false;
            return AssetDatabase.OpenAsset( asset );
        }
    }
}
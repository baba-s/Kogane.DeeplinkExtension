using System;
using JetBrains.Annotations;
using Needle.Deeplink;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kogane.Internal
{
    internal static class DeeplinkExtension
    {
        [DeepLink( RegexFilter = @"com.unity3d.kharma:execute-menu-item\/(.*)" )]
        [UsedImplicitly]
        private static bool ExecuteMenuItem( string option )
        {
            var menuItemName = Uri.UnescapeDataString( option );
            Debug.Log( $"{nameof( ExecuteMenuItem )}: {menuItemName}" );
            return EditorApplication.ExecuteMenuItem( menuItemName );
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:ping-asset\/(.*)" )]
        [UsedImplicitly]
        private static bool PingAsset( string option )
        {
            var assetPath = Uri.UnescapeDataString( option );
            Debug.Log( $"{nameof( PingAsset )}: {assetPath}" );
            var asset = AssetDatabase.LoadAssetAtPath<Object>( assetPath );
            if ( asset == null ) return false;
            EditorGUIUtility.PingObject( asset );
            return true;
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:ping-game-object\/(.*)" )]
        [UsedImplicitly]
        private static bool PingGameObject( string option )
        {
            var gameObjectName = Uri.UnescapeDataString( option );
            Debug.Log( $"{nameof( PingGameObject )}: {gameObjectName}" );
            var gameObject = GameObject.Find( gameObjectName );
            if ( gameObject == null ) return false;
            EditorGUIUtility.PingObject( gameObject );
            return true;
        }

        [DeepLink( RegexFilter = @"com.unity3d.kharma:open-asset\/(.*)" )]
        [UsedImplicitly]
        private static bool OpenAsset( string option )
        {
            var assetName = Uri.UnescapeDataString( option );
            Debug.Log( $"{nameof( OpenAsset )}: {assetName}" );
            var asset = AssetDatabase.LoadAssetAtPath<Object>( assetName );
            if ( asset == null ) return false;
            return AssetDatabase.OpenAsset( asset );
        }
    }
}
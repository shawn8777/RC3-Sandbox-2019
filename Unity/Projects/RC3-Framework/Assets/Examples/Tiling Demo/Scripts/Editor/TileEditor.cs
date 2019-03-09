
/*
 * Notes
 * 
 * impl refs
 * http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
 * http://catlikecoding.com/unity/tutorials/editor/custom-list/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CustomEditor(typeof(LabeledTile))]
    public class TileEditor : Editor
    {
        private ReorderableList _list;
        private PreviewRenderUtility _renderUtil;
        

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            _list = new ReorderableList(
                serializedObject, 
                serializedObject.FindProperty("_labels"), 
                true, true, true, true);

            _list.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Labels");
            _list.drawElementCallback = OnDrawElement;
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnDrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            var elem = _list.serializedProperty.GetArrayElementAtIndex(index);
            rect = new Rect(rect.x, rect.y + 2, rect.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(rect, elem, new GUIContent($"Direction {index}"));
        }


        /// <summary>
        /// 
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();
            _list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasPreviewGUI()
        {
            return true;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="background"></param>
        public override void OnPreviewGUI(Rect rect, GUIStyle background)
        {
            // TODO Resolve interaction

            if (_renderUtil == null)
            {
                _renderUtil = new PreviewRenderUtility();
                _renderUtil.camera.transform.position = new Vector3(0.0f, 0.0f, -6.0f);
            }

            _renderUtil.BeginPreview(rect, background);
            {
                var tile = target as LabeledTile;
                _renderUtil.DrawMesh(tile.Mesh, Matrix4x4.identity, tile.Material, 0);
                _renderUtil.camera.Render();
            }
            Texture result = _renderUtil.EndPreview();

            GUI.DrawTexture(rect, result);
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnDisable()
        {
            if (_renderUtil != null)
                _renderUtil.Cleanup();
        }
    }
}
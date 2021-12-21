/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LerpPointerMeterEditor.cs
 *  Description  :  Editor for LerpPointerMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

namespace MGS.Meter.Editors
{
    [CustomEditor(typeof(LerpMeter), true)]
    [CanEditMultipleObjects]
    public class LerpPointerMeterEditor : MeterEditor
    {
        #region Field and Property
        protected new LerpMeter Target { get { return target as LerpMeter; } }

        protected SerializedProperty lerpMode;
        protected SerializedProperty mainSpeed;
        protected SerializedProperty minSpeed;
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            lerpMode = serializedObject.FindProperty("lerpMode");
            mainSpeed = serializedObject.FindProperty("mainSpeed");
            minSpeed = serializedObject.FindProperty("minSpeed");
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(lerpMode);
            EditorGUILayout.PropertyField(mainSpeed);
            if (Target.lerpMode == LerpMode.Lerp)
            {
                EditorGUILayout.PropertyField(minSpeed);
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
        #endregion
    }
}
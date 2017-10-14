/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  LerpMeterEditor.cs
 *  Description  :  Editor for LerpMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

namespace Developer.Meter
{
    [CustomEditor(typeof(LerpMeter), true)]
    [CanEditMultipleObjects]
    public class LerpMeterEditor : MeterEditor
    {
        #region Property and Field
        protected new LerpMeter script { get { return target as LerpMeter; } }
        protected SerializedProperty minSpeed;
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            minSpeed = serializedObject.FindProperty("minSpeed");
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (script.lerpType == LerpType.Lerp)
            {
                EditorGUILayout.PropertyField(minSpeed);
                serializedObject.ApplyModifiedProperties();
            }
        }
        #endregion
    }
}
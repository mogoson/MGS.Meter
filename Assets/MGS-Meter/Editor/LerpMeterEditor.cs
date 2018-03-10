/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LerpMeterEditor.cs
 *  Description  :  Editor for LerpMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

namespace Developer.Meter
{
    [CustomEditor(typeof(LerpMeter), true)]
    [CanEditMultipleObjects]
    public class LerpMeterEditor : MeterEditor
    {
        #region Field and Property 
        protected new LerpMeter Target { get { return target as LerpMeter; } }
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

            if (Target.lerpType == LerpType.Lerp)
            {
                EditorGUILayout.PropertyField(minSpeed);
                serializedObject.ApplyModifiedProperties();
            }
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: LerpMeterEditor.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/4/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.        LerpMeterEditor           Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     4/4/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Meter
{
    using UnityEditor;

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
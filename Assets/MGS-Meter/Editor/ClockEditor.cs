/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  ClockEditor.cs
 *  Description  :  Editor for Clock component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Developer.Meter
{
    [CustomEditor(typeof(Clock), true)]
    [CanEditMultipleObjects]
    public class ClockEditor : MeterEditor
    {
        #region Property and Field
        protected new Clock script { get { return target as Clock; } }
        #endregion

        #region Protected Method
        protected override void OnSceneGUI()
        {
            DrawPointers(script.pointers);
        }

        protected void DrawPointers(Transform[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer)
                {
                    Handles.color = transparentBlue;
                    Handles.DrawSolidDisc(pointer.position, pointer.forward, areaRadius);
                    Handles.color = blue;
                    DrawSphereCap(pointer.position, Quaternion.identity, nodeSize);
                    DrawCircleCap(pointer.position, pointer.rotation, areaRadius);
                    DrawArrow(pointer.position, pointer.forward, arrowLength, nodeSize, "Axis", blue);
                    DrawArrow(pointer.position, pointer.up, areaRadius, nodeSize, string.Empty, blue);
                }
            }
        }
        #endregion
    }
}
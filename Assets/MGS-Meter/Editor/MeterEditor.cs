/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  MeterEditor.cs
 *  Description  :  Editor for Meter component.
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
    [CustomEditor(typeof(Meter), true)]
    [CanEditMultipleObjects]
    public class MeterEditor : Editor
    {
        #region Property and Field
        protected Meter script { get { return target as Meter; } }

        protected readonly Color blue = new Color(0, 1, 1, 1);
        protected readonly Color transparentBlue = new Color(0, 1, 1, 0.1f);

        protected const float nodeSize = 0.05f;
        protected const float arrowLength = 0.75f;
        protected const float areaRadius = 0.5f;
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            DrawPointers(script.pointers);
        }

        protected void DrawPointers(MPointer[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer.pTrans)
                {
                    Handles.color = transparentBlue;
                    Handles.DrawSolidDisc(pointer.pTrans.position, pointer.pTrans.forward, areaRadius);
                    Handles.color = blue;
                    DrawSphereCap(pointer.pTrans.position, Quaternion.identity, nodeSize);
                    DrawCircleCap(pointer.pTrans.position, pointer.pTrans.rotation, areaRadius);
                    DrawArrow(pointer.pTrans.position, pointer.pTrans.forward, arrowLength, nodeSize, "Axis", blue);
                    DrawArrow(pointer.pTrans.position, pointer.pTrans.up, areaRadius, nodeSize, string.Empty, blue);
                }
            }
        }

        protected void DrawArrow(Vector3 start, Vector3 direction, float length, float size, string text, Color color)
        {
            var gC = GUI.color;
            var hC = Handles.color;

            GUI.color = color;
            Handles.color = color;

            var end = start + direction * length;
            Handles.DrawLine(start, end);
            DrawSphereCap(end, Quaternion.identity, size);
            Handles.Label(end, text);

            GUI.color = gC;
            Handles.color = hC;
        }

        protected void DrawSphereCap(Vector3 position, Quaternion rotation, float size)
        {
#if UNITY_5_5_OR_NEWER
            Handles.SphereHandleCap(0, position, rotation, size, EventType.Ignore);
#else
            Handles.SphereCap(0, position, rotation, size);
#endif
        }

        protected void DrawCircleCap(Vector3 position, Quaternion rotation, float size)
        {
#if UNITY_5_5_OR_NEWER
            Handles.CircleHandleCap(0, position, rotation, size, EventType.Ignore);
#else
            Handles.CircleCap(0, position, rotation, size);
#endif
        }
        #endregion
    }
}
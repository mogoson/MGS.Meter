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

        protected void DrawPointers(MeterPointer[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer.pointerTrans)
                {
                    Handles.color = transparentBlue;
                    Handles.DrawSolidDisc(pointer.pointerTrans.position, pointer.pointerTrans.forward, areaRadius);

                    Handles.color = blue;
                    DrawSphereCap(pointer.pointerTrans.position, Quaternion.identity, nodeSize);
                    DrawCircleCap(pointer.pointerTrans.position, pointer.pointerTrans.rotation, areaRadius);
                    DrawArrow(pointer.pointerTrans.position, pointer.pointerTrans.forward, arrowLength, nodeSize, "Axis", blue);
                    DrawArrow(pointer.pointerTrans.position, pointer.pointerTrans.up, areaRadius, nodeSize, string.Empty, blue);
                }
            }
        }

        protected void DrawArrow(Vector3 start, Vector3 direction, float length, float size, string text, Color color)
        {
            var gColor = GUI.color;
            var hColor = Handles.color;

            GUI.color = color;
            Handles.color = color;

            var end = start + direction * length;
            Handles.DrawLine(start, end);
            DrawSphereCap(end, Quaternion.identity, size);
            Handles.Label(end, text);

            GUI.color = gColor;
            Handles.color = hColor;
        }

        protected void DrawSphereCap(Vector3 position, Quaternion rotation, float size)
        {
#if UNITY_5_5_OR_NEWER
            if (Event.current.type == EventType.Repaint)
                Handles.SphereHandleCap(0, position, rotation, size, EventType.Repaint);
#else
            Handles.SphereCap(0, position, rotation, size);
#endif
        }

        protected void DrawCircleCap(Vector3 position, Quaternion rotation, float size)
        {
#if UNITY_5_5_OR_NEWER
            if (Event.current.type == EventType.Repaint)
                Handles.CircleHandleCap(0, position, rotation, size, EventType.Repaint);
#else
            Handles.CircleCap(0, position, rotation, size);
#endif
        }
        #endregion
    }
}
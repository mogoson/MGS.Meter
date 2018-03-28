/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MeterEditor.cs
 *  Description  :  Editor for Meter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.EditorExtension;
using UnityEditor;
using UnityEngine;

namespace Mogoson.Meter
{
    [CustomEditor(typeof(Meter), true)]
    [CanEditMultipleObjects]
    public class MeterEditor : GenericEditor
    {
        #region Field and Property
        protected Meter Target { get { return target as Meter; } }

        protected new const float AreaRadius = 0.1f;
        protected new const float ArrowLength = 0.25f;
        protected new const float NodeSize = 0.02f;
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            foreach (var pointer in Target.pointers)
            {
                DrawPointer(pointer.pointerTrans);
            }
        }

        protected void DrawPointer(Transform pointer)
        {
            if (pointer)
            {
                Handles.color = TransparentBlue;
                Handles.DrawSolidDisc(pointer.position, pointer.forward, AreaRadius);

                Handles.color = Blue;
                DrawSphereCap(pointer.position, Quaternion.identity, NodeSize);
                DrawCircleCap(pointer.position, pointer.rotation, AreaRadius);
                DrawSphereArrow(pointer.position, -pointer.forward, ArrowLength, NodeSize, Blue, "Axis");
                DrawSphereArrow(pointer.position, pointer.up, AreaRadius, NodeSize, Blue, string.Empty);
            }
        }
        #endregion
    }
}
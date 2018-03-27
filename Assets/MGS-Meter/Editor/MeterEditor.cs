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
            DrawPointers(Target.pointers);
        }

        protected void DrawPointers(MeterPointer[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer.pointerTrans)
                {
                    Handles.color = TransparentBlue;
                    Handles.DrawSolidDisc(pointer.pointerTrans.position, pointer.pointerTrans.forward, AreaRadius);

                    Handles.color = Blue;
                    DrawSphereCap(pointer.pointerTrans.position, Quaternion.identity, NodeSize);
                    DrawCircleCap(pointer.pointerTrans.position, pointer.pointerTrans.rotation, AreaRadius);
                    DrawSphereArrow(pointer.pointerTrans.position, -pointer.pointerTrans.forward, ArrowLength, NodeSize, Blue, "Axis");
                    DrawSphereArrow(pointer.pointerTrans.position, pointer.pointerTrans.up, AreaRadius, NodeSize, Blue, string.Empty);
                }
            }
        }
        #endregion
    }
}
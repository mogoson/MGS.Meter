﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MeterEditor.cs
 *  Description  :  Editor for PointerMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Editors;
using UnityEditor;
using UnityEngine;

namespace MGS.Meter.Editors
{
    [CustomEditor(typeof(Meter), true)]
    [CanEditMultipleObjects]
    public class MeterEditor : SceneEditor
    {
        #region Field and Property
        protected Meter Target { get { return target as Meter; } }

        protected readonly Color AreaColor = new Color(1, 1, 1, 0.1f);
        protected readonly Color HandleColor = Color.white;
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            foreach (var pointer in Target.pointers)
            {
                DrawPointer(pointer);
            }
        }

        protected void DrawPointer(Transform pointer)
        {
            if (pointer)
            {
                Handles.color = AreaColor;
                DrawAdaptiveSolidDisc(pointer.position, pointer.forward, AreaRadius);

                Handles.color = HandleColor;
                DrawAdaptiveSphereCap(pointer.position, Quaternion.identity, NodeSize);
                DrawAdaptiveCircleCap(pointer.position, pointer.rotation, AreaRadius);

                DrawAdaptiveSphereArrow(pointer.position, -pointer.forward, ArrowLength, NodeSize, "Axis");
                DrawAdaptiveSphereArrow(pointer.position, pointer.up, AreaRadius, NodeSize);
            }
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: MeterEditor.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/4/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.         MeterEditor              Ignore.
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
    using UnityEngine;

    [CustomEditor(typeof(Meter), true)]
    [CanEditMultipleObjects]
    public class MeterEditor : Editor
    {
        #region Property and Field
        protected Color blue = new Color(0, 1, 1, 1);
        protected Color transparentBlue = new Color(0, 1, 1, 0.1f);
        protected float nodeSize = 0.05f;
        protected float arrowLength = 0.75f;
        protected float areaRadius = 0.5f;
        protected Meter script { get { return target as Meter; } }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            DrawPointers(script.pointers);
        }//OnSceneGUI()_end

        protected void DrawPointers(MPointer[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer.pTrans)
                {
                    Handles.color = transparentBlue;
                    Handles.DrawSolidDisc(pointer.pTrans.position, pointer.pTrans.forward, areaRadius);
                    Handles.color = blue;
                    Handles.SphereCap(0, pointer.pTrans.position, Quaternion.identity, nodeSize);
                    Handles.CircleCap(0, pointer.pTrans.position, pointer.pTrans.rotation, areaRadius);
                    DrawArrow(pointer.pTrans.position, pointer.pTrans.forward, arrowLength, nodeSize, "Axis", blue);
                    DrawArrow(pointer.pTrans.position, pointer.pTrans.up, areaRadius, nodeSize, string.Empty, blue);
                }
            }//foreach()_end
        }//DrawPointers()_end

        protected void DrawArrow(Vector3 start, Vector3 direction, float length, float size, string text, Color color)
        {
            var gC = GUI.color;
            var hC = Handles.color;

            GUI.color = color;
            Handles.color = color;

            var end = start + direction * length;
            Handles.DrawLine(start, end);
            Handles.SphereCap(0, end, Quaternion.identity, size);
            Handles.Label(end, text);

            GUI.color = gC;
            Handles.color = hC;
        }//DrawArrow()_end
        #endregion
    }//class_end
}//namespace_end
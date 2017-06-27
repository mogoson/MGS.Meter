/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: ClockEditor.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/4/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.         ClockEditor              Ignore.
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
        }//OnSceneGUI()_end

        protected void DrawPointers(Transform[] pointers)
        {
            foreach (var pointer in pointers)
            {
                if (pointer)
                {
                    Handles.color = transparentBlue;
                    Handles.DrawSolidDisc(pointer.position, pointer.forward, areaRadius);
                    Handles.color = blue;
                    Handles.SphereCap(0, pointer.position, Quaternion.identity, nodeSize);
                    Handles.CircleCap(0, pointer.position, pointer.rotation, areaRadius);
                    DrawArrow(pointer.position, pointer.forward, arrowLength, nodeSize, "Axis", blue);
                    DrawArrow(pointer.position, pointer.up, areaRadius, nodeSize, string.Empty, blue);
                }
            }//foreach()_end
        }//DrawPointers()_end
        #endregion
    }//class_end
}//namespace_end
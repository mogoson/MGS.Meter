/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson tech. Co., Ltd.
 *  FileName: Meter.cs
 *  Author: Mogoson   Version: 1.0   Date: 4/4/2016
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.             Meter                Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     4/4/2016       1.0        Build this file.
 *************************************************************************/

namespace Developer.Meter
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Meter Pointer.
    /// </summary>
    [Serializable]
    public struct MPointer
    {
        /// <summary>
        /// Transform of meter pointer.
        /// </summary>
        public Transform pTrans;

        /// <summary>
        /// Ratio of meter pointer.
        /// </summary>
        public float pRatio;
    }

    [AddComponentMenu("Developer/Meter/Meter")]
    public class Meter : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Pointers of meter.
        /// First is main pointer.
        /// </summary>
        public MPointer[] pointers;

        /// <summary>
        /// Pointers start angles.
        /// </summary>
        public Vector3[] startAngles { private set; get; }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        public float mainAngle
        {
            set
            {
                mAngle = value;
                OnMainAngleChanged();
            }
            get
            {
                return mAngle;
            }
        }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        protected float mAngle = 0;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            startAngles = new Vector3[pointers.Length];
            for (int i = 0; i < pointers.Length; i++)
            {
                startAngles[i] = pointers[i].pTrans.localEulerAngles;
            }
        }

        /// <summary>
        /// On main pointer's angle changed.
        /// </summary>
        protected virtual void OnMainAngleChanged()
        {
            SetPointersAngle(mAngle);
        }

        /// <summary>
        /// Set pointers angle.
        /// </summary>
        /// <param name="mainPointerAngle">Main pointer's angle.</param>
        protected void SetPointersAngle(float mainPointerAngle)
        {
            for (int i = 0; i < pointers.Length; i++)
            {
                var pAngle = mainPointerAngle * pointers[i].pRatio;
                var euler = startAngles[i] + Vector3.back * pAngle;
                pointers[i].pTrans.localRotation = Quaternion.Euler(euler);
            }
        }
        #endregion
    }
}
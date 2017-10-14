/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  Meter.cs
 *  Description  :  Define pointer meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Developer.Meter
{
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
        public MPointer[] pointers = { };

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
                var euler = startAngles[i] + Vector3.back * mainPointerAngle * pointers[i].pRatio;
                pointers[i].pTrans.localRotation = Quaternion.Euler(euler);
            }
        }
        #endregion
    }
}
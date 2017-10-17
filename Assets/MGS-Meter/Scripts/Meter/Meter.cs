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
    public class MeterPointer
    {
        /// <summary>
        /// Transform of meter pointer.
        /// </summary>
        public Transform pointerTrans;

        /// <summary>
        /// Ratio of meter pointer.
        /// </summary>
        public float pointerRatio = 1.0f;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MeterPointer() { }

        /// <summary>
        /// Constructor of MeterPointer.
        /// </summary>
        /// <param name="pTrans">Transform of meter pointer.</param>
        /// <param name="pRatio">Ratio of meter pointer.</param>
        public MeterPointer(Transform pointerTrans, float pointerRatio)
        {
            this.pointerTrans = pointerTrans;
            this.pointerRatio = pointerRatio;
        }
    }

    [AddComponentMenu("Developer/Meter/Meter")]
    public class Meter : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Pointers of meter.
        /// First is main pointer.
        /// </summary>
        public MeterPointer[] pointers = { };

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
                startAngles[i] = pointers[i].pointerTrans.localEulerAngles;
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
                var euler = startAngles[i] + Vector3.back * mainPointerAngle * pointers[i].pointerRatio;
                pointers[i].pointerTrans.localRotation = Quaternion.Euler(euler);
            }
        }
        #endregion
    }
}
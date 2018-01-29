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
    public struct MeterPointer
    {
        /// <summary>
        /// Transform of meter pointer.
        /// </summary>
        public Transform pointerTrans;

        /// <summary>
        /// Ratio of meter pointer.
        /// </summary>
        public float pointerRatio;

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
        public Vector3[] StartAngles { protected set; get; }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        public float MainAngle
        {
            set
            {
                mainPointerAngle = value;
                OnMainAngleChanged(mainPointerAngle);
            }
            get
            {
                return mainPointerAngle;
            }
        }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        protected float mainPointerAngle = 0;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            StartAngles = new Vector3[pointers.Length];
            for (int i = 0; i < pointers.Length; i++)
            {
                StartAngles[i] = pointers[i].pointerTrans.localEulerAngles;
            }
        }

        /// <summary>
        /// On main pointer's angle changed.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected virtual void OnMainAngleChanged(float mainAngle)
        {
            SetPointersAngle(mainAngle);
        }

        /// <summary>
        /// Set pointers angle.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected void SetPointersAngle(float mainAngle)
        {
            for (int i = 0; i < pointers.Length; i++)
            {
                var euler = StartAngles[i] + Vector3.back * mainAngle * pointers[i].pointerRatio;
                pointers[i].pointerTrans.localRotation = Quaternion.Euler(euler);
            }
        }
        #endregion
    }
}
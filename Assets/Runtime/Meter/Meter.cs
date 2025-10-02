/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Meter.cs
 *  Description  :  Define meter with pointers.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Meter with pointers.
    /// </summary>
    [AddComponentMenu("MGS/Meter/Meter")]
    public class Meter : MonoBehaviour, IMeter
    {
        #region Field and Property
        /// <summary>
        /// Pointers of meter.
        /// </summary>
        public Transform[] pointers;

        /// <summary>
        /// Pointers zero angles.
        /// </summary>
        public Vector3[] ZeroAngles { protected set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            ZeroAngles = new Vector3[pointers.Length];
            for (int i = 0; i < pointers.Length; i++)
            {
                ZeroAngles[i] = pointers[i].localEulerAngles;
            }
        }

        /// <summary>
        /// Set pointer rotation angle.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="angle"></param>
        protected void SetPointerAngle(int index, float angle)
        {
            var euler = ZeroAngles[index] + Vector3.back * angle;
            pointers[index].localRotation = Quaternion.Euler(euler);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh meter values.
        /// </summary>
        /// <param name="values"></param>
        public void Refresh(params float[] values)
        {
            var count = Mathf.Min(values.Length, pointers.Length);
            for (int i = 0; i < count; i++)
            {
                Refresh(i, values[i]);
            }
        }

        /// <summary>
        /// Refresh meter value.
        /// </summary>
        /// <param name="index">Index of part.</param>
        /// <param name="value">Value of part.</param>
        public virtual void Refresh(int index, float value)
        {
            SetPointerAngle(index, value);
        }
        #endregion
    }
}
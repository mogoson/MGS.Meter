/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMeter.cs
 *  Description  :  Define interface for meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Meter
{
    /// <summary>
    /// Interface for meter.
    /// </summary>
    public interface IMeter
    {
        /// <summary>
        /// Refresh meter values.
        /// </summary>
        /// <param name="values"></param>
        void Refresh(params float[] values);

        /// <summary>
        /// Refresh meter value.
        /// </summary>
        /// <param name="index">Index of part.</param>
        /// <param name="value">Value of part.</param>
        void Refresh(int index, float value);
    }
}
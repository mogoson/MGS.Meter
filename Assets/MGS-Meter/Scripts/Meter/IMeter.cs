/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMeter.cs
 *  Description  :  Define interface of meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Mogoson.Meter
{
    /// <summary>
    /// Interface of meter.
    /// </summary>
    public interface IMeter
    {
        /// <summary>
        /// Angle of meter main pointer.
        /// </summary>
        float MainAngle { set; get; }
    }
}
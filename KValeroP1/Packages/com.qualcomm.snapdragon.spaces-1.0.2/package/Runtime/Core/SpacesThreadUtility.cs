﻿/*
 * Copyright (c) Qualcomm Technologies, Inc. and/or its subsidiaries.
 * All rights reserved.
 * Confidential and Proprietary - Qualcomm Technologies, Inc.
 */

using UnityEngine;
using UnityEngine.XR.OpenXR;

namespace Qualcomm.Snapdragon.Spaces
{
    public static class SpacesThreadUtility
    {
        private static BaseRuntimeFeature _baseRuntimeFeature = null;

        /// <summary>
        ///    This must be called on main thread ahead of running SetThreadHint.
        ///    In the editor this must be called from the main thread before a stress-test sets thread hints for its threads.
        /// </summary>
        public static void InitFindBaseRuntime()
        {
            _baseRuntimeFeature = OpenXRSettings.ActiveBuildTargetInstance.GetFeature<BaseRuntimeFeature>();
        }

        /// <summary>
        ///     Set a <see cref="SpacesThreadType" /> for a running thread.
        ///     This will adjust its scheduling priority with OpenXR, and can potentially improve performance.
        ///     This method **must** be called from the thread to which the hint will be applied.
        ///     This method must be used with caution!
        ///     It is recommended to benchmark the performance change of applying this change.
        ///     Identifying a non-rendering thread as a rendering thread could adversely affect the performance of your
        ///     application.
        /// </summary>
        /// <param name="threadType">The thread type to assign for the running thread</param>
        public static void SetThreadHint(SpacesThreadType threadType)
        {
            if (!FeatureUseCheckUtility.IsFeatureUseable(_baseRuntimeFeature))
            {
#if !UNITY_EDITOR
                Debug.LogWarning("Unable to set thread hint because base runtime feature is not useable.");
#endif
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            _baseRuntimeFeature.SetThreadHint(threadType);
#endif
        }
    }
}

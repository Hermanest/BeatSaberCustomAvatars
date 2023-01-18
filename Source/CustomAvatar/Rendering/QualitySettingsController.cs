﻿//  Beat Saber Custom Avatars - Custom player models for body presence in Beat Saber.
//  Copyright © 2018-2023  Nicolas Gnyra and Beat Saber Custom Avatars Contributors
//
//  This library is free software: you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation, either
//  version 3 of the License, or (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using CustomAvatar.Configuration;
using UnityEngine;
using Zenject;

namespace CustomAvatar.Rendering
{
    internal class QualitySettingsController : IInitializable, IDisposable
    {
        private readonly Settings _settings;

        public QualitySettingsController(Settings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            QualitySettings.shadowDistance = 10;
            QualitySettings.shadowNearPlaneOffset = 3;
            QualitySettings.shadowProjection = ShadowProjection.StableFit;
            QualitySettings.shadowmaskMode = ShadowmaskMode.Shadowmask;

            QualitySettings.shadows = _settings.lighting.shadowQuality;
            QualitySettings.shadowResolution = _settings.lighting.shadowResolution;
            QualitySettings.pixelLightCount = _settings.lighting.pixelLightCount;

            _settings.skinWeights.changed += OnSkinWeightsChanged;
            OnSkinWeightsChanged(_settings.skinWeights);
        }

        public void Dispose()
        {
            _settings.skinWeights.changed -= OnSkinWeightsChanged;
        }

        private void OnSkinWeightsChanged(SkinWeights value)
        {
            QualitySettings.skinWeights = value;
        }
    }
}
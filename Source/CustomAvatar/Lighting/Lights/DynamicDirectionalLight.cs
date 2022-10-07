﻿//  Beat Saber Custom Avatars - Custom player models for body presence in Beat Saber.
//  Copyright © 2018-2022  Nicolas Gnyra and Beat Saber Custom Avatars Contributors
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

using UnityEngine;

namespace CustomAvatar.Lighting.Lights
{
    internal class DynamicDirectionalLight : MonoBehaviour
    {
        private static readonly Vector3 kOrigin = new Vector3(0, 1, 0);

        [SerializeField]
        private DirectionalLight _directionalLight;

        [SerializeField]
        private float _lightIntensityMultiplier;

        [SerializeField]
        private Light _light;

        private float _intensityFalloff;

        internal void Init(DirectionalLight directionalLight, float lightIntensityMultiplier)
        {
            _directionalLight = directionalLight;
            _lightIntensityMultiplier = lightIntensityMultiplier;
            _light = GetComponent<Light>();
        }

        private void Start()
        {
            float distance = Vector3.Distance(_directionalLight.transform.position, kOrigin);
            _intensityFalloff = Mathf.Max((_directionalLight.radius - distance) / _directionalLight.radius, 0);
        }

        private void Update()
        {
            float intensity = _intensityFalloff * _directionalLight.intensity * _lightIntensityMultiplier;

            _light.color = _directionalLight.color;
            _light.intensity = intensity;
            _light.enabled = intensity > 0.0001f;
        }
    }
}

//  Beat Saber Custom Avatars - Custom player models for body presence in Beat Saber.
//  Copyright � 2018-2023  Nicolas Gnyra and Beat Saber Custom Avatars Contributors
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
//  You should have received a copy of the GNU Lesser General Public
//  License along with this program.  If not, see <https://www.gnu.org/licenses/>.

using UnityEngine;
using UnityEngine.Events;

// keeping root namespace for compatibility
#pragma warning disable IDE1006
namespace CustomAvatar
{
    public class EventManager : MonoBehaviour
    {
        public UnityEvent OnSlice;
        public UnityEvent OnMiss;
        public UnityEvent OnBadCut;
        public UnityEvent OnComboUp;
        public UnityEvent OnComboBreak;
        public UnityEvent MultiplierUp;
        public UnityEvent MultiplierDown;
        public UnityEvent SaberStartColliding;
        public UnityEvent SaberStopColliding;
        public UnityEvent OnMenuEnter;
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelFail;
        public UnityEvent OnLevelFinish;
    }
}
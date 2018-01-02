﻿/*
 * Copyright 2014 - 2017 Adaptive Financial Consulting Ltd
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Runtime.CompilerServices;

namespace Adaptive.Agrona.Concurrent.Status
{
    public class AtomicLongPosition : IPosition
    {
        private readonly AtomicLong _value = new AtomicLong();

        public override void Dispose()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int Id()
        {
            return 0;
        }

        public override long Volatile => _value.Get();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override long Get()
        {
            return _value.Get();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Set(long value)
        {
            _value.Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void SetOrdered(long value)
        {
            _value.Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void SetVolatile(long value)
        {
            _value.Set(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool ProposeMax(long proposedValue)
        {
            return ProposeMaxOrdered(proposedValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool ProposeMaxOrdered(long proposedValue)
        {
            bool updated = false;

            if (Get() < proposedValue)
            {
                SetOrdered(proposedValue);
                updated = true;
            }

            return updated;
        }
    }
}
﻿using System;
using System.ComponentModel;
using System.Linq;

namespace PhilipDaubmeier.DigitalstromClient.Twin
{
    public abstract class AbstractState<T> : INotifyPropertyChanged
    {
        private PropertyChangedEventHandler _propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!(_propertyChanged?.GetInvocationList()?.Contains(value) ?? false))
                    _propertyChanged += value;
            }
            remove
            {
                _propertyChanged -= value;
            }
        }

        private PropertyChangedEventHandler _propertyChangedInternal;
        internal event PropertyChangedEventHandler PropertyChangedInternal
        {
            add
            {
                if (!(_propertyChangedInternal?.GetInvocationList()?.Contains(value) ?? false))
                    _propertyChangedInternal += value;
            }
            remove
            {
                _propertyChangedInternal -= value;
            }
        }

        public DateTime Timestamp { get; set; }

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Timestamp = DateTime.UtcNow;
                NotifyChanged();
            }
        }

        internal T ValueInternal
        {
            get { return _value; }
            set
            {
                _value = value;
                Timestamp = DateTime.UtcNow;
                NotifyChanged(false);
            }
        }

        private void NotifyChanged(bool useInternal = true)
        {
            var propertyChangedInternalHandler = _propertyChangedInternal;
            if (useInternal && propertyChangedInternalHandler != null)
                propertyChangedInternalHandler(this, new PropertyChangedEventArgs(nameof(Value)));

            var propertyChangedHandler = _propertyChanged;
            if (propertyChangedHandler == null)
                return;

            propertyChangedHandler(this, new PropertyChangedEventArgs(nameof(Value)));
            propertyChangedHandler(this, new PropertyChangedEventArgs(nameof(Timestamp)));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

namespace CC.Debug
{
    public class Require
    {
        public static Require That(object value, string name)
        {
            return new Require(value, name);
        }

        private readonly object _value;
        private readonly string _name;

        public Require(object value, string name)
        {
            _value = value;
            _name = name;
        }

        public Require IsNotNull()
        {
            isNotNull();

            return this;
        }

        public Require IsNotNullOrEmpty()
        {
            isNotNull();
            isNotEmpty();

            return this;
        }

        [Conditional("DEBUG")]
        private void isNotNull()
        {
            if (_value == null)
                throw new ArgumentException(string.Format("Argument [{0}] cannot be null.", _name));
        }

        [Conditional("DEBUG")]
        private void isNotEmpty()
        {
            if ((_value is string && (_value as string).Length == 0)
                || (_value is ICollection && (_value as ICollection).Count == 0))
            {
                throw new ArgumentException(string.Format("Argument [{0}] cannot be empty.", _name));
            }
        }
    }
}


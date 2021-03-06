﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TakeAsh;

namespace EnumHelperLib_Test {

    [TestFixture]
    public class FlagHelper_Test {

        [Flags]
        [HexDigit(2)]
        [TypeConverter(typeof(EnumTypeConverter<WDays>))]
        public enum WDays {
            None = 0x00,
            Sunday = 0x01,
            Monday = 0x02,
            Tuesday = 0x04,
            Wednesday = 0x08,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        private TypeConverter wDaysConverter = TypeDescriptor.GetConverter(typeof(WDays));

        [TestCase(WDays.None, "00")]
        [TestCase(WDays.Sunday, "01")]
        [TestCase(WDays.Monday, "02")]
        [TestCase(WDays.Tuesday, "04")]
        [TestCase(WDays.Wednesday, "08")]
        [TestCase(WDays.Thursday, "10")]
        [TestCase(WDays.Friday, "20")]
        [TestCase(WDays.Saturday, "40")]
        [TestCase(WDays.Sunday | WDays.Monday, "03")]
        [TestCase(WDays.Monday | WDays.Tuesday, "06")]
        [TestCase(WDays.Tuesday | WDays.Wednesday, "0C")]
        [TestCase(WDays.Wednesday | WDays.Thursday, "18")]
        [TestCase(WDays.Thursday | WDays.Friday, "30")]
        [TestCase(WDays.Friday | WDays.Saturday, "60")]
        [TestCase(WDays.Saturday | WDays.Sunday, "41")]
        [TestCase(WDays.None | WDays.Sunday | WDays.Monday | WDays.Tuesday | WDays.Wednesday | WDays.Thursday | WDays.Friday | WDays.Saturday, "7F")]
        public void ToHex_Test(WDays wday, string expect) {
            Assert.AreEqual(expect, wday.ToHex());
        }

        [TestCase(WDays.None, "00: None")]
        [TestCase(WDays.Sunday, "01: Sunday")]
        [TestCase(WDays.Monday, "02: Monday")]
        [TestCase(WDays.Tuesday, "04: Tuesday")]
        [TestCase(WDays.Wednesday, "08: Wednesday")]
        [TestCase(WDays.Thursday, "10: Thursday")]
        [TestCase(WDays.Friday, "20: Friday")]
        [TestCase(WDays.Saturday, "40: Saturday")]
        [TestCase(WDays.Sunday | WDays.Monday, "03: Sunday, Monday")]
        [TestCase(WDays.Monday | WDays.Tuesday, "06: Monday, Tuesday")]
        [TestCase(WDays.Tuesday | WDays.Wednesday, "0C: Tuesday, Wednesday")]
        [TestCase(WDays.Wednesday | WDays.Thursday, "18: Wednesday, Thursday")]
        [TestCase(WDays.Thursday | WDays.Friday, "30: Thursday, Friday")]
        [TestCase(WDays.Friday | WDays.Saturday, "60: Friday, Saturday")]
        [TestCase(WDays.Saturday | WDays.Sunday, "41: Sunday, Saturday")]
        [TestCase(WDays.None | WDays.Sunday | WDays.Monday | WDays.Tuesday | WDays.Wednesday | WDays.Thursday | WDays.Friday | WDays.Saturday, "7F: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
        public void ToHexWithFlag_Test(WDays wday, string expect) {
            Assert.AreEqual(expect, wday.ToHexWithFlag());
        }

        [TestCase(WDays.None, "00: None")]
        [TestCase(WDays.Sunday, "01: Sunday")]
        [TestCase(WDays.Monday, "02: Monday")]
        [TestCase(WDays.Tuesday, "04: Tuesday")]
        [TestCase(WDays.Wednesday, "08: Wednesday")]
        [TestCase(WDays.Thursday, "10: Thursday")]
        [TestCase(WDays.Friday, "20: Friday")]
        [TestCase(WDays.Saturday, "40: Saturday")]
        [TestCase(WDays.Sunday | WDays.Monday, "03: Sunday, Monday")]
        [TestCase(WDays.Monday | WDays.Tuesday, "06: Monday, Tuesday")]
        [TestCase(WDays.Tuesday | WDays.Wednesday, "0C: Tuesday, Wednesday")]
        [TestCase(WDays.Wednesday | WDays.Thursday, "18: Wednesday, Thursday")]
        [TestCase(WDays.Thursday | WDays.Friday, "30: Thursday, Friday")]
        [TestCase(WDays.Friday | WDays.Saturday, "60: Friday, Saturday")]
        [TestCase(WDays.Saturday | WDays.Sunday, "41: Sunday, Saturday")]
        [TestCase(WDays.None | WDays.Sunday | WDays.Monday | WDays.Tuesday | WDays.Wednesday | WDays.Thursday | WDays.Friday | WDays.Saturday, "7F: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
        public void TypeConverter_Test(WDays wday, string expect) {
            Assert.AreEqual(expect, wDaysConverter.ConvertToString(wday));
        }

        [TestCase(0x00, "00: None")]
        [TestCase(0x01, "01: Sunday")]
        [TestCase(0x02, "02: Monday")]
        [TestCase(0x04, "04: Tuesday")]
        [TestCase(0x08, "08: Wednesday")]
        [TestCase(0x10, "10: Thursday")]
        [TestCase(0x20, "20: Friday")]
        [TestCase(0x40, "40: Saturday")]
        [TestCase(0x03, "03: Sunday, Monday")]
        [TestCase(0x06, "06: Monday, Tuesday")]
        [TestCase(0x0c, "0C: Tuesday, Wednesday")]
        [TestCase(0x18, "18: Wednesday, Thursday")]
        [TestCase(0x30, "30: Thursday, Friday")]
        [TestCase(0x60, "60: Friday, Saturday")]
        [TestCase(0x41, "41: Sunday, Saturday")]
        [TestCase(0x7f, "7F: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
        public void ToFlag_Test(int wday, string expect) {
            var actual = wday.ToEnum<WDays>();
            Assert.AreEqual(expect, actual.ToHexWithFlag());
        }
    }
}

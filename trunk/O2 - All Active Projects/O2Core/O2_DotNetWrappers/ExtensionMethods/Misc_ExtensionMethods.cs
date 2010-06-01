﻿using System;
using O2.DotNetWrappers.Network;
using O2.DotNetWrappers.Windows;
using O2.Kernel;
using System.Drawing;
using O2.DotNetWrappers.DotNet;
using System.Windows.Forms;
using System.Threading;

namespace O2.DotNetWrappers.ExtensionMethods
{
    public static class Misc_ExtensionMethods
    {
        public static int sleep(this int sleepPeriod)
        {
            Thread.Sleep(sleepPeriod);
            return sleepPeriod;
        }
        
        public static bool isFalse(this bool value)
        {
            return value == false;
        }

        public static bool isTrue(this bool value)
        {
            return value == true;
        }

        public static bool and(this bool leftOperand, bool rightOperand)
        {
            return leftOperand && rightOperand;
        }

        public static bool or(this bool leftOperand, bool rightOperand)
        {
            return leftOperand || rightOperand;
        }

        public static bool not(this bool value)
        {
            return !value;
        }

        public static Bitmap bitmap(this string file)
        {
            if (file.fileExists())
                return new Bitmap(file);
            return null;
        }
    }
}
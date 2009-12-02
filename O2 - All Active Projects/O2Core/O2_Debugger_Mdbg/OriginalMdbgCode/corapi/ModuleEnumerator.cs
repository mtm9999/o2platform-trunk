// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
//---------------------------------------------------------------------
//  This file is part of the CLR Managed Debugger (mdbg) Sample.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//---------------------------------------------------------------------

using System;
using System.Collections;
using O2.Debugger.Mdbg.Debugging.CorDebug.NativeApi;
using O2.Debugger.Mdbg.Debugging.CorDebug.NativeApi;
using O2.Debugger.Mdbg.Debugging.CorDebug.NativeApi;

namespace O2.Debugger.Mdbg.Debugging.CorDebug
{
    /** Exposes an enumerator for Modules. */

    internal class CorModuleEnumerator : IEnumerable, IEnumerator, ICloneable
    {
        private readonly ICorDebugModuleEnum m_enum;
        private CorModule m_mod;

        internal CorModuleEnumerator(ICorDebugModuleEnum moduleEnumerator)
        {
            m_enum = moduleEnumerator;
        }

        //
        // ICloneable interface
        //

        #region ICloneable Members

        public Object Clone()
        {
            ICorDebugEnum clone = null;
            m_enum.Clone(out clone);
            return new CorModuleEnumerator((ICorDebugModuleEnum) clone);
        }

        #endregion

        //
        // IEnumerable interface
        //

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion

        //
        // IEnumerator interface
        //

        #region IEnumerator Members

        public bool MoveNext()
        {
            var a = new ICorDebugModule[1];
            uint c = 0;
            int r = m_enum.Next((uint) a.Length, a, out c);
            if (r == 0 && c == 1) // S_OK && we got 1 new element
                m_mod = new CorModule(a[0]);
            else
                m_mod = null;
            return m_mod != null;
        }

        public void Reset()
        {
            m_enum.Reset();
            m_mod = null;
        }

        public Object Current
        {
            get { return m_mod; }
        }

        #endregion
    } /* class ModuleEnumerator */
} /* namespace  */

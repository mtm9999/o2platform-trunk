// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace O2.Legacy.CoreLib.Xsd
{
    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class api_info
    {
        /// <remarks/>
        [XmlArrayItem("class", IsNullable = false)]
        public api_infoClass[] classes { get; set; }

        /// <remarks/>
        public object nonclassfunctions { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string language { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class api_infoClass
    {
        /// <remarks/>
        [XmlElement("method")]
        public api_infoClassMethod[] method { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string class_name { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string class_unique_id { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string package { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public bool final { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class api_infoClassMethod
    {
        /// <remarks/>
        [XmlArrayItem("called_function", IsNullable = false)]
        public api_infoClassMethodCalled_function[] called_functions { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string method_name { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public bool @protected { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public bool @static { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class api_infoClassMethodCalled_function
    {
        /// <remarks/>
        [XmlAttribute]
        public string function_name { get; set; }
    }
}

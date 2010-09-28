// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using System.Text;
using O2.Interfaces.O2Core;
using O2.Interfaces.O2Findings;
using O2.Kernel;
using O2.Kernel.ExtensionMethods;
using O2.DotNetWrappers.O2Findings;
using O2.DotNetWrappers.ExtensionMethods;
using O2.DotNetWrappers.Windows;
using O2.DotNetWrappers.Network;
using O2.DotNetWrappers.DotNet;
using O2.Views.ASCX;
using O2.External.SharpDevelop.AST;
using O2.External.SharpDevelop.ExtensionMethods;
using O2.External.SharpDevelop.Ascx;
//using O2.External.IE.ExtensionMethods;
//using O2.External.IE.Wrapper;
using O2.API.AST.CSharp;
using O2.API.AST.ExtensionMethods;
using O2.API.AST.ExtensionMethods.CSharp;
using ICSharpCode.TextEditor;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast; 
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Dom.CSharp;
using System.CodeDom;
using O2.Views.ASCX.O2Findings;
using O2.Views.ASCX.DataViewers;
using System.Security.Cryptography;

//O2Ref:O2_API_AST.dll

namespace O2.XRules.Database.Utils
{
	public static class ExtraMethodsToAddToO2CodeBase_IO
	{
		// Config
		public static string localScriptFile(this string file)
		{
			if (PublicDI.CurrentScript.valid())			
				return PublicDI.CurrentScript.directoryName().pathCombine(file);
			return null;
		}
		public static Dictionary<string,string> localConfig_Load(this string file)
		{
			var configFile = file.localScriptFile();
			if (configFile.fileExists())
				return configFile.configLoad();				
			return null;
		}	
		
		public static Dictionary<string,string> localConfig_Save(this Dictionary<string,string> dictionary, string file)
		{			
			var configFile = file.localScriptFile();				
			"Saving {0} items to file: {1}".info(dictionary.Count,configFile);
			return dictionary.configSave(configFile);				
		}	
		
		// Collections Dictionary<string,string>
		public static Dictionary<string,string> clear(this Dictionary<string,string> dictionary)
		{
			if (dictionary.notNull())
				dictionary.Clear();
			return dictionary;
		}
		
		//Processes ExtensionMethods API				
		
		public static Process getProcessWithWindowTitle(this string processName, string windowTitle)
		{
			foreach(var process in Processes.getProcessesCalled(processName))
				if (process.MainWindowTitle == windowTitle)
					return process;
				return null;
		}
	

		
	}	   
}
    	
		
		
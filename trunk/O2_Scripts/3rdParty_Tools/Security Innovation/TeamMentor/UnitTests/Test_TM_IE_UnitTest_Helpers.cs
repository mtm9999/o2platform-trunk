// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework; 
using O2.Kernel;
using O2.XRules.Database.APIs;
using O2.XRules.Database.Utils;
using O2.DotNetWrappers.Network;
using O2.DotNetWrappers.ExtensionMethods;
using O2.Kernel.ExtensionMethods;

//O2File:Test_TM_IE.cs
 
namespace O2.SecurityInnovation.TeamMentor
{	
	[TestFixture]
    public class Test_TM_IE_UnitTest_Helpers : Test_TM_IE
    {    	    	    	    	    	
    	public Test_TM_IE_UnitTest_Helpers()
		{
			var ieKey = "Test_TM_IE_WebSite";
			base.set_IE_Object(ieKey);	
			Assert.That(ie.notNull(), "ie object was null");	
		}
		
    	[Test]
    	public string GuiObjects_CreateMappingsTable()  
    	{								
			base.open("html_pages/_UnitTest_Helpers/GuiObjects_CreateMappingsTable.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_Loaded");			
			Assert.That(value.str()=="True","value was not True");
    		return "ok: open_IE_and_get_HomePage";    		
    	} 
    	    	
    	[Test]
    	public string GuiObjects_ViewFolderStructure()  
    	{								
			base.open("html_pages/_UnitTest_Helpers/GuiObjects_ViewFolderStructure.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_Loaded").str();			
			Assert.That(value.str()=="True","value was not True");
    		return "ok: open_IE_and_get_HomePage";    		
    	} 
    	
    	[Test]
    	public string GuiObjects_ViewFolderStructure_with_GuidandeItemsGuids()  
    	{								
			base.open("html_pages/_UnitTest_Helpers/GuiObjects_ViewFolderStructure_with_GuidandeItemsGuids.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_Loaded").str();			
			Assert.That(value.str()=="True","value was not True");
    		return "ok: open_IE_and_get_HomePage";    		
    	} 
    	
    	[Test]
    	public string LibrariesFoldersViews_And_GuidanceItems_Guids()  
    	{					
    		var guidanceItemsDiv_DEFAULT_VALUE = "GuidanceItems will go here";
			base.open("html_pages/_UnitTest_Helpers/LibrariesFoldersViews_And_GuidanceItems_Guids.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_Loaded").str();			
			Assert.That(value.str()=="True","value was not True");
			ie.eval("var guidanceItemsDiv = $('#guidanceItems').html()");
			var guidanceItemsDiv = ie.getJsVariable("guidanceItemsDiv").str();
			Assert.That(guidanceItemsDiv.notNull(), "guidanceItemsDiv was null");
			Assert.AreEqual(guidanceItemsDiv, guidanceItemsDiv_DEFAULT_VALUE, "guidanceItemsDiv default value");
			ie.eval("$('.library').eq(0).click()");
			ie.eval("var guidanceItemsDiv = $('#guidanceItems').html()");
			guidanceItemsDiv = ie.getJsVariable("guidanceItemsDiv").str();
			Assert.That(guidanceItemsDiv.contains("Showing") && guidanceItemsDiv.contains("GuidanceItems"), "guidanceItemsDiv didn't contain expected two words");			
    		return "ok: LibrariesFoldersViews_And_GuidanceItems_Guids";    		
    	} 

		[Test]
		public string LibrariesFoldersViews_And_GuidanceItems_Guids_Mode_B()  
    	{					    		
			base.open("html_pages/_UnitTest_Helpers/LibrariesFoldersViews_And_GuidanceItems_Guids_Mode_B.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_Loaded").str();			
			Assert.That(value.str()=="True","value was not True");
			ie.eval("var guidanceItemsDiv = $('#guidanceItems').html()");
			var guidanceItemsDiv = ie.getJsVariable("guidanceItemsDiv").str();
			Assert.That(guidanceItemsDiv.contains("Showing") && guidanceItemsDiv.contains("GuidanceItems"), "guidanceItemsDiv didn't contain expected two words");			

			return "ok: LibrariesFoldersViews_And_GuidanceItems_Guids_Mode_B";
		}
		
		[Test]
		public string SlickGrid_ViewUniqueStrings()  
    	{					    		
			base.open("html_pages/_UnitTest_Helpers/DataGrids/SlickGrid_View_UniqueStrings.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_SlickGridLoaded").str();			
			Assert.AreEqual		(value ,"True",															"value was not True");
			Assert.IsNotNull	(ie.getJsVariable("TM.testGrid"), 										"TM.testGrid");			
			Assert.AreEqual		(ie.getJsVariable("TM.testGrid.slickGridVersion").str(), "2.0a1",   	"TM.testGrid.slickGridVersion version didn't match");
			Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()"),							 	"TM.testGrid.getData");						
			Assert.That			(ie.getJsVariable("TM.testGrid.getData()") is IEnumerable, 				"TM.testGrid.getData not collection");						
			Assert.AreEqual		(ie.getJsVariable("TM.testGrid.getData()[0].id").str(), "0", 			"TM.testGrid.getData()[0].id should be 0");			
			Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].uniqueString"), 			"TM.testGrid.getData()[0].uniqueString");
			Assert.That			(ie.getJsVariable("TM.testGrid.getData()[0].uniqueString").str().isGuid(), 	"TM.testGrid.getData()[0].uniqueString should be a guid");
			return "ok: DataGrids_SlickGrid_ViewUniqueStrings";
		}		
		
		[Test]
		public string SlickGrid_View_GuidandeItemsMappings()  
    	{					    		
			base.open("html_pages/_UnitTest_Helpers/DataGrids/SlickGrid_View_GuidandeItemsMappings.html?time=" + DateTime.Now.Ticks);										
			var value = ie.waitForJsVariable("UnitTest_Helper_SlickGridLoaded").str();						
			Assert.AreEqual		(value ,"True",	"UnitTest_Helper_SlickGridLoaded value was not True");
			Assert.IsNotNull	(ie.getJsVariable("TM.testGrid"), 									"TM.testGrid");			
			Assert.AreEqual		(ie.getJsVariable("TM.testGrid.slickGridVersion").str(), "2.0a1",   "TM.testGrid.slickGridVersion version didn't match");
			Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()"),							"TM.testGrid.getData");						
			Assert.That			(ie.getJsVariable("TM.testGrid.getData()") is IEnumerable, 			"TM.testGrid.getData not collection");									
			
			Action testIfTableIsEmpty = 
				()=>{
						Assert.IsNull		(ie.getJsVariable("TM.testGrid.getData()[0]"), 						"TM.testGrid.getData()[0] should be null here");
					};
					
			Action testIfRowsHaveData = 
				()=>{			
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0]"), 						"TM.testGrid.getData()[0] should NOT be null here");
						Assert.AreEqual		(ie.getJsVariable("TM.testGrid.getData()[0].Id").str(), "0", 		"TM.testGrid.getData()[0].Id should be 0");			
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].MappingIndexes"), 		"TM.testGrid.getData()[0].MappingIndexes");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Guid"), 				"TM.testGrid.getData()[0].Guid");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].LibraryId"), 			"TM.testGrid.getData()[0].LibraryId should be a guid");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Title"), 				"TM.testGrid.getData()[0].Title");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Technology"), 			"TM.testGrid.getData()[0].Technology");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Phase"), 				"TM.testGrid.getData()[0].Phase");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Type"), 				"TM.testGrid.getData()[0].Type");
						Assert.IsNotNull	(ie.getJsVariable("TM.testGrid.getData()[0].Category"), 			"TM.testGrid.getData()[0].Category");
					};	
			
			testIfTableIsEmpty();
			
			ie.eval("loadDataUsingUniqueStrings()");					
			testIfRowsHaveData();			
			
			ie.eval("clearTable()");
			testIfTableIsEmpty();
			
			ie.eval("loadDataUsingMappedData()");
			testIfRowsHaveData();
			
			return "ok: SlickGrid_View_GuidandeItemsMappings";
		}	
		
		[Test]
		public string DataTable_View_GuidanceItemsMappings()  
    	{					    		
			base.open("html_pages/_UnitTest_Helpers/DataGrids/DataTable_View_GuidanceItemsMappings.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_DataTable").str();			
			Assert.That(value.str()=="True","value was not True");
			return "ok: DataTable_View_GuidanceItemsMappings";
		}


		[Test]
		public string AppliedFilters_View_All_GuidanceItems()  
    	{					    		
			base.open("html_pages/_UnitTest_Helpers/AppliedFilters_View_All_GuidanceItems.html?time=" + DateTime.Now.Ticks); 						
			var value = ie.waitForJsVariable("UnitTest_Helper_AppliedFilters").str();			
			Assert.That(value.str()=="True","UnitTest_Helper_AppliedFilters value was not True");
			ie.eval("showFiltersWithCurrentData()");
			Assert.IsNotNull	(ie.getJsVariable("$('#pivotPanel_Technology input')"), 		"#pivotPanel_Technology input");
			Assert.That			(ie.getJsVariable("$('#pivotPanel_Technology input').length").str().toInt() > 0 ,  "pivotPanel_Technology input').length < 1");
			//$("#pivotPanel_Technology input").length
			return "ok: DataTable_View_GuidanceItemsMappings";
		}



    	
    	
    	
    	[Test]
    	public string close_IE()
    	{
    		Test_TM.CLOSE_BROWSER_IN_SECONDS = 4;
    		base.close_IE_Object();    		
    		return "ok: close_IE (in {0} seconds)".format(Test_TM.CLOSE_BROWSER_IN_SECONDS)
    					.jQuery_Append_Body(ie);
    	}
    	
    	
    }
}
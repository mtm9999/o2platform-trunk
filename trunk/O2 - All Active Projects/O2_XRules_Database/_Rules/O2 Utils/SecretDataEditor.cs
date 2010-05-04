using System;
using System.Windows.Forms;
using O2.Kernel.ExtensionMethods;
using O2.DotNetWrappers.ExtensionMethods;
using O2.Views.ASCX.ExtensionMethods;
using O2.Views.ASCX.classes.MainGUI;
using O2.XRules.Database._Rules._Interfaces;

namespace O2.XRules.Database.O2Utils
{
    public class SecretDataEditor
    {
        public static string showGui()
        {
            var panel = O2Gui.open<Panel>
              ("Secret Data Files", 750, 200);
            panel.clear();
            var userDataDirectory = "C:\\O2\\_USERDATA";
            var controls = panel.add_1x1("Folder with secret data files", "SecretData", true, 200);
            var directory = controls[0].add_Directory(userDataDirectory);
            if (userDataDirectory.files().size() == 0)
                new SecretData().serialize(userDataDirectory.pathCombine("SecretData.xml"));


            directory.afterFileSelect(selectedFile =>
            {
                controls[1].clear();
                try
                {
                    var dataGridView = controls[1].add_DataGridView();
                    dataGridView.AllowUserToAddRows = true;
                    dataGridView.AllowUserToDeleteRows = true;
                    dataGridView.add_Columns(typeof(Credential));

                    var secretData = selectedFile.deserialize<SecretData>
                      ();
                    dataGridView.add_Rows(secretData.Credentials);

                    var contextMenu = dataGridView.add_ContextMenu();
                    contextMenu.add_MenuItem("Save", () =>
                    {
                        secretData = new SecretData();
                        foreach (var row in dataGridView.rows())
                            if ((row[0] as string).valid())
                                secretData.Credentials.createTypeAndAddToList<Credential>(
								row[0],
								row[1],
								row[2],
								row[3],
								row[4]);
                        secretData.serialize(selectedFile);
                    });
                    contextMenu.add_MenuItem("New File (called RenameME.xml)", () =>
                    {
                        secretData = new SecretData();
                        selectedFile = directory.getCurrentDirectory().pathCombine("RenameME.xml");
                        secretData.serialize(selectedFile);
                    });

                }
                catch (Exception ex)
                {
                    controls[1].clear();
                    controls[1].add_TextBox(true).set_Text("Error loading select file: {0}".format(ex.Message));
                }
            });
            return "done";
        }
    }
}
//O2Ref:System.Data.dll
//O2File:C:\_O2_SVN\O2 - All Active Projects\O2_XRules_Database\_Rules\_Interfaces\ISecretData.cs 

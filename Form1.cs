using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiemensToIgnitionTagConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTIATagList_Click(object sender, EventArgs e)
        {
            if (openFileDialogTIATagList.ShowDialog() == DialogResult.OK)
            {
                textBoxTIATagList.Text = openFileDialogTIATagList.FileName;
            }
        }

        private void buttonSaveIgnitionTagList_Click(object sender, EventArgs e)
        {
            if (textBoxTIATagList.TextLength<1)
            {
                MessageBox.Show("TIA Tag List can not be empty");
            }
            else if (textBoxIgnitionFolderName.TextLength < 1)
            {
                MessageBox.Show("Ignition Folder Name can not be empty");
            }
            else if (textBoxIgnitionOPCConnectionName.TextLength < 1)
            {
                MessageBox.Show("Ignition OPC Connection Name can not be empty");
            }
            else if (saveFileDialogSaveIgnitionTagList.ShowDialog() == DialogResult.OK)
            {
                BuildJSONFile(saveFileDialogSaveIgnitionTagList.FileName);
                MessageBox.Show("JSON-file saved");
            }
        }

        private void BuildJSONFile(string savePath)
        {
            string[] lines = System.IO.File.ReadAllLines(textBoxTIATagList.Text);
            string last = lines.Last();
            string first = lines.First();

            using (StreamWriter writer = new StreamWriter(savePath))
            {
                writer.WriteLine("{");
                writer.WriteLine("  \"name\": \"" + textBoxIgnitionFolderName.Text + "\",");
                writer.WriteLine("  \"tagType\": \"Folder\",");
                writer.WriteLine("  \"tags\": [");
                //TODO: Get all tags from csv and convert them to JSON format


                foreach(string line in lines)
                {
                    if (line.Equals(first))
                    {
                        continue;
                    }
                    else
                    {
                        string[] columns = line.Split(';');
                        writer.WriteLine("    {");
                        writer.WriteLine("      \"valueSource\": \"opc\",");
                        string adressString = columns[3].Remove(0,1);
                        string nameString = columns[0];

                        //searching for some illegal characters
                        while (nameString.Contains('.'))
                        {
                           nameString = nameString.Replace('.', '_');
                            //int place = nameString.IndexOf('.')
                            //nameString.Remove(place, 1).Insert(place, '_');
                        }

                        while (nameString.Contains('/'))
                        {
                            nameString = nameString.Replace('/', '_');
                        }
                        
                        if (adressString.Contains('.'))
                        {
                            //bit access is being used. Ignition needs an X in the adressing.
                            string numbers = string.Empty;
                            string letters = string.Empty;
                            for (int i = 0; i < adressString.Length; i++)
                            {
                                if (Char.IsDigit(adressString[i]) || Char.Equals(adressString[i], '.'))
                                {
                                    numbers += adressString[i];
                                }
                                else
                                {
                                    letters += adressString[i];
                                }
                            }
                            letters += 'X';

                            adressString = letters + numbers;
                        }

                        writer.WriteLine("      \"opcItemPath\": \"[" + textBoxIgnitionOPCConnectionName.Text + "]" + adressString + "\",");

                        switch (columns[2])
                        {
                            case "Word":
                                
                                writer.WriteLine("      \"dataType\": \"" + "Int4" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Real":
                                writer.WriteLine("      \"dataType\": \"" + "Float4" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Int":
                                writer.WriteLine("      \"dataType\": \"" + "Int4" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Bool":
                                writer.WriteLine("      \"dataType\": \"" + "Boolean" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Time":
                                writer.WriteLine("      \"dataType\": \"" + "DateTime" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Byte":
                                writer.WriteLine("      \"dataType\": \"" + "Int1" + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;


                            default:
                                writer.WriteLine("      \"dataType\": \"" + columns[2] + "\",");//TODO correlate TIA datatype with Ignition Datatype
                                break;
                        }

                        
                        writer.WriteLine("      \"name\": \"" + nameString + "\",");
                        writer.WriteLine("      \"tagType\": \"AtomicTag\",");
                        writer.WriteLine("      \"opcServer\": \"Ignition OPC UA Server\"");
                        if (line.Equals(last))
                        {
                            writer.WriteLine("    }");
                        }
                        else
                        {
                            writer.WriteLine("    },");
                        }
                    }
                }



                writer.WriteLine("  ]");
                writer.WriteLine("}");
            }
        }
    }
}

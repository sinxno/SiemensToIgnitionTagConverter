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
                        string adressString = columns[3].Remove(0,1); //Removes the % from the adress
                        string nameString = columns[0];
                        string ignitionJSONNameString = String.Empty;
                        //searching for some illegal characters in the name
                        while (nameString.Contains('.'))
                        {
                           nameString = nameString.Replace('.', '_');
                        }

                        while (nameString.Contains('/'))
                        {
                            nameString = nameString.Replace('/', '_');
                        }

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
                        if (letters.Length>1)
                        {
                            letters = letters.Remove(1); //Only keep the first letter defining if it is an Input, Output, Memory etc..
                        }
                        

                        if (adressString.Contains('.'))
                        {
                            //bit access is being used. Ignition needs an X in the adressing.
                            
                            
                            letters += 'X';

                        }

                        

                        switch (columns[2])
                        {
                            case "Word":
                                letters += 'W';
                                ignitionJSONNameString="      \"dataType\": \"" + "Int4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Real":
                                letters += "REAL";
                                ignitionJSONNameString = "      \"dataType\": \"" + "Float4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Int":
                                letters += 'I';
                                ignitionJSONNameString = "      \"dataType\": \"" + "Int4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Bool":
                                ignitionJSONNameString = "      \"dataType\": \"" + "Boolean" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Time":
                                ignitionJSONNameString = "      \"dataType\": \"" + "DateTime" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Byte":
                                letters += 'B';
                                ignitionJSONNameString = "      \"dataType\": \"" + "Int1" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "Char":
                                letters += 'C';
                                ignitionJSONNameString = "      \"dataType\": \"" + "String" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "DWord":
                                letters += 'D';
                                ignitionJSONNameString = "      \"dataType\": \"" + "Int8" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "DInt":
                                letters += "DI";
                                ignitionJSONNameString = "      \"dataType\": \"" + "Int8" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;

                            case "String":
                                letters += "STRING";
                                ignitionJSONNameString = "      \"dataType\": \"" + "String" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;


                            default:
                                ignitionJSONNameString = "      \"dataType\": \"" + "Boolean" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                                break;
                        }

                        adressString = letters + numbers;

                        writer.WriteLine("      \"opcItemPath\": \"[" + textBoxIgnitionOPCConnectionName.Text + "]" + adressString + "\",");
                        writer.WriteLine(ignitionJSONNameString);


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

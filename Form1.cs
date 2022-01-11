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
                if (!checkBoxDB.Checked) //if the tag list is standard memory and IO tags
                {
                    int noOfTags = BuildJSONFile(saveFileDialogSaveIgnitionTagList.FileName);
                    MessageBox.Show("JSON-file saved.\n" +
                        "Exported " + noOfTags + " Tags");
                }
                else //the tag list is referencing an DB
                {
                    int noOfTags = BuildJSONFileDB(saveFileDialogSaveIgnitionTagList.FileName);
                    MessageBox.Show("DB JSON-file saved.\n" +
                        "Exported " + noOfTags + " Tags");
                }
                
            }
        }

        private int BuildJSONFile(string savePath)
        {
            //TODO: IMPLEMENT SUPPORT FOR XLS files
            string[] lines = System.IO.File.ReadAllLines(textBoxTIATagList.Text);
            string last = lines.Last();
            string first = lines.First();
            int numberOfTags = 0;
            //TODO: IMPLEMENT SUPPORT FOR COMMA DELIMITED CSVs
            if (lines[0].Contains(';'))
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    JSONFileStartSegment(writer);
                    //TODO: Get all tags from csv and convert them to JSON format
                    //TODO: IMPLEMENT SUPPORT FOR DB TAGS

                    //TODO: IMPLEMENT SUPPORT FOR DUTs


                    foreach (string line in lines)
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
                            string adressString = columns[3].Remove(0, 1); //Removes the % from the adress
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
                            if (letters.Length > 1)
                            {
                                letters = letters.Remove(1); //Only keep the first letter defining if it is an Input, Output, Memory etc..
                            }


                            if (adressString.Contains('.'))
                            {
                                //bit access is being used. Ignition needs an X in the adressing.


                                letters += 'X';

                            }



                            var dataType = DataTypeSelector(columns[2]);
                            letters += dataType.letter;
                            ignitionJSONNameString = dataType.ignitionJSONNameString;

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

                            numberOfTags++;

                        }
                    }



                    writer.WriteLine("  ]");
                    writer.WriteLine("}");
                }
            }
            else
            {
                MessageBox.Show("CSV file is not formatted correctly!\n" +
                    "Make sure it uses ';' as delimiter.");
            }

            

            return numberOfTags;
        }

        

        private void checkBoxDB_CheckedChanged(object sender, EventArgs e)
        {
            labelDBNumber.Visible = checkBoxDB.Checked;
            textBoxDBNumber.Visible = checkBoxDB.Checked;
        }

        private int BuildJSONFileDB(string savePath)
        {
            string[] lines = System.IO.File.ReadAllLines(textBoxTIATagList.Text);
            string last = lines.Last();
            string first = lines.First();
            int numberOfTags = 0;
            //TODO: IMPLEMENT SUPPORT FOR COMMA DELIMITED CSVs
            if (lines[0].Contains(';'))
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    JSONFileStartSegment(writer);

                    //TODO: Get all tags from csv and convert them to JSON format
                    //TODO: IMPLEMENT SUPPORT FOR DB TAGS

                    //TODO: IMPLEMENT SUPPORT FOR DUTs


                    foreach (string line in lines)
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
                            string adressString = columns[2];
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

                            string letters = "DB"+textBoxDBNumber.Text+",";
                            

                            if (columns[1].Contains("Bool"))
                            {
                                //bit access is being used. Ignition needs an X in the adressing.

                                letters += 'X';
                                
                            }
                            else
                            {
                                //remove .0 from offset
                                columns[2] = columns[2].Remove(columns[2].IndexOf('.'));
                            }

                            var dataType = DataTypeSelector(columns[1]);
                            letters += dataType.letter;
                            ignitionJSONNameString = dataType.ignitionJSONNameString;

                            
                            adressString = letters + columns[2];

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

                            numberOfTags++;

                        }
                    }

                    writer.WriteLine("  ]");
                    writer.WriteLine("}");
                }
            }
            else
            {
                MessageBox.Show("CSV file is not formatted correctly!\n" +
                    "Make sure it uses ';' as delimiter.");
            }

            return numberOfTags;
        }

        private void JSONFileStartSegment(StreamWriter writer)
        {
            writer.WriteLine("{");
            writer.WriteLine("  \"name\": \"" + textBoxIgnitionFolderName.Text + "\",");
            writer.WriteLine("  \"tagType\": \"Folder\",");
            writer.WriteLine("  \"tags\": [");
        }

        private (string letter, string ignitionJSONNameString) DataTypeSelector(string column)
        {
            string dataLetter = String.Empty;
            string JSONNameString = String.Empty;

            switch (column)
            {
                case "Word":
                    dataLetter += 'W';
                    JSONNameString = "      \"dataType\": \"" + "Int4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Real":
                    dataLetter += "REAL";
                    JSONNameString = "      \"dataType\": \"" + "Float4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Int":
                    dataLetter += 'I';
                    JSONNameString = "      \"dataType\": \"" + "Int4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Bool":
                    JSONNameString = "      \"dataType\": \"" + "Boolean" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Time":
                    dataLetter += 'I';
                    JSONNameString = "      \"dataType\": \"" + "Int4" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Byte":
                    dataLetter += 'B';
                    JSONNameString = "      \"dataType\": \"" + "Int1" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "Char":
                    dataLetter += 'C';
                    JSONNameString = "      \"dataType\": \"" + "String" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "DWord":
                    dataLetter += 'D';
                    JSONNameString = "      \"dataType\": \"" + "Int8" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "DInt":
                    dataLetter += "DI";
                    JSONNameString = "      \"dataType\": \"" + "Int8" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;

                case "String":
                    dataLetter += "STRING";
                    JSONNameString = "      \"dataType\": \"" + "String" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;


                default:
                    JSONNameString = "      \"dataType\": \"" + "Boolean" + "\",";//TODO correlate TIA datatype with Ignition Datatype
                    break;
            }


            return (dataLetter, JSONNameString);
        }


    }
}

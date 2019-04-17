using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.database
{
    public class dbFormat
    {
        public string Name { get; set; }
        public int AmountOfItems { get; set; }
        public int AmountOfColumns { get; set; }
        public int Start { get; set; }
        public List<string> types { get; set; }

        public string path = Path.Combine(Environment.CurrentDirectory, "DataBaseFormat.dat");

        public void CreateTable(string name, int colums, List<string> param)
        {
            try
            {
                var formats = new List<dbFormat>();
                int AmountOfTable = 0;
                bool empty = true;

                //read data about tables
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        AmountOfTable = reader.ReadInt32();

                        for (int i = 0; i < AmountOfTable; i++)
                        {
                            var format = new dbFormat();
                            format.types = new List<string>();
                            format.Name = reader.ReadString();
                            format.AmountOfItems = reader.ReadInt32();
                            format.Start = reader.ReadInt32();
                            format.AmountOfColumns = reader.ReadInt32();
                            for (int k = 0; k < format.AmountOfColumns; k++)
                            {
                                format.types.Add(reader.ReadString()); // types of column. order is important
                            }
                            formats.Add(format);
                        }

                        empty = false;
                        break;
                    }
                }

                if (empty)
                {
                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
                    {
                        writer.Write(1); //amount of tables
                        writer.Write(name); //name of table 
                        writer.Write(0); //amount of items in table 
                        writer.Write(0); //table start from
                        writer.Write(colums); //amount of columns 
                        for (int i = 0; i < param.Count; i++)
                        {
                            writer.Write(param[i]); // types of column. order is important
                        }
                    }
                }
                else
                {
                    string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBaseFormat.dat");

                    FileStream fs = new FileStream("NewDataBaseFormat.dat", FileMode.CreateNew);
                    fs.Close();
                    fs.Dispose();

                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(newPath)))
                    {
                        writer.Write(AmountOfTable + 1); //amount of tables
                        for (int i = 0; i < AmountOfTable; i++)
                        {
                            writer.Write(formats[i].Name); //name of table 
                            writer.Write(formats[i].AmountOfItems); //amount of items in table
                            writer.Write(formats[i].Start); //table start from
                            writer.Write(formats[i].AmountOfColumns); //amount of columns 
                            for (int j = 0; j < formats[i].types.Count; j++)
                            {
                                writer.Write(formats[i].types[j]); // types of column. order is important
                            }
                        }
                        writer.Write(name); //name of table 
                        writer.Write(0); //amount of items in table
                        writer.Write(formats[AmountOfTable - 1].Start + formats[AmountOfTable - 1].AmountOfItems + 1); //table start from
                        writer.Write(colums); //amount of columns 
                        for (int j = 0; j < param.Count; j++)
                        {
                            writer.Write(param[j]); // types of column. order is important
                        }
                    }

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "backupFormat.dat"));
                    File.Move("DataBaseFormat.dat", "backupFormat.dat");
                    File.Delete(path);
                    File.Move("NewDataBaseFormat.dat", "DataBaseFormat.dat");
                    File.Delete(newPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ChangeFormat(string type)
        {
            string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBase.dat");
            try
            {
                FileStream fs = new FileStream("NewDataBase.dat", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();

                var formats = new List<dbFormat>();
                int AmountOfTable = 0;

                //read data about tables
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    AmountOfTable = reader.ReadInt32();

                    for (int i = 0; i < AmountOfTable; i++)
                    {
                        var format = new dbFormat();
                        format.Name = reader.ReadString();
                        format.AmountOfItems = reader.ReadInt32();
                        format.Start = reader.ReadInt32();
                        formats.Add(format);
                    }
                }

                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
                {
                    writer.Write(AmountOfTable);
                    for (int i = 0; i < AmountOfTable; i++)
                    {
                        writer.Write(formats[i].Name);
                        if (formats[i].Name == "f")
                            writer.Write(formats[i].AmountOfItems + 1);
                        writer.Write(formats[i].Start + 1);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, "backup.dat"));
                File.Move("DataBase.dat", "backup.dat");
                File.Delete(path);
                File.Move("NewDataBase.dat", "DataBase.dat");
                File.Delete(newPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

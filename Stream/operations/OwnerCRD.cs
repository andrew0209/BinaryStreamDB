using Stream.interfaces;
using Stream.models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.operations
{
    class OwnerCRD : ICRD<Owner>
    {
        private string TableName { get; set; }

        public OwnerCRD(string name)
        {
            TableName = name;
        }

        public string path = Path.Combine(Environment.CurrentDirectory, "DataBase.dat");
        public void Delete(int id)
        {
            string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBase.dat");
            try
            {
                FileStream fs = new FileStream("NewDataBase.dat", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();

                string tableN = string.Empty;
                int ID = 0;
                bool write = false;
                int current = 0;
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                //Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (write)
                                {
                                    using (BinaryWriter writer = new BinaryWriter(File.Open(newPath, FileMode.Append)))
                                    {
                                        writer.Write('S');
                                        writer.Write(reader.ReadString());
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                tableN = reader.ReadString();
                                break;
                            case 'I': // int32
                                if (current == 0)
                                {
                                    ID = reader.ReadInt32();
                                    if (ID == id)
                                    {
                                        write = false;
                                        tableN = string.Empty;
                                    }
                                    else
                                    {
                                        write = true;
                                        using (BinaryWriter writer = new BinaryWriter(File.Open(newPath, FileMode.Append)))
                                        {
                                            writer.Write('T');
                                            writer.Write(tableN);
                                            writer.Write('I');
                                            writer.Write(ID);
                                            tableN = string.Empty;
                                            current++;
                                        }
                                    }
                                    ID = 0;
                                }
                                else
                                {
                                    if (write)
                                    {
                                        using (BinaryWriter writer = new BinaryWriter(File.Open(newPath, FileMode.Append)))
                                        {
                                            writer.Write('I');
                                            writer.Write(reader.ReadInt32());
                                        }
                                    }
                                    else
                                    {
                                        reader.ReadInt32();
                                    }
                                }
                                break;
                            case 'E': // string end of table
                                if (write)
                                {
                                    using (BinaryWriter writer = new BinaryWriter(File.Open(newPath, FileMode.Append)))
                                    {
                                        writer.Write('E');
                                        writer.Write(reader.ReadString());
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
                        }
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

        public List<Owner> GetAll()
        {
            try
            {
                var owners = new List<Owner>();
                bool writeToOwner = false;
                int current = 0;
                var owner = new Owner();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (writeToOwner)
                                {
                                    switch (current)
                                    {
                                        case 1:
                                            owner.FirstName = reader.ReadString();
                                            current++;
                                            break;
                                        case 2:
                                            owner.LastName = reader.ReadString();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                if (reader.ReadString().Equals(TableName))
                                {
                                    writeToOwner = true;
                                }
                                else
                                {
                                    writeToOwner = false;
                                }
                                break;
                            case 'I': // int32
                                if (writeToOwner)
                                {
                                    switch (current)
                                    {
                                        case 0:
                                            owner.Id = reader.ReadInt32();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadInt32();
                                }
                                break;
                            case 'E': // string end of table
                                if (reader.ReadString() == "%end%")
                                {
                                    if (writeToOwner)
                                    {
                                        owners.Add(owner);
                                        owner = new Owner();
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unexpected error");
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
                        }
                    }
                }

                return owners;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Owner GetByID(int id)
        {
            try
            {
                var owner = new Owner();
                bool writeToOwner = false;
                int current = 0;
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        char fieldType = reader.ReadChar();
                        switch (fieldType)
                        {
                            case 'C': // char
                                Console.WriteLine(reader.ReadChar());
                                break;
                            case 'S': // string
                                if (writeToOwner)
                                {
                                    switch (current)
                                    {
                                        case 1:
                                            owner.FirstName = reader.ReadString();
                                            current++;
                                            break;
                                        case 2:
                                            owner.LastName = reader.ReadString();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadString();
                                }
                                break;
                            case 'T': // string name of table
                                if (reader.ReadString() == TableName)
                                {
                                    writeToOwner = true;
                                }
                                else
                                {
                                    writeToOwner = false;
                                }
                                break;
                            case 'I': // int32
                                if (writeToOwner)
                                {
                                    switch (current)
                                    {
                                        case 0:
                                            owner.Id = reader.ReadInt32();
                                            current++;
                                            break;
                                    }
                                }
                                else
                                {
                                    reader.ReadInt32();
                                }
                                break;
                            case 'E': // string end of table
                                if (reader.ReadString() == "%end%")
                                {
                                    if (owner.Id == id)
                                    {
                                        return owner;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unexpected error");
                                }
                                current = 0;
                                break;
                            default: // unexpected!
                                throw new Exception("Unexpected field type");
                        }
                    }
                }

                return new Owner(); //todo need return message not found
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(Owner owner)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write('T');
                    writer.Write(TableName);
                    writer.Write('I');
                    writer.Write(owner.Id);
                    writer.Write('S');
                    writer.Write(owner.FirstName);
                    writer.Write('S');
                    writer.Write(owner.LastName);
                    writer.Write('E');
                    writer.Write("%end%");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(Owner owner, string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write('T');
                    writer.Write(TableName);
                    writer.Write('I');
                    writer.Write(owner.Id);
                    writer.Write('S');
                    writer.Write(owner.FirstName);
                    writer.Write('S');
                    writer.Write(owner.LastName);
                    writer.Write('E');
                    writer.Write("%end%");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

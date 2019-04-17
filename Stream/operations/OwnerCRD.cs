using Stream.database;
using Stream.interfaces;
using Stream.models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stream.operations
{
    class OwnerCRD : ICRD<Owner>
    {
        public string path = Path.Combine(Environment.CurrentDirectory, "DataBase.dat");
        public void Delete(int id)
        {
            string newPath = Path.Combine(Environment.CurrentDirectory, "NewDataBase.dat");
            try
            {
                FileStream fs = new FileStream("NewDataBase.dat", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    reader.Read();
                    while (reader.PeekChar() != -1)
                    {
                        var owner = new Owner();
                        owner.Id = reader.ReadInt32();
                        owner.FirstName = reader.ReadString();
                        owner.LastName = reader.ReadString();
                        if (owner.Id != id)
                        {
                            Insert(owner, newPath);
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
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    //while (reader.BaseStream.Position != reader.BaseStream.Length)
                    while (reader.PeekChar() != -1)
                    {
                        var owner = new Owner();
                        owner.Id = reader.ReadInt32();
                        owner.FirstName = reader.ReadString();
                        owner.LastName = reader.ReadString();
                        owners.Add(owner);
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
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        owner.Id = reader.ReadInt32();
                        owner.FirstName = reader.ReadString();
                        owner.LastName = reader.ReadString();
                        if (owner.Id != id)
                        {
                            break;
                        }
                    }
                }

                return owner;
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
                    writer.Write(owner.Id);
                    writer.Write(owner.FirstName);
                    writer.Write(owner.LastName);
                }
                dbFormat format = new dbFormat();
                format.ChangeFormatA("owners");
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
                    writer.Write(owner.Id);
                    writer.Write(owner.FirstName);
                    writer.Write(owner.LastName);
                }
                dbFormat format = new dbFormat();
                format.ChangeFormatM("owners");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

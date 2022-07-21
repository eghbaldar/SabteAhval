using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PNationalCard.Entity;
using PNationalCard.Definition;

namespace PNationalCard.DataProvider
{
    internal sealed partial class DAL : HNP.DataProvider.Base
    {
        internal bool SelectPerson(Person obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                bool IsCount = false;
                command.CommandText = "Person_SP_Select";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NationalID", SqlDbType.BigInt)).Value = obj.NationalID;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.SingleRow);
                while (dr.Read())
                {
                    obj.NationalID = Int64.Parse(dr["NationalID"].ToString());
                    obj.Status = PNationalCard.Definition.NCollections.Status[short.Parse(dr["StatusID"].ToString())];
                    obj.Office = PNationalCard.Definition.NCollections.Offices[short.Parse(dr["OfficeID"].ToString())];
                    IsCount = true;
                }
                dr.Close();
                command.Connection.Close();
                command.Dispose();
                return IsCount;
            }
        }

        internal void SelectPerson(PersonCollection Persons)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_SelectAll";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Person obj = new Person();
                    obj.NationalID = Int64.Parse(dr["NationalID"].ToString());
                    obj.Office = NCollections.Offices[Int16.Parse(dr["OfficeID"].ToString())];
                    obj.Status = NCollections.Status[short.Parse(dr["StatusID"].ToString())];
                    Persons.Add(obj);
                }
                dr.Close();
            }
        }

        internal void SelectPersonWithStatus(PersonCollection Persons,short StatusID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_SelectAllWithStatus";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt)).Value = StatusID;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Person obj = new Person();
                    obj.NationalID = Int64.Parse(dr["NationalID"].ToString());
                    obj.Office = NCollections.Offices[Int16.Parse(dr["OfficeID"].ToString())];
                    obj.Status = NCollections.Status[short.Parse(dr["StatusID"].ToString())];
                    Persons.Add(obj);
                }
                dr.Close();
            }
        }


        internal void SelectPersonWithOffice(PersonCollection Persons,short OfficeID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_SelectAllWithOffice";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.TinyInt)).Value = OfficeID;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Person obj = new Person();
                    obj.NationalID = Int64.Parse(dr["NationalID"].ToString());
                    obj.Office = NCollections.Offices[Int16.Parse(dr["OfficeID"].ToString())];
                    obj.Status = NCollections.Status[short.Parse(dr["StatusID"].ToString())];
                    Persons.Add(obj);
                }
                dr.Close();
            }
        }


        internal void GetAllDefinition(AllCollection all)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "GetAllCollection";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
                all.Status.Clear();
                while (dr.Read())
                {
                    Status obj = new Status();
                    obj.StatusID = short.Parse(dr["StatusID"].ToString());
                    obj.StatusDesc = dr["StatusDesc"].ToString();
                    all.Status.Add(obj);
                }

                dr.NextResult();
                all.Offices.Clear();
                while (dr.Read())
                {
                    Office obj = new Office();
                    obj.OfficeID = short.Parse(dr["OfficeID"].ToString());
                    obj.OfficeName = dr["OfficeName"].ToString();
                    obj.Address = dr["Address"].ToString();
                    all.Offices.Add(obj);
                }

                dr.Close();
                command.Dispose();
            }
        }
    }
}

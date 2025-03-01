﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Data
{
    public class DogDB : IDogDB
    {
        private ConnectionDB _conn;

        public bool Insert(Dog dog)
        {
            bool status = false;
            string sql = string.Format(Dog.INSERT, dog.Name);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Update(Dog dog)
        {
            bool status = false;
            string sql = string.Format(Dog.UPDATE, dog.Name, dog.Id);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = string.Format(Dog.DELETE, id);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public List<Dog> Select()
        {
            using (_conn = new ConnectionDB())
            {
                string sql = Dog.SELECT;
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }
        public Dog SelectById(int id)
        {
            using (_conn = new ConnectionDB())
            {
                string sql = string.Format(Dog.SELECTBYID, id); 
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData)[0];
            }
        }

        private List<Dog> TransformSQLReaderToList (SqlDataReader returnData)
        {
            var list = new List<Dog>();

            while (returnData.Read())
            {
                var item = new Dog() { 
                    Id = int.Parse(returnData["id"].ToString()),
                    Name = returnData["name"].ToString(),
                };

                list.Add(item);
            }
            return list;
        }
    }
}

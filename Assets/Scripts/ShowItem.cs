using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour {

	public Text txtChange;

	public void show(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);

		dbconn.Open(); //Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand();

		string sqlQuery = "Select * " + "From Account";
		dbcmd.CommandText = sqlQuery;

		IDataReader reader = dbcmd.ExecuteReader();

		while(reader.Read()){
			string username = reader.GetString(1);
			string password = reader.GetString(2);
			int age = reader.GetInt32(3) ;

			txtChange.text += "\nUsername = " + username + "\nPassword = " + password + "\nAge = " + age;
		}

		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
	}
}

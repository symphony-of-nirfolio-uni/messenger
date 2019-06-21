using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace DataAccess
{

	public class ChatInfo
	{
		int ChatId; a
		string ChatDesc;
	}

	public struct TimeStamp
	{
		int year;
		int month;
		int day;
		int hours;
		int minutes;
		int seconds;
	}


	public class Record
	{
		int SenderId;
		string Raw;
		bool ReadStatus;
		TimeStamp deliveredOn;
	}

	// abstract factory
	public abstract class DAOFactory
	{
		public abstract IDAO FactoryMethod();
	};

	// concrete factory, creates DAO objects that must be passed in other objects by pointers at runtime
	public class SimpleDAOFactory : DAOFactory
	{
		public override IDAO FactoryMethod()
		{
			return new SimpleDAO();
		}
	}

	// interface for DAO objects 
	public interface IDAO
	{
		// creational
		void CreateDB();
		//void LoadDB();

		/*
		// insert
		void InsertChat();
		void InsertRecord();

		// select
		List <Record> GetRecentMessages(int chatId);
		List <ChatInfo> GetAllChatsFromDB();
		*/

		// TODO - extend operation functionality
	};

	// concrete DAO - MODIFY THIS CLASS
	// simpledb is for init data table ???
	//  create other daos to manage other information/tables
	public class SimpleDAO : IDAO
	{
		SQLiteConnection Connection;
		bool insertion_impossibe = false;
		bool dropped = false;

		public void CreateDB()
		{
			string cs = "URI=file:test.db";

			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(con))
				{
					cmd.CommandText = "CREATE TABLE UserData (username Text, privatekey Text, publickey Text, domain Text);";
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}

		public void Insert(string username, string privatekey, string publickey, string domain)
		{
			if (insertion_impossibe || dropped)
			{
				Console.WriteLine("impossible to write another entry to the db");
				return;
			}

			insertion_impossibe = true;

			string cs = "URI=file:test.db";
			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(con))
				{
					cmd.CommandText = "INSERT INTO UserData(username, privatekey, publickey, domain) VALUES(@username, @privatekey, @publickey, @domain);";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@username", username);
					cmd.Parameters.AddWithValue("@privatekey", privatekey);
					cmd.Parameters.AddWithValue("@publickey", publickey);
					cmd.Parameters.AddWithValue("@domain", domain);
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}


		public List<Tuple<string, string, string, string>> Get()
		{
			List<Tuple<string, string, string, string>> ret = new List<Tuple<string, string, string, string>>();

			string cs = "URI=file:test.db";

			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();

				string stm = "SELECT * FROM UserData";
				using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
				{
					using (SQLiteDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							Console.WriteLine(rdr.GetString(0) + " "
								+ rdr.GetString(1) + " " + rdr.GetString(2) + rdr.GetString(3));

							ret.Add(new Tuple<string, string, string, string>(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)));
						}
					}
				}

				con.Close();
			}

			return ret;
		}


		public void Update_domain(string domain)
		{
			if (dropped)
				return;
			string cs = "URI=file:test.db";

			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(con))
				{
					cmd.CommandText = "UPDATE UserData SET domain=@dmain;";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@dmain", domain);
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}

		public void Update_username(string username)
		{
			if (dropped)
				return;
			string cs = "URI=file:test.db";

			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(con))
				{
					cmd.CommandText = "UPDATE UserData SET username=@usrname;";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@usrname", username);
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}

		public void Init(string fileName)
		{
			Console.WriteLine(insertion_impossibe);
			Console.WriteLine("------");
			if (!File.Exists("./test.db"))
			{
				CreateDB();
			}
		}

		public void drop()
		{
			if (dropped)
			{
				return;
			}

			dropped = true;
			string cs = "URI=file:test.db";
			using (SQLiteConnection con = new SQLiteConnection(cs))
			{
				con.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(con))
				{
					cmd.CommandText = "DROP TABLE IF EXISTS UserData";
					cmd.ExecuteNonQuery();
				}
				con.Close();
			}
		}
	}
}
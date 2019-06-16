using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataAccess
{

	public class ChatInfo
	{
		int ChatId;
		string ChatDesc;
	}

	struct TimeStamp
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
	class SimpleDAO : IDAO
	{
		SQLiteConnection Connection;

		public void CreateDB()
		{
			
		}

		/*
		public void LoadDB()
		{

		}
		*/
	}
}

namespace DBTestEnv
{
	class Program
	{
		static void Main(string[] args)
		{
	
		}
	}
}


using System;

namespace Dos_e
{
	class Program
	{
		static void Main(string[] args)
		{
			string[,] cardFile = new string[0, 4];
			string userInput;
			bool working = true;

			while (working)
			{
				WriteCommands();
				userInput = Console.ReadLine();
				Console.Clear();

				switch (userInput)
				{
					case "1":
						cardFile = AddFile(cardFile);
                        Console.Clear();
						break;
					case "2":
						WriteFiles(cardFile);
						break;
					case "3":
						cardFile = DeleteFile(cardFile);
						Console.Clear();
						break;
					case "4":
						ResearchName(cardFile);
						break;
					case "5":
						Console.WriteLine("До свидания.");
						working = false;
						break;
					default:
						Console.WriteLine("Некорректный номер.");
						break;
				}
			}
			Console.ReadKey();
		}

		static string[,] AddFile(string[,] cardFile)
		{
			string[,] tempCardFile = new string[cardFile.GetLength(0) + 1, 4];

			for (int i = 0; i < cardFile.GetLength(0); i++)
			{
				for (int j = 0; j < cardFile.GetLength(1); j++)
				{
					tempCardFile[i, j] = cardFile[i, j];
				}
			}

			Console.Write("Введите фамилию: ");
			tempCardFile[tempCardFile.GetLength(0) - 1, 0] = Console.ReadLine();
			Console.Write("Введите имя: ");
			tempCardFile[tempCardFile.GetLength(0) - 1, 1] = Console.ReadLine();
			Console.Write("Введите отчество: ");
			tempCardFile[tempCardFile.GetLength(0) - 1, 2] = Console.ReadLine();
			Console.Write("Введите должность: ");
			tempCardFile[tempCardFile.GetLength(0) - 1, 3] = Console.ReadLine();

			cardFile = tempCardFile;
			return cardFile;
		}

		static void WriteFiles(string[,] cardFile)
		{
			for (int i = 0; i < cardFile.GetLength(0); i++)
			{
				WriteFile(i, cardFile);
			}
			Console.WriteLine();
		}

		static string[,] DeleteFile(string[,] cardFile)
		{
			Console.WriteLine("Введите НОМЕР досье, которое хотите удалить.");
			int userValue = Convert.ToInt32(Console.ReadLine());

			string[,] tempCardFile = new string[cardFile.GetLength(0) - 1, 3];

			for (int i = 0; i < userValue - 1; i++)
			{
				for (int j = 0; j < cardFile.GetLength(1); i++)
				{
					tempCardFile[i, j] = cardFile[i, j];
				}
			}


			for (int i = userValue; i < cardFile.GetLength(0); i++)
			{
				for (int j = 0; j < cardFile.GetLength(1); j++)
				{
					tempCardFile[i - 1, j] = cardFile[i, j];
				}
			}

			cardFile = tempCardFile;
			return cardFile;
		}

		static void ResearchName(string[,] cardFile)
		{
			Console.Write("Введите фамилию: ");
			string userValue = Console.ReadLine();

			for (int i = 0; i < cardFile.GetLength(0); i++)
			{
				if (userValue == cardFile[i, 0])
					WriteFile(i, cardFile);
			}

			Console.WriteLine();
			Console.ReadLine();
			Console.Clear();
		}

		static void WriteCommands()
		{
			Console.WriteLine("1. Добавить досье.");
			Console.WriteLine("2. Вывести все досье.");
			Console.WriteLine("3. Удалить досье.");
			Console.WriteLine("4.Поиск по фамилии.");
			Console.WriteLine("5. Выход.");
			Console.Write("Введите номер команды: ");
		}

		static void WriteFile(int serialNumber, string[,] cardFile)
		{
			Console.WriteLine((serialNumber + 1) + ". " + cardFile[serialNumber, 0] + " " + cardFile[serialNumber, 1] + " " + cardFile[serialNumber, 2] + " " + cardFile[serialNumber, 3]);
		}
	}
}


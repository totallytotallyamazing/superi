namespace Superi.Features
{
	public static class Texts
	{
	    public static TextList GetTexts()
		{
			return new TextList(true);
		}

		public static bool UpdateTextName(string Name, int Id)
		{
			Text text = new Text(Id);
			text.Name = Name;
			return text.Save();
		}

		public static bool UpdateTextName(string Name, int Id, string Alias)
		{
			Text text = new Text(Id);
			text.Name = Name;
			text.Alias = Alias;
			return text.Save();
		}

		public static bool UpdateTextValue(string Description, int ID)
		{
			Text text = new Text(ID);
			text.Value = Description;
			return text.Save();
		}

		public static bool DeleteText(int ID)
		{
			Text text = new Text(ID);
			return text.Remove();
		}

		public static bool InsertText(string Name)
		{
			Text text = new Text();
			text.Name = Name;
			return text.Save();
		}

		public static bool InsertText(string Name, string Alias)
		{
			Text text = new Text();
			text.Name = Name;
			text.Alias = Alias;
			return text.Save();
		}
	}
}

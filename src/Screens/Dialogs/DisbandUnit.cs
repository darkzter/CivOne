// CivOne
//
// To the extent possible under law, the person who associated CC0 with
// CivOne has waived all copyright and related or neighboring rights
// to CivOne.
//
// You should have received a copy of the CC0 legalcode along with this
// work. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

using System.Linq;
using CivOne.Advances;
using CivOne.Enums;
using CivOne.Graphics;
using CivOne.Units;
using CivOne.UserInterface;

namespace CivOne.Screens.Dialogs
{
	internal class DisbandUnit : BaseDialog
	{
		private readonly Picture[] _textLines;

		protected override void FirstUpdate()
		{
			int menuWidth = _textLines.Max(b => b.Width) + 5;
			Menu menu = new Menu(Palette, Selection(45, 28, menuWidth, 10))
			{
				X = 103,
				Y = 100,
				MenuWidth = menuWidth,
				ActiveColour = 11,
				TextColour = 5,
				FontId = 0
			};
			menu.Items.Add("Unit Disbanded.").OnSelect(Cancel);
			menu.MissClick += Cancel;
			menu.Cancel += Cancel;
			AddMenu(menu);
		}

		private static Picture[] TextPictures(City city, IUnit unit)
		{
			string[] message = new string[] { $"{city.Name} can't support", $"{unit.Name}." };
			Picture[] output = new Picture[message.Length];
			for (int i = 0; i < message.Length; i++)
				output[i] = Resources.GetText(message[i], 0, 15);
			return output;
		}

		public DisbandUnit(City city, IUnit unit) : base(58, 72, TextPictures(city, unit).Max(b => b.Width) + 52, 62)
		{
			bool modernGovernment = Human.HasAdvance<Invention>();
			IBitmap governmentPortrait = Icons.GovernmentPortrait(Human.Government, Advisor.Defense, modernGovernment);
			
			Palette palette = Common.DefaultPalette;
			for (int i = 144; i < 256; i++)
			{
				palette[i] = governmentPortrait.Palette[i];
			}
			this.SetPalette(palette);

			DialogBox.AddLayer(governmentPortrait, 2, 2);
			DialogBox.DrawText("Defense Minister:", 0, 15, 47, 4);
			DialogBox.FillRectangle(47, 11, 94, 1, 11);

			_textLines = TextPictures(city, unit);
			for (int i = 0; i < _textLines.Length; i++)
			{
				DialogBox.AddLayer(_textLines[i], 47, (_textLines[i].Height * i) + 13);
			}
		}
	}
}
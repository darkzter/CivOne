// CivOne
//
// To the extent possible under law, the person who associated CC0 with
// CivOne has waived all copyright and related or neighboring rights
// to CivOne.
//
// You should have received a copy of the CC0 legalcode along with this
// work. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

using CivOne.Enums;
using CivOne.Interfaces;
using CivOne.Templates;

namespace CivOne.Units
{
	internal class Nuclear : BaseUnit
	{
		public Nuclear() : base(16, 99, 0, 16)
		{
			Class = UnitClass.Air;
			Type = Unit.Nuclear;
			Name = "Nuclear";
			RequiredTech = null;
			ObsoleteTech = null;
			SetIcon('D', 0, 0);
		}
	}
}
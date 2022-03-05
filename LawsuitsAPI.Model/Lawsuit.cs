using System;

namespace LawsuitsAPI.Model
{
	public class Lawsuit
	{
		public int Id { get; set; }
		public string CaseTitle { get; set; }
		public string Number { get; set; }
		public int CourtId { get; set; }
	}
}


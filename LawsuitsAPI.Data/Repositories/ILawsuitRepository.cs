using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawsuitsAPI.Model;

namespace LawsuitsAPI.Data.Repositories
{
	public interface ILawsuitRepository
	{
        Task<IEnumerable<Lawsuit>> GetAllLawsuits();
		Task<Lawsuit> GetLawsuitDetails(int id);
		Task<bool> InsertLawsuit(Lawsuit lawsuit);
		Task<bool> UpdateLawsuit(Lawsuit lawsuit);
		Task<bool> DeleteLawsuit(Lawsuit lawsuit);
	}
}


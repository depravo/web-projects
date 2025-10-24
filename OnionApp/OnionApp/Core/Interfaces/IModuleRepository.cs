using OnionApp.Core.Entities;

namespace OnionApp.Core.Interfaces {
	public interface IModuleRepository : IRepository<Module>{
		Task<IEnumerable<Module>> GetModulesByCourse(int couresId);
	}
}

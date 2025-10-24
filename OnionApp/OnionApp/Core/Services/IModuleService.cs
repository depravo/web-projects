using OnionApp.Application.DTO;

namespace OnionApp.Core.Services {

	public interface IModuleService {
		Task<IEnumerable<ModuleResponseDto>> GetModuleByCourseIdAsync(int courseId);
		Task<IEnumerable<ModuleResponseDto>> GetAllModulesAsync();
		Task CreateModuleAsync(ModuleDto moduleDto);
		Task UpdateModuleAsync(int id, ModuleUpdateDto moduleDto);
		Task DeleteModuleAsync(int id);
	}
}

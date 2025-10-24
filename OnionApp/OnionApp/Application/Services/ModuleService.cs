using OnionApp.Application.DTO;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Application.Mappings;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Services {
	public class ModuleService : IModuleService {

		private readonly IModuleRepository _moduleRepository;

		public ModuleService(IModuleRepository moduleRepository) {
			_moduleRepository = moduleRepository;
		}

		public async Task CreateModuleAsync(ModuleDto moduleDto) {
			var module = ModuleMapper.MapToEntity(moduleDto);
			await _moduleRepository.AddAsync(module);
		}

		public async Task DeleteModuleAsync(int id) {
			await _moduleRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ModuleResponseDto>> GetAllModulesAsync() {
			var modules = await _moduleRepository.GetAllAsync();
			return modules.Select(m => ModuleMapper.MapToResponseDto(m));
		}

		public async Task<IEnumerable<ModuleResponseDto>> GetModuleByCourseIdAsync(int courseId) {
			var modules = await _moduleRepository.GetModulesByCourse(courseId);
			return modules == null ? null : modules.Select(ModuleMapper.MapToResponseDto);
		}

		public async Task UpdateModuleAsync(int id, ModuleUpdateDto moduleDto) {
			var module = await _moduleRepository.GetByIdAsync(id);
			if (module == null)
				throw new KeyNotFoundException($"Module with ID {id} not found");
			module.Update(moduleDto.Title, moduleDto.OrderNumber);
			await _moduleRepository.UpdateAsync(module);
		}
	}
}

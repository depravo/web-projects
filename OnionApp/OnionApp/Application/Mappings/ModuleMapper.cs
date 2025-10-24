using OnionApp.Application.DTO;
using OnionApp.Core.Entities;

namespace OnionApp.Application.Mappings {
	public class ModuleMapper {
		public static ModuleResponseDto MapToResponseDto(Module module) {
			if (module == null) return null;

			return new ModuleResponseDto {
				Id = module.Id,
				Title = module.Title,
				OrderNumber = module.OrderNumber
			};
		}

		public static Module MapToEntity(ModuleDto moduleDto) {
			if (moduleDto == null) return null;

			return new Module(moduleDto.Title, moduleDto.OrderNumber, moduleDto.CourseId);
		}
	}
}

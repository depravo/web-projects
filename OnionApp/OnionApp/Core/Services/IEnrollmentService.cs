using OnionApp.Application.DTO;

namespace OnionApp.Core.Services {
	public interface IEnrollmentService {
		Task<EnrollmentResponseDto> GetEnrollmentByIdAsync(int id);
		Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync();
		Task CreateEnrollmentAsync(EnrollmentDto enrollmentDto);
		Task UpdateEnrollmentAsync(int id, EnrollmentUpdateDto enrollmentDto);
		Task DeleteEnrollmentAsync(int id);
	}
}

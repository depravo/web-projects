using OnionApp.Application.DTO;
using OnionApp.Application.Mappings;
using OnionApp.Core.Interfaces;
using OnionApp.Core.Services;
using OnionApp.Infrastructure.Repositories;

namespace OnionApp.Application.Services {
	public class EnrollmentService : IEnrollmentService {
		private readonly IEnrollmentRepository _enrollmentRepository;

		public EnrollmentService(IEnrollmentRepository enrollmentRepository) {
			_enrollmentRepository = enrollmentRepository;
		}
		public async Task CreateEnrollmentAsync(EnrollmentDto enrollmentDto) {
			var enrollment = EnrollmentMapper.MapToEntity(enrollmentDto);
			await _enrollmentRepository.AddAsync(enrollment);
		}

		public async Task DeleteEnrollmentAsync(int id) {
			await _enrollmentRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync() {
			var enrollments = await _enrollmentRepository.GetAllAsync();
			return enrollments.Select(e => EnrollmentMapper.MapToResponseDto(e));
		}

		public async Task<EnrollmentResponseDto> GetEnrollmentByIdAsync(int id) {
			var enrollment = await _enrollmentRepository.GetByIdAsync(id);
			return enrollment == null ? null : EnrollmentMapper.MapToResponseDto(enrollment);

		}

		public async Task UpdateEnrollmentAsync(int id, EnrollmentUpdateDto enrollmentDto) {
			var enrollment = await _enrollmentRepository.GetByIdAsync(id);
			if (enrollment == null)
				throw new KeyNotFoundException($"User with ID {id} not found");

			enrollment.Update(enrollmentDto.EnrolledAt, enrollmentDto.Grade);
			await _enrollmentRepository.UpdateAsync(enrollment);
		}
	}
}

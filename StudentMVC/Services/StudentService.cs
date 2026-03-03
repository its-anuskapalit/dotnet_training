using StudentPortalMvc.Models;
using StudentPortalMvc.Repositories;

namespace StudentPortalMvc.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public async Task<bool> CreateAsync(Student student)
        {
            if (await _repo.EmailExistsAsync(student.Email))
                return false;

            student.CreatedAt = DateTime.Now;

            await _repo.AddAsync(student);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            await _repo.UpdateAsync(student);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
            return true;
        }
    }
}
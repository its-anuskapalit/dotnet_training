using System;
using UniExamPro.Repositories;
namespace UniExamPro.Integrations
{
    // Class to bind courses to departments
    public class DepartmentCourseBinder
    {
        private readonly DepartmentRepository departmentRepo;
        private readonly CourseRepository courseRepo;
        // Constructor
        public DepartmentCourseBinder(DepartmentRepository deptRepo, CourseRepository courseRepo)
        {
            this.departmentRepo = deptRepo;
            this.courseRepo = courseRepo;
        }
        // Method to bind course to department
        public void BindCourseToDepartment(int courseId, int departmentId)
        {
            var dept = departmentRepo.GetById(departmentId);
            var course = courseRepo.GetById(courseId);

            // Validate existence and association
            if (dept == null || course == null)
                throw new Exception("Department or Course not found");

            if (course.DepartmentId != departmentId)
                throw new Exception("Course does not belong to this Department");
        }
    }
}

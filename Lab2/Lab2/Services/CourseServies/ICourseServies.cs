using Lab2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Services.CourseServies
{
    public interface ICourseServies
    {
        public List<CourseDTO> Get();
        public CourseDTO? Get(int id);
        public CourseDTO? Put(int id, CourseDTO course);
        public CourseDTO? Post(CourseDTO course);
        public CourseDTO? Delete(int id);
    }
}

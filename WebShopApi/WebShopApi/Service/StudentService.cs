using MongoDB.Driver;
using WebShopApi.Models;

namespace WebShopApi.Service
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(Guid id);
        Student Create(Student student);
        void Update(Guid id, Student student);
        void Remove(Guid id);
    }
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCoursesCollectionName);
        }

        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Student Get(Guid id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(Guid id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}
